using System;
using WebShopScraper.Core.Models;
using WebShopScraper.Core.Models._220;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public static class HtmlParserFactory
    {
        public static IHtmlParser<TEntity> CreateInstance<TEntity>(IShop shop) where TEntity : Product, new()
        {
            switch (shop)
            {
                case Shop1A _:
                    return new HtmlParser1A<TEntity>();
                case Shop220 _:
                    return new HtmlParser220<TEntity>();
                case null:
                    throw new ArgumentNullException();
                default:
                    throw new UnknownShopException();
                    
            }
        }
    }
}
