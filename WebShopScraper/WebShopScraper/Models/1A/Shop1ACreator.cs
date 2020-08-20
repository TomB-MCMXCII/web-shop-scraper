using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Models._1A
{
    public class Shop1ACreator : ShopCreator
    {
        private readonly IConfiguration _config;
        public Shop1ACreator(IConfiguration config)
        {
            _config = config;
        }
        public override IShop GetShop()
        {
            return new Shop1A(_config);
        }
    }
}
