using System;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;
using WebShopScraper.Core.Models._220;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public static class ShopProductParserFactory 
    {
        public static IShopProductParser GetShopParserInstance<TEntity>(IShop shop) where TEntity : Product, new()
        {
            switch (shop)
            {
                case Shop1A _:
                    return new HtmlParser1A();
                case Shop220 _:
                    return new HtmlParser220();
                case null:
                    throw new ArgumentNullException();
                default:
                    throw new UnknownShopException();
                    
            }
        }
    }
}
