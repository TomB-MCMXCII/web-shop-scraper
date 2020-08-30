using System.Collections.Generic;

namespace WebShopScraper.Core
{
    public interface IProductService<TEntity> where TEntity : class
    {
        void SaveProducts(IEnumerable<TEntity> products);
        public void SetHighPrice();
        public void SetLowPrice();
        public void SetAvgPrice();
    }
}