﻿using AngleSharp;
using HtmlAgilityPack;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace WebShopScraper.Models
{
    public class HtmlParser1A : IHtmlParser
    {
        private List<ElectricScooter> _products;
        public HtmlParser1A()
        {
            _products = new List<ElectricScooter>();
        }
        public List<ElectricScooter> GetProducts(string response)
        {
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var parser = context.GetService<AngleSharp.Html.Parser.IHtmlParser>();
            var source = response;
            var document = parser.ParseDocument(source);
            var coll = document.GetElementsByClassName("catalog-taxons-product__hover");
            foreach(var a in coll)
            {
                var product = new ElectricScooter()
                {
                    Name = a.GetElementsByClassName("catalog-taxons-product__name").FirstOrDefault().InnerHtml.Trim(),
                    Price = decimal.Parse(a.GetElementsByClassName("catalog-taxons-product-price__item-price").FirstOrDefault().ChildNodes[1].TextContent.Replace(',','.')),
                    Shop = ShopName.Shop1A
                };
                _products.Add(product);
            }


            
            return _products;
        }
    }
}
