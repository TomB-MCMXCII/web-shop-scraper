﻿using AngleSharp;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using WebShopScraper.Models;

namespace WebShopScraper.Core.Models._220
{
    public class HtmlParser220<TEntity> : IHtmlParser<TEntity> where TEntity : Product, new()
    {
        private List<TEntity> _products;
        private IHtmlCollection<IElement> _productElements;
        public HtmlParser220()
        {
            _products = new List<TEntity>();
        }
        public List<TEntity> GetProducts(string response)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<AngleSharp.Html.Parser.IHtmlParser>();

            var document = parser.ParseDocument(response);
            _productElements = document.GetElementsByClassName("product-list-item tag-top");
            foreach (var a in _productElements)
            {
                var b = a.GetElementsByClassName("price notranslate").First().TextContent.Replace('€', ' ').Replace(',', '.').Replace(" ", "").Trim();
                try
                {
                    var product = new TEntity()
                    {
                        Name = a.GetElementsByClassName("product-name").First().TextContent.Trim(),
                        Price = decimal.Parse(a.GetElementsByClassName("price notranslate").First().TextContent.Replace('€', ' ').Replace(',', '.').Replace(" ", "").Trim()),
                        Shop = ShopName.Shop220
                    };
                    
                    _products.Add(product);
                }
                catch
                {

                }
            }

            return _products;
        }
        public TEntity SetCustomProperties(TEntity entity)
        {
            return new TEntity();
        }
    }
}