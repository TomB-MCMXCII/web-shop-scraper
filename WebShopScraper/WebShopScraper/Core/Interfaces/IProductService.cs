using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Core
{
    public interface IProductService<TEntity> where TEntity : Product
    {
        void SaveProducts(IEnumerable<TEntity> products);
        public TEntity ComparePrice(TEntity product, TEntity newProduct);
        ServiceResult ProductExists(TEntity product);
    }
}