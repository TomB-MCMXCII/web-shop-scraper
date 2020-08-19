using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class ShopWebClient
    {
        private readonly IRestClient _client;
        public Uri baseUrl { get; set; }
        public ShopWebClient(IRestClient client)
        {
            _client = client;
        }
        public 

    }
}
