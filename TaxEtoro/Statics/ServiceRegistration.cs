﻿using Calculations;
using Calculations.Interfaces;
using Database.DataAccess;
using Database.DataAccess.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using TaxEtoro.Interfaces;
using ResultsPresenter;
using ResultsPresenter.Interfaces;
using TaxCalculatingService.BussinessLogic;
using TaxCalculatingService.Interfaces;

namespace TaxEtoro.Statics;

public static class TaxEtoroServiceRegistration
{
    public static void RegisterServices(IServiceCollection services)
    {       
        services.AddTransient<ITaxCalculations, TaxCalculations>();
        services.AddSingleton<IActionPerformer, ActionPerformer>();
        services.AddTransient<IClosedPositionsDataAccess, ClosedPositionsDataAccess>();
        services.AddTransient<ITransactionReportsDataAccess, TransactionReportsDataAccess>();
        services.AddTransient<IFileWriter, FileWriter>();
        services.AddSingleton<IFileCleaner, FileCleaner>();
        services.AddSingleton<IFileProcessor, FileProcessor>();
    }
}