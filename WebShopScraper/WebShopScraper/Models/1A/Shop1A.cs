using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Models
{
    public class Shop1A : IShop
    {
        private readonly IConfiguration _config;
        public Uri BaseUrl { get; }
        public Shop1A(IConfiguration config)
        {
            _config = config;
            BaseUrl = new Uri(_config.GetSection("1A:BaseUrl").Value.ToString());
        }
        
        
    }
}
