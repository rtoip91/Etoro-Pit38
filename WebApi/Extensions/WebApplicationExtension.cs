﻿using TaxCalculatingService.Interfaces;
using TaxEtoro.Interfaces;

namespace WebApi.Extensions
{
    internal static class WebApplicationExtension
    {

        private static Task calculationTask;
        private static Task clearResultTask;

        private static readonly CancellationTokenSource CancellationTokenSource = new();
        
        public static void RunPeriodicTasks(this WebApplication? webApplication)
        {
            var actionPerformer = webApplication?.Services.GetService<IActionPerformer>();
            var fileProcessor = webApplication?.Services.GetService<IFileProcessor>();

            calculationTask = Task.Factory.StartNew(() => fileProcessor.ProcessFiles(CancellationTokenSource.Token), TaskCreationOptions.LongRunning);
            clearResultTask= Task.Factory.StartNew(() => actionPerformer.ClearResultFilesPeriodically(), TaskCreationOptions.LongRunning);
        }
        
        
    }
}
