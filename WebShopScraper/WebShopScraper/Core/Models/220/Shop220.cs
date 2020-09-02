using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebShopScraper.Models;

namespace WebShopScraper.Core.Models._220
{
    public class Shop220 : IShop
    {
        public Shop220(IConfiguration config)
        {
            _config = config;
            Categories = new List<Category>();
        }
        private readonly IConfiguration _config;
        public ShopName ShopName => ShopName.Shop220;

        public Uri BaseUrl { get; set; }
        public List<Category> Categories { get; set; }

        public void SetBaseUrl() => BaseUrl = new Uri(_config.GetSection("220:BaseUrl").Value.ToString());

        public void SetCategories()
        {
            foreach (var a in (ProductCategory[])Enum.GetValues(typeof(ProductCategory)))
            {
                Categories.Add(new Category()
                {
                    ProductCategory = a,
                    Path = _config.GetSection($"220:CategoryPaths:{a}").Value.ToString()
                });
            }
        }
    }
}
