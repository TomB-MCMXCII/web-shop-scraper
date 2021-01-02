using System.Collections.Generic;
using System.Threading.Tasks;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper.Core
{
    public interface IProductDataProvider
    {
        Task<List<string>> GetProductData<TEntity>(IShop shop, int pageNumber) where TEntity : Product;
    }
}