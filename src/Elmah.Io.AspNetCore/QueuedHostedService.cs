﻿using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Elmah.Io.AspNetCore
{
    public class QueuedHostedService : BackgroundService
    {
        private readonly IBackgroundTaskQueue _taskQueue;
        private readonly IOtherBackgroundTaskQueue otherBackgroundTaskQueue;

        public QueuedHostedService(IBackgroundTaskQueue taskQueue, IOtherBackgroundTaskQueue otherBackgroundTaskQueue)
        {
            _taskQueue = taskQueue;
            this.otherBackgroundTaskQueue = otherBackgroundTaskQueue;
        }        

        protected async override Task ExecuteAsync(
            CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {

                var workItem = await _taskQueue.DequeueAsync(cancellationToken);

                try
                {
                    var blah = workItem(cancellationToken);
                    otherBackgroundTaskQueue.QueueBackgroundWorkItem(blah);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}