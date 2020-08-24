using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace WebShopScraper.Models
{
    public class HtmlParser1A : IHtmlParser
    {
        private List<Product> _products;
        public HtmlParser1A()
        {
            _products = new List<Product>();
        }
        public List<Product> GetProducts(string response)
        {
            var document = new HtmlDocument();
            document.LoadHtml(response);
            var products = document.DocumentNode.SelectNodes("/html/body/div[1]/div[3]/div/div/div/div[2]");
            var product = new Product()
            {

            };
            return _products;
        }
    }
}
