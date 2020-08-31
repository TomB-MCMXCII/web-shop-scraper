using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebShopScraper.Models;

namespace WebShopScraper.Core.Models._220
{
    public class HtmlParser220 : IHtmlParser
    {
        private List<Product> _products;
        public HtmlParser220()
        {
            _products = new List<Product>();
        }
        public List<Product> GetProducts(string response)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<AngleSharp.Html.Parser.IHtmlParser>();

            var document = parser.ParseDocument(response);
            var coll = document.GetElementsByClassName("product-list-item tag-top");
            foreach (var a in coll)
            {
                var g = a.GetElementsByClassName("product-name").FirstOrDefault().TextContent.Trim();
                var p = a.GetElementsByClassName("price notranslate").FirstOrDefault().TextContent.Replace('€', ' ').Replace(',', '.').Replace(" ","").Trim();

                var product = new Product()
                {
                    Name = a.GetElementsByClassName("product-name").FirstOrDefault().TextContent.Trim(),
                    Price = decimal.Parse(a.GetElementsByClassName("price notranslate").FirstOrDefault().TextContent.Replace('€', ' ').Replace(',', '.').Replace(" ", "").Trim()),
                    Shop = ShopName.Shop220
                };
                _products.Add(product);
            }

            return _products;
        }
    }
}
