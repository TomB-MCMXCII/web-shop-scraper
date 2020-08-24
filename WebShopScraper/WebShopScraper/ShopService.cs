using RestSharp;
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
        private readonly IProductService _productService;
        public ShopService(IWebClient client, IProductService productService)
        {
            _client = client;
            _productService = productService;
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
                    products = parser.GetProducts(response.Result);
                    if (products.Count == 0) nextPage = false;
                    pageNumber++;
                }  
            }
            _productService.AddProducts(products);
        }
    }
}
