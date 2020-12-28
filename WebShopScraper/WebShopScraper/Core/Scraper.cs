using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public class Scraper : IHostedService
    {
        private readonly IProductProcessor _productProcessor;
        private readonly IShopCreator _shopCreator;
        private IEnumerable<IShop> _shops;
        private readonly ILogger _logger;

        public Scraper(IProductProcessor productProcessor,IShopCreator shopCreator, IHostApplicationLifetime appLifetime, ILogger<Scraper> logger)
        {
            _productProcessor = productProcessor;
            _shopCreator = shopCreator;
            appLifetime.ApplicationStarted.Register(OnStarted);
            appLifetime.ApplicationStopping.Register(OnStopping);
            appLifetime.ApplicationStopped.Register(OnStopped);
            _logger = logger;
        }

        public void Build()
        {
            _shops = _shopCreator.CreateShops();
        }

        public void Start()
        {
            _productProcessor
                .SetShops(_shops);
            _productProcessor.Scrape<Cpu>();
                 _productProcessor.Scrape<ElectricScooter>();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("1. StartAsync has been called.");
            Build();
            Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("4. StopAsync has been called.");
            return Task.CompletedTask;
        }

        private void OnStarted()
        {
            Build();
            Start();
            _logger.LogInformation("2. OnStarted has been called.");
        }

        private void OnStopping()
        {
            _logger.LogInformation("3. OnStopping has been called.");
        }

        private void OnStopped()
        {
            _logger.LogInformation("5. OnStopped has been called.");
        }
    }
}
