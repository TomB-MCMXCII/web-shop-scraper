using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShopScraper.Core;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public class ShopService : IShopService
    { 
        private readonly IWebClient _client;
        private readonly IServiceProvider _serviceProvider;
        public ShopService(IWebClient client, IServiceProvider serviceProvider)
        {
            _client = client;
            //_productService = productService;
            _serviceProvider = serviceProvider;
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
            IProductService<ElectricScooter> _productService = (IProductService<ElectricScooter>)_serviceProvider.GetService(typeof(IProductService<ElectricScooter>));
            var products = new List<ElectricScooter>();
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
            _productService.SaveProducts(products);
        }
    }
}
