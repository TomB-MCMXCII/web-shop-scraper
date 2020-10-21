using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebShopScraper.Core.Models._220;
using WebShopScraper.Models;
using WebShopScraper.Models._1A;

namespace WebShopScraper
{
    public class Application
    {
        private readonly IConfiguration _config;
        private readonly IScraper _scraper;
        public List<IShop> Shops;
        public Application(IConfiguration config,IScraper scraper)
        {
            _config = config;
            _scraper = scraper;
            Shops = new List<IShop>();
        }
        public void StartApplication()
        {
            InitializeShops();
            StartScrape();
        }
        public void InitializeShops()
        {
            CreateShop(new Shop1ACreator(_config));
            CreateShop(new Shop220Creator(_config));
        }
        public void StartScrape()
        {
            _scraper.ScrapeShops<ElectricScooter>(Shops);
            _scraper.ScrapeShops<Cpu>(Shops);
        }
        public void CreateShop(ShopCreator creator)
        {
            creator.Create();
            Shops.Add(creator.Shop);
        }
    }
}
