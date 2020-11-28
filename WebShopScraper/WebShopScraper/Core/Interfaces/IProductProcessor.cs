using System.Collections.Generic;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public interface IProductProcessor
    {
        IProductProcessor Scrape<T>() where T : Product, new();
        IProductProcessor SetShops(IEnumerable<IShop> shops);
    }
}