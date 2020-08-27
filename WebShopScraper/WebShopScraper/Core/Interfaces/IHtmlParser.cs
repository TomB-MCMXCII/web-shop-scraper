using RestSharp;
using System.Collections.Generic;
using System.Net.Http;

namespace WebShopScraper.Models
{
    public interface IHtmlParser
    {
        List<ElectricScooter> GetProducts(string response);
    }
}