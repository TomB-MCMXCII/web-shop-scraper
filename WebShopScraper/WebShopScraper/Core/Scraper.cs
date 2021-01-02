using Microsoft.Extensions.DependencyInjection;
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
    public class Scraper
    {
        private readonly IProductProcessor _productProcessor;
        private readonly IShopCreator _shopCreator;
        private readonly IServiceProvider _services;
        private IEnumerable<IShop> _shops;
        private readonly ILogger _logger;

        public Scraper(IProductProcessor productProcessor,IShopCreator shopCreator, IServiceProvider services, ILogger<Scraper> logger)
        {
            _productProcessor = productProcessor;
            _shopCreator = shopCreator;
            _services = services;
            _logger = logger;
        }

        public void Build()
        {
            _shops = _shopCreator.CreateShops();
        }

        public async Task Start()
        {
            Build();
            _productProcessor
                .SetShops(_shops);
           
            await _productProcessor.Scrape<Product>();
        }
    }
}
