using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper.WebApi
{
    public interface IProductProcessor<TEntity> where TEntity : Product
    {
        IEnumerable<TEntity> GetLargestPriceDifferenceProducts();
        IEnumerable<TEntity> GetProducts();
    }
}