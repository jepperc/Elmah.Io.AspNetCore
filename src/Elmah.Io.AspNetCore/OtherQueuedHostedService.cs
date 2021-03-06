﻿using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Elmah.Io.AspNetCore
{
    public class OtherQueuedHostedService : BackgroundService
    {
        private readonly IOtherBackgroundTaskQueue _taskQueue;
        private Task _backgroundRunner;
        public OtherQueuedHostedService(IOtherBackgroundTaskQueue taskQueue)
        {
            _taskQueue = taskQueue;
        }

        protected override Task ExecuteAsync(
            CancellationToken cancellationToken)
        {
            _backgroundRunner = Task.Run(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        var t = _taskQueue.DequeueAsync(cancellationToken);
                        await t;
                    }
                    catch (Exception ex)
                    {
                    }
                }
            });

            return Task.CompletedTask;
        }
    }
}