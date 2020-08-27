﻿using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Models
{
    public class Shop1A : IShop
    {
        private readonly IConfiguration _config;
        public Uri BaseUrl { get; set; }
        public List<Category> Categories { get; set; }
        public ShopName ShopName { get; private set; }
        public Shop1A(IConfiguration config)
        {
            _config = config;
            Categories = new List<Category>();
        }
        public void SetBaseUrl() => BaseUrl = new Uri(_config.GetSection("1A:BaseUrl").Value.ToString());
        public void SetCategories()
        {
            foreach (var a in (ProductCategory[])Enum.GetValues(typeof(ProductCategory)))
            {
                Categories.Add(new Category()
                {
                    ProductCategory = a,
                    Path = _config.GetSection($"1A:CategoryPaths").GetSection($"{a}").Value
            });
            }
        }
    }
}