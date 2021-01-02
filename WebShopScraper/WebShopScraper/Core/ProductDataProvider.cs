using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        public async Task<List<string>> GetProductData<TEntity>(IShop shop,int pageNumber) where TEntity : Product
        {
            var htmlStrings = new List<string>();
            var _client = new WebClient(HttpClientFactory);
            _client.SetBaseUri(shop.BaseUrl);
            foreach(var cat in shop.Categories)
            {
                _client.SetPath(cat.Path);
                
                htmlStrings.Add(await _client.GetPageHtmlContent(pageNumber, shop));
            }
            return htmlStrings;
            
        }
    }
}
