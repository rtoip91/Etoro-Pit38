﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Calculations.Dto;
using Calculations.Interfaces;
using Database.DataAccess.Interfaces;
using Database.Enums;
using ExcelReader.Dto;
using ExcelReader.Interfaces;
using ExcelReader.Statics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ResultsPresenter.Interfaces;
using TaxCalculatingService.Interfaces;

namespace TaxCalculatingService.BussinessLogic;

internal sealed class FileProcessor : IFileProcessor
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IConfiguration _configuration;
    private readonly IFileDataAccess _fileDataAccess;
    private readonly ILogger<FileProcessor> _logger;
    private readonly IExchangeRatesLocker _exchangeRatesLocker;
    private readonly Stopwatch _stopwatch;
    private readonly ManualResetEventSlim _pause;
    private readonly object _locker;

    public FileProcessor(IServiceProvider serviceProvider,
        IConfiguration configuration,
        IFileDataAccess fileDataAccess,
        ILogger<FileProcessor> logger,
        IExchangeRatesLocker exchangeRatesLocker)
    {
        _serviceProvider = serviceProvider;
        _configuration = configuration;
        _fileDataAccess = fileDataAccess;
        _logger = logger;
        _exchangeRatesLocker = exchangeRatesLocker;
        _stopwatch = new Stopwatch();
        _pause = new ManualResetEventSlim(true);
        _locker = new object();
    }

    private async Task ProcessSingleFile(Guid operation, CancellationToken token)
    {
        DirectoryInfo directory =
            FileInputUtil.GetDirectory(@_configuration.GetValue<string>("InputFileStorageFolder"));
        var fileEntity = await _fileDataAccess.GetInputFileDataAsync(operation);
        FileInfo file = directory.GetFiles(fileEntity.InputFileName).FirstOrDefault();
        if (file is null)
        {
            _logger.LogWarning("File {FileEntityInputFileName} was not found, marking as deleted.",
                fileEntity.InputFileName);
            await _fileDataAccess.SetAsDeletedAsync(operation);
            return;
        }

        await ProcessFile(directory, file, operation, fileEntity.FileVersion)
            .ContinueWith(_ => RemoveFile(file), token);
    }

    public async Task ProcessFiles(CancellationToken token)
    {
        if (token.IsCancellationRequested)
        {
            return;
        }


        var numberOfOperations = await _fileDataAccess.GetOperationsToProcessNumberAsync();

        if (numberOfOperations == 0)
        {
            _logger.LogInformation("No pending operations detected waiting for new operation");
            return;
        }

        if (!_stopwatch.IsRunning)
        {
            _stopwatch.Restart();
        }

        do
        {
            IList<Guid> operations = await _fileDataAccess.GetOperationsToProcessAsync();
            await Parallel.ForEachAsync(operations, token,
                async (operation, cancellationToken) =>
                {
                    _pause.Wait(cancellationToken);
                    await ProcessSingleFile(operation, cancellationToken);
                });

            numberOfOperations = await _fileDataAccess.GetOperationsToProcessNumberAsync();
        } while (numberOfOperations > 0);

        _stopwatch.Stop();
        TimeSpan stopwatchResult = _stopwatch.Elapsed;

        _logger.LogInformation($"Calculation took {stopwatchResult:m\\:ss\\.fff}");

        _exchangeRatesLocker.ClearLockers();
    }

    public void PauseProcessing()
    {
        lock (_locker)
        {
            if (_pause.IsSet) ;
            {
                _logger.LogInformation("Pausing processing");
                if (_stopwatch.IsRunning)
                {
                    _stopwatch.Stop();
                }
                _pause.Reset();
            }
        }
    }

    public void ResumeProcessing()
    {
        lock (_locker)
        {
            if (!_pause.IsSet)
            {
                _logger.LogInformation("Resuming processing");
                _pause.Set();
                _stopwatch.Start();
            }
        }
    }

    private void RemoveFile(FileInfo file)
    {
        file.Delete();
        _logger.LogInformation($"File: {file.Name} was deleted");
    }

    private Task ProcessFile(DirectoryInfo directory, FileInfo file, Guid operation, FileVersion fileVersion)
    {
        Task task = Task.Run(async () =>
        {
            try
            {
                await _fileDataAccess.SetAsInProgressAsync(operation);
                await using AsyncServiceScope scope = _serviceProvider.CreateAsyncScope();
                var versionData = scope.ServiceProvider.GetService<ICurrentVersionData>();
                versionData.FileVersion = fileVersion;
                CalculationResultDto dto = await Calculate(directory, file, scope, operation);
                await PresentCalculationResults(dto, file, scope, operation);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error during processing file {file.FullName}");
            }
        });
        return task;
    }

    private async Task<CalculationResultDto> PerformCalculations(string directory, string fileName,
        AsyncServiceScope scope)
    {
        var reader = scope.ServiceProvider.GetService<IExcelDataExtractor>();
        var taxCalculations = scope.ServiceProvider.GetService<ITaxCalculations>();

        _logger.LogInformation($"Started processing of the file {fileName}");
        await reader.ImportDataFromExcel(directory, fileName);
        CalculationResultDto result = await taxCalculations.CalculateTaxes();

        return result;
    }

    private async Task PresentCalculationResults(CalculationResultDto result, FileInfo file,
        AsyncServiceScope scope, Guid operationGuid)
    {
        var fileWriter = scope.ServiceProvider.GetService<IFileWriter>();

        var fileName = await fileWriter.PresentData(operationGuid, file, result);

        _logger.LogInformation($"Created results in {fileName}");
    }

    private async Task<CalculationResultDto> Calculate(DirectoryInfo directory, FileInfo file,
        AsyncServiceScope scope, Guid operation)
    {
        CalculationResultDto dto = await PerformCalculations(directory.FullName, file.Name, scope);
        var dtoString = JsonConvert.SerializeObject(dto);
        await _fileDataAccess.SetAsCalculatedAsync(operation, dtoString);
        return dto;
    }
}