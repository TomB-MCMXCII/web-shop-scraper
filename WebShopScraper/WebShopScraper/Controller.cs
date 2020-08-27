using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebShopScraper.Models;
using WebShopScraper.Models._1A;

namespace WebShopScraper
{
    //todo rename class
    public class Application
    {
        private readonly IConfiguration _config;
        private readonly IShopService _service;
        public List<IShop> Shops;
        public Application(IConfiguration config,IShopService service)
        {
            _config = config;
            _service = service;
            Shops = new List<IShop>();
        }
        public void StartApplication()
        {
            SetupShops();
            StartScrape();
        }
        public void SetupShops()
        {
            CreateShop(new Shop1ACreator(_config));
        }
        public void StartScrape()
        {
            _service.ScrapeScooters(Shops);
            //_service.ScrapeLaptops(Shops);
            //_service.ScrapeCpus(Shops);
        }
        public void CreateShop(ShopCreator creator)
        {
            creator.Create();
            Shops.Add(creator.Shop);
        }
    }
}
