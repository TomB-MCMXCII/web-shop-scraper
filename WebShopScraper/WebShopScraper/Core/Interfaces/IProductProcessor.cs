using System.Collections.Generic;
using System.Threading.Tasks;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public interface IProductProcessor
    {
        Task Scrape<T>() where T : Product, new();
        IProductProcessor SetShops(IEnumerable<IShop> shops);
    }
}