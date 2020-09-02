using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using WebShopScraper.Core;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public class ShopService : IShopService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceProvider _serviceProvider;
        public ShopService(IServiceProvider serviceProvider,IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _serviceProvider = serviceProvider;
        }
        public void ScrapeCpus(List<IShop> shops)
        {
            IProductService<Cpu> _productService = (IProductService<Cpu>)_serviceProvider.GetService(typeof(IProductService<Cpu>));

            var products = new List<Cpu>();
            foreach (var a in shops)
            {
                var _client = new WebClient(_httpClientFactory);
                _client.SetBaseUri(a.BaseUrl);
                _client.SetPath(a.Categories.Where(x => x.ProductCategory == ProductCategory.Cpu).FirstOrDefault().Path);

                var pageNumber = 1;
                var nextPage = true;
                while (nextPage)
                {
                    var response = _client.GetPageHtmlContent(pageNumber, a);
                    var parser = HtmlParserFactory.CreateInstance(a);
                    var parsedProducts = parser.GetProducts(response.Result);

                    if (parsedProducts.Count == 0)
                    {
                        nextPage = false;
                    }
                    else
                    {
                        foreach (var c in parsedProducts)
                        {
                            products.Add(new Cpu()
                            {
                                Name = c.Name,
                                Price = c.Price,
                                Shop = c.Shop,
                            });
                        }
                        pageNumber++;
                    }
                }
            }
            _productService.SaveProducts(products);
        }
        public void ScrapeLaptops(List<IShop> shops)
        {
            throw new NotImplementedException();
        }
        public void ScrapeScooters(List<IShop> shops)
        {
            IProductService<ElectricScooter> _productService = (IProductService<ElectricScooter>)_serviceProvider.GetService(typeof(IProductService<ElectricScooter>));

            var products = new List<ElectricScooter>();
            foreach(var a in shops)
            {
                var _client = new WebClient(_httpClientFactory);
                _client.SetBaseUri(a.BaseUrl);
                _client.SetPath(a.Categories.Where(x => x.ProductCategory == ProductCategory.ElectricScooter).FirstOrDefault().Path);

                var pageNumber = 1;
                var nextPage = true;
                while(nextPage)
                {
                    var response = _client.GetPageHtmlContent(pageNumber,a);
                    var parser = HtmlParserFactory.CreateInstance(a);
                    var parsedProducts = parser.GetProducts(response.Result);
                   
                    if (parsedProducts.Count == 0)
                    { 
                        nextPage = false;
                    }
                    else 
                    {
                        foreach (var c in parsedProducts)
                        {
                            products.Add(new ElectricScooter()
                            {
                                Name = c.Name,
                                Price = c.Price,
                                Shop = c.Shop,
                            });
                        }
                        pageNumber++; 
                    }   
                }  
            }
            _productService.SaveProducts(products);
        }
    }
}
