using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using WebShopScraper.Core.Models._220;
using WebShopScraper.Models;

namespace WebShopScraper.Core.Models
{
    public class ShopCreator : IShopCreator
    {
        private readonly IConfiguration configuration;

        public ShopCreator(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public IEnumerable<IShop> CreateShops()
        {
            return new List<IShop>()
            {
                new Shop1A(configuration),
                new Shop220(configuration)
            };  
        }
    }
}
