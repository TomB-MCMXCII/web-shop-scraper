﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WebShopScraper.Models;
using WebShopScraper.Models._1A;

namespace WebShopScraper
{
    public class Controller
    {
        private readonly IConfiguration _config;
        private readonly IShopService _service;
        public List<IShop> Shops;
        public Controller(IConfiguration config,IShopService service)
        {
            _config = config;
            _service = service;
            Shops = new List<IShop>();
        }
        public void StartApplication()
        {
            CreateShop(new Shop1ACreator(_config));
            
        }
        public void CreateShop(ShopCreator creator)
        {
            creator.Create();
            Shops.Add(creator.Shop);
        }
    }
}
