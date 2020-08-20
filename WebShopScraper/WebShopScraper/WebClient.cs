using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class WebClient : IWebClient
    {
        private readonly IRestClient _client;
        private readonly IRestRequest _request;
        public WebClient(IRestClient client, IRestRequest request)
        {
            _client = client;
            _request = request;
        }
        public void SetBaseUri(string baseUri) => _client.BaseUrl = new Uri(baseUri);
        public void SetPath(string path)
        {
            _request.Resource = path;
            var request = _request;

            _client.BuildUri(request);
        }
        public RestResponse GetPageHtmlContent()
        {
            throw new NotImplementedException();
        }

    }
}
