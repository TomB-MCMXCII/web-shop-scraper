using RestSharp;
using System;

namespace WebShopScraper
{
    public interface IWebClient
    {
        RestResponse GetPageHtmlContent();
        void SetBaseUri(Uri baseUri);
        void SetPath(string path);
    }
}