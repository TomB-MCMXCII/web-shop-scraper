using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebShopScraper.Models;

namespace WebShopScraper.Core.Models._220
{
    public class Shop220Creator : ShopCreator
    {
        private readonly IConfiguration _config;
        public Shop220Creator(IConfiguration config)
        {
            _config = config;
        }
        public override IShop CreateInstance()
        {
            Shop = new Shop220(_config);
            return Shop;
        }
    }
}
