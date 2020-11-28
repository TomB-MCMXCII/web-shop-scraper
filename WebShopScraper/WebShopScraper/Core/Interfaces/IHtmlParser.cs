using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Models
{
    public interface IShopProductParser
    {
        List<TEntity> ParseHtmlStringToProducts<TEntity>(string response) where TEntity : Product, new();
    }
}