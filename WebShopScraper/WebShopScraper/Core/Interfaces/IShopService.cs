using System.Collections.Generic;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public interface IScraper
    {
        void ScrapeShops<TEntity>(List<IShop> shops) where TEntity : Product, new();
    }
}