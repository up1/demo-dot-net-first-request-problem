using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Application
{
    public class WarmupServices : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private readonly HttpClient httpClient;

        public WarmupServices(ILogger<WarmupServices> logger)
        {
            _logger = logger;
            httpClient = new HttpClient();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Starting IHostedService...");

            httpClient.GetAsync("https://localhost:5001");

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("StoppingIHostedService...");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _logger.LogInformation("Dispose HttpClient...");
            httpClient?.Dispose();
        }
    }
}
