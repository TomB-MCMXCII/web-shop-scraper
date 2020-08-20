using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Models._220
{
    public class Shop220 : IShop
    {
        private readonly IConfiguration _config;
        public Uri BaseUrl { get; }
        public Shop220(IConfiguration config)
        {
            _config = config;
            BaseUrl = new Uri(_config.GetSection("220:BaseUrl").Value.ToString());
        }
    }
}
