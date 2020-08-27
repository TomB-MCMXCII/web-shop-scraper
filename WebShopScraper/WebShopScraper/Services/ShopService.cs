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
        
        private Repository _repository;
        public ShopService(IWebClient client,IDataAccess dataAccess)
        {
            _client = client;
            _repository = new Repository(dataAccess);
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
            var products = new List<Product>();
            foreach(var a in shops)
            {
                _client.SetBaseUri(a.BaseUrl);
                _client.SetPath(a.Categories.Where(x => x.ProductCategory == ProductCategory.ElectricScooter).FirstOrDefault().Path);

                var pageNumber = 1;
                var nextPage = true;
                while(nextPage)
                {
                    var response = _client.GetPageHtmlContent(pageNumber);
                    var parser = HtmlParserFactory.CreateInstance(a);
                    var parsedProducts = parser.GetProducts(response.Result);
                    if (parsedProducts.Count == 0)
                    { 
                        nextPage = false;
                    }
                    else 
                    {
                        products.AddRange(parsedProducts);
                        pageNumber++; 
                    }   
                }  
            }
            _repository.SaveProducts(products);
        }
    }
}