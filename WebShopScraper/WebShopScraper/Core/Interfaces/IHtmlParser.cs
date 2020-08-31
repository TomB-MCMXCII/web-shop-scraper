using RestSharp;
using System.Collections.Generic;
using System.Net.Http;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Models
{
    public interface IHtmlParser
    {
        List<Product> GetProducts(string response);
    }
}