using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Models._220
{
    public class Shop220Creator : ShopCreator
    {
        private readonly IConfiguration _config;
        public Shop220Creator(IConfiguration config)
        {
            _config = config;
        }
        public override IShop GetShop()
        {
            return new Shop220(_config);
        }
    }
}
