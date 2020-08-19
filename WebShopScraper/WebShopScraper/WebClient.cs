using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class WebClient
    {
        private readonly IRestClient _client;
        private readonly ILogger<WebClient> _log;
        private readonly IConfiguration _config;
        public WebClient(IRestClient client, ILogger<WebClient> log, IConfiguration config)
        {
            _client = client;
            _log = log;
            _config = config;
        }
        public void GetPageHtmlContent()
        {
            
        }

    }
}
