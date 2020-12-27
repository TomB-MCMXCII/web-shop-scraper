using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Core
{
    public interface IProductComparer<TEntity> where TEntity : Product
    {
        (IEnumerable<TEntity> productsToUpdate, IEnumerable<TEntity> productsToCreate) CompareProducts(IEnumerable<TEntity> products);
    }
}