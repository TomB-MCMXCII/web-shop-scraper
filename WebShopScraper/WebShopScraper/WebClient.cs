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
        private List<string> contents;
        public WebClient(IRestClient client, IRestRequest request)
        {
            _client = client;
            _request = request;
            contents = new List<string>();
        }
        public void SetBaseUri(Uri baseUri) => _client.BaseUrl = baseUri;
        public void SetPath(string path)
        {
            _request.Resource = path;
            var request = _request;

            _client.BuildUri(request);
        }
        public RestResponse GetPageHtmlContent()
        {
            var page = 0;
            IRestResponse response;
            while (true)
            {
                _request.Method = Method.GET;
                _request.AddParameter("page", 4);
                response = _client.Execute(_request);
                responses.Add(response.Content);
                page++;
            }
            //return response;
        }

    }
}
