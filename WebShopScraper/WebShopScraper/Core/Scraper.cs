using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public class Scraper : IScraper 
    {
        private readonly IProductProcessor _productProcessor;
        private readonly IShopCreator _shopCreator;
        private IEnumerable<IShop> _shops;
        public Scraper(IProductProcessor productProcessor,IShopCreator shopCreator)
        {
            _productProcessor = productProcessor;
            _shopCreator = shopCreator;
        }

        public IScraper Build()
        {
            _shops = _shopCreator.CreateShops();
            return this;
        }

        public IScraper Start()
        {
            _productProcessor
                .SetShops(_shops);
            _productProcessor.Scrape<Cpu>();
                 _productProcessor.Scrape<ElectricScooter>();
            return this;
        }
    }
}
