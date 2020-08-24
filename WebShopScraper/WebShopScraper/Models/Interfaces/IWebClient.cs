using RestSharp;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public interface IWebClient
    {
        Task<string> GetPageHtmlContent(int pageNumber);
        void SetBaseUri(Uri baseUri);
        void SetPath(string path);
    }
}