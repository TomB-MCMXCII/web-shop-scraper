using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Models
{
    public class Shop1A : IShop
    {
        private readonly IConfiguration _config;
        public Uri BaseUrl { get; set; }
        public List<Category> Categories { get; set; }
        public ShopName ShopName => ShopName.Shop1A;
        public Shop1A(IConfiguration config)
        {
            _config = config;
            Categories = new List<Category>();
        }
        public void SetBaseUrl() => BaseUrl = new Uri(_config.GetSection("1A:BaseUrl").Value.ToString());
        //todo create exception 
        public void SetCategories()
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
