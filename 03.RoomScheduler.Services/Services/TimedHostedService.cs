using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoomScheduler.Services.Interfaces;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace RoomScheduler.Services.Services
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;
        private readonly IWebHostEnvironment env;
        private readonly IServiceProvider serviceProvider;
        private Timer timer;

        public TimedHostedService(IServiceProvider serviceProvider, IWebHostEnvironment env)
        {
            this.serviceProvider = serviceProvider;
            this.env = env;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Interlocked.Increment(ref executionCount);

            using IServiceScope serviceScope = serviceProvider.GetService<IServiceScopeFactory>().CreateScope();
            IJsonExportService jsonExportService = serviceProvider.GetService<IJsonExportService>();
            jsonExportService.Export(Path.Combine(env.WebRootPath, "json/") + "roomsExport.json", serviceProvider);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }
    }
}
