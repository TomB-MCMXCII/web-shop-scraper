using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public class WebClient : IWebClient
    {
        private IHttpClientFactory _httpClientFactory { get; set; }
        private HttpClient _client { get; set; }
        private string _path { get; set; }
        public WebClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _client = _httpClientFactory.CreateClient();
        }
        public void SetBaseUri(Uri baseUri) => _client.BaseAddress = baseUri;
        public void SetPath(string path)
        {
            _path = path;
        }
        public async Task<string> GetPageHtmlContent(int pageNumber,IShop shop)
        {
            HttpResponseMessage response;
            if (shop.ShopName == ShopName.Shop1A)
            {
                if (_path.Contains('?'))
                {
                    response = await _client.GetAsync(_path + $"&page={pageNumber}");
                }
                else
                {
                    response = await _client.GetAsync(_path + $"?page={pageNumber}");
                }
            }
            else
            {
                response = await _client.GetAsync(_path + $"?page={pageNumber}");
            }
            var taskString = response.Content.ReadAsStringAsync();
            taskString.Wait();
            return taskString.Result;
        }

    }
}
