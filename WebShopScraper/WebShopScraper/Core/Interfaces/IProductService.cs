using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Core
{
    public interface IProductService<TEntity> where TEntity : Product
    {
        void SaveProducts(IEnumerable<TEntity> products);
        public void SetHighPrice(TEntity product);
        public void SetLowPrice(TEntity product);
        public void SetAvgPrice(TEntity product);
        TEntity ProductExists(TEntity product);
    }
}