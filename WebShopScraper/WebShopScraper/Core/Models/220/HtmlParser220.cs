using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using WebShopScraper.Models;

namespace WebShopScraper.Core.Models._220
{
    public class HtmlParser220 : BaseParser, IShopProductParser
    {
        public List<TEntity> ParseHtmlStringToProducts<TEntity>(string responses) where TEntity : Product, new()
        {
            List<TEntity> _products = new List<TEntity>();

            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<AngleSharp.Html.Parser.IHtmlParser>();
            
                var document = parser.ParseDocument(responses);
                var _productElements = document.GetElementsByClassName("product-list-item tag-top");

                foreach (var a in _productElements)
                {
                    try
                    {
                        var product = new TEntity()
                        {
                            Name = a.GetElementsByClassName("product-name").First().TextContent.Trim(),
                            Price = decimal.Parse(a.GetElementsByClassName("price notranslate").First().TextContent.Replace('€', ' ').Replace(',', '.').Replace(" ", "").Trim()),
                            Shop = ShopName.Shop220,
                            Url = a.GetElementsByClassName("cover-link").FirstOrDefault().GetAttribute("href")
                        };

                        _products.Add(product);
                    }
                    catch
                    {

                    }
                }
                if (_products.Count == 0)
                {
                    OnZeroProductsParsed(EventArgs.Empty);
                }
            
            
            return _products;
        }

        
    }
}
