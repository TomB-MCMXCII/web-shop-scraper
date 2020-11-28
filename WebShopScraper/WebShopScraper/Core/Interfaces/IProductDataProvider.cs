using System.Collections.Generic;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper.Core
{
    public interface IProductDataProvider
    {
        string GetProductData<TEntity>(IShop shop, int pageNumber) where TEntity : Product;
    }
}