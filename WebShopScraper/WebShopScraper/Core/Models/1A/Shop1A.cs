using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using WebShopScraper.Core.Enums;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Models
{
    public class Shop1A : IShop
    {
        private readonly IConfiguration _config;
        public Uri BaseUrl { get; set; }
        public List<Category> Categories { get; set; }
        public ShopName ShopName { get => ShopName.Shop1A;}

        public Shop1A(IConfiguration config)
        { 
            Categories = new List<Category>();
            _config = config;
            ReadBaseUrl();
            ReadCategories();
        }
        public void ReadBaseUrl() => BaseUrl = new Uri("https://www.1a.lv/");

        public void ReadCategories()
        {
            foreach (var a in (ProductCategory[])Enum.GetValues(typeof(ProductCategory)))
            {
                Categories.Add(new Category()
                {
                    ProductCategory = a,
                    Path = _config.GetSection($"1A:CategoryPaths:{a}").Value.ToString()
                });
            }
        }
    }
}
