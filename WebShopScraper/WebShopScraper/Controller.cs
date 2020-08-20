using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebShopScraper.Models;
using WebShopScraper.Models._1A;
using WebShopScraper.Models._220;

namespace WebShopScraper
{
    public class Controller
    {
        private readonly IConfiguration _config;
        public List<IShop> shops { get; set; }
        public Controller(IConfiguration config)
        {
            _config = config;
            shops = new List<IShop>();
            shops.Add(new Shop1ACreator(_config).GetShop());
            shops.Add(new Shop220Creator(_config).GetShop());
        }

        public void Run()
        {

        }
    }
}
