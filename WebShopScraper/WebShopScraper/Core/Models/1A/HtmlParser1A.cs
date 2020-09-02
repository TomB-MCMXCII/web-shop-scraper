using AngleSharp;
using System.Collections.Generic;
using System.Linq;
using WebShopScraper.Core.Models;

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
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<AngleSharp.Html.Parser.IHtmlParser>();

            var document = parser.ParseDocument(response);
            var coll = document.GetElementsByClassName("catalog-taxons-product__hover");
            foreach (var a in coll)
            {
                try
                {
                    var product = new Product()
                    {
                        Name = a.GetElementsByClassName("catalog-taxons-product__name").FirstOrDefault().InnerHtml.Trim(),
                        Price = decimal.Parse(MakeDecimalString(a.GetElementsByClassName("catalog-taxons-product-price__item-price").FirstOrDefault().ChildNodes[1].TextContent.Replace(".", ","))),
                        Shop = ShopName.Shop1A
                    };
                    _products.Add(product);
                }
                catch
                {

                }
            }
            return _products;
        }

        private string MakeDecimalString(string price)
        {
            var decimalString = price.Remove(price.Length - 3, 1).Insert(price.Length - 3, ".");
            return decimalString;
        }
    }
}
