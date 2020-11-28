using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Core
{
    public interface IProductComparer<TEntity> where TEntity : Product
    {
        (List<TEntity> productsToUpdate, List<TEntity> productsToCreate) CompareProducts(IEnumerable<TEntity> products);
    }
}