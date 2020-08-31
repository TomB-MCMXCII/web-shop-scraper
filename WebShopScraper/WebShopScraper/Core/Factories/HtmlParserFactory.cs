using RestSharp;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public static class HtmlParserFactory
    {
        public static IHtmlParser CreateInstance(IShop shop) 
        {
            switch (shop)
            {
                case Shop1A _:
                    return new HtmlParser1A();
                case null:
                    throw new ArgumentNullException();
                default:
                    throw new UnknownShopException();
                    
            }
        }
    }
}
