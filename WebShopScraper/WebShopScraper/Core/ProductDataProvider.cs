using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper.Core
{
    public class ProductDataProvider : IProductDataProvider
    {
        public IHttpClientFactory HttpClientFactory { get; }

        public ProductDataProvider(IHttpClientFactory httpClientFactory)
        {
            HttpClientFactory = httpClientFactory;
        }
        public string GetProductData<TEntity>(IShop shop,int pageNumber) where TEntity : Product
        {
            var _client = new WebClient(HttpClientFactory);
            _client.SetBaseUri(shop.BaseUrl);
            _client.SetPath(shop.Categories.Where(x => x.ProductCategory.ToString() == typeof(TEntity).Name).FirstOrDefault().Path);
            var htmlStrings = new List<string>();
            return _client.GetPageHtmlContent(pageNumber, shop).Result;
        }
    }
}
