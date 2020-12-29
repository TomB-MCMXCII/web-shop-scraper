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
    public class Scraper :  BackgroundService
    {
        private readonly IProductProcessor _productProcessor;
        private readonly IShopCreator _shopCreator;
        private IEnumerable<IShop> _shops;
        private readonly ILogger _logger;

        public Scraper(IProductProcessor productProcessor,IShopCreator shopCreator, IHostApplicationLifetime appLifetime, ILogger<Scraper> logger)
        {
            _productProcessor = productProcessor;
            _shopCreator = shopCreator;
           
            _logger = logger;
        }

        public void Build()
        {
            _shops = _shopCreator.CreateShops();
        }

        public async Task Start()
        {
             _productProcessor
                .SetShops(_shops);
            await _productProcessor.Scrape<Cpu>();
            await _productProcessor.Scrape<ElectricScooter>();
        }

       

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("1. StartAsync has been called.");
            Build();
            await Start();
        }
    }
}
