﻿using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public class ShopService : IShopService
    {
        private readonly IWebClient _client;
        public ShopService(IWebClient client)
        {
            _client = client;
        }
        public void ScrapeCpus(List<IShop> shops)
        {
            throw new NotImplementedException();
        }
        public void ScrapeLaptops(List<IShop> shops)
        {
            throw new NotImplementedException();
        }
        public void ScrapeScooters(List<IShop> shops)
        {
            foreach(var a in shops)
            {
                _client.SetBaseUri(a.BaseUrl);
                _client.SetPath(a.Categories.Where(x => x.ProductCategory == ProductCategory.ElectricScooter).FirstOrDefault().Path);

                var pageNumber = 0;
                var nextPage = true;
                while(nextPage)
                {
                    var response = _client.GetPageHtmlContent(pageNumber);
                    var parser = HtmlParserFactory.CreateInstance(a);
                    var products = parser.GetProducts(response.Result);
                }
                
            }
        }
    }
}
