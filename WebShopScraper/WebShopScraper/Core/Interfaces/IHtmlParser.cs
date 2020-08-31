using RestSharp;
using System.Collections.Generic;
using System.Net.Http;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Models
{
    public interface IHtmlParser<TEntity> where TEntity : Product
    {
        List<TEntity> GetProducts(string response);
    }
}