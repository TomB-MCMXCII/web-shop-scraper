using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Models
{
    public class HtmlParser1A : BaseParser, IShopProductParser
    { 
        public List<TEntity> ParseHtmlStringToProducts<TEntity>(string responses) where TEntity : Product , new()
        {
            List<TEntity> _products = new List<TEntity>();
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<AngleSharp.Html.Parser.IHtmlParser>();
           
                var document = parser.ParseDocument(responses);
                var coll = document.GetElementsByClassName("catalog-taxons-product__hover");
                foreach (var a in coll)
                {
                    try
                    {
                        var product = new TEntity()
                        {
                            Name = a.GetElementsByClassName("catalog-taxons-product__name").FirstOrDefault().InnerHtml.Trim(),
                            Price = decimal.Parse(MakeDecimalString(a.GetElementsByClassName("catalog-taxons-product-price__item-price").FirstOrDefault().ChildNodes[1].TextContent.Replace(".", ","))),
                            Shop = ShopName.Shop1A,
                            Url = "https://www.1a.lv" + a.GetElementsByClassName("catalog-taxons-product__name").FirstOrDefault().GetAttribute("href")
                        };
                        _products.Add(product);
                    }
                    catch
                    {
                        //var product = new TEntity()
                        //{
                        //    Name = a.GetElementsByClassName("catalog-taxons-product__name").FirstOrDefault().InnerHtml.Trim(),
                        //    Price = decimal.Parse(MakeDecimalString(a.GetElementsByClassName("product-price-details__price-number").FirstOrDefault().ChildNodes[1].TextContent.Replace(".", ","))),
                        //    Shop = ShopName.Shop1A,
                        //    Url = "https://www.1a.lv" + a.GetElementsByClassName("catalog-taxons-product__name").FirstOrDefault().GetAttribute("href")
                        //};
                        //_products.Add(product);
                    }
                }
                if (_products.Count == 0)
                {
                    OnZeroProductsParsed(EventArgs.Empty);
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
