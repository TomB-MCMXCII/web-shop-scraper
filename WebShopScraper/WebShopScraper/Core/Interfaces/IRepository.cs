using System.Collections;
using System.Collections.Generic;

namespace WebShopScraper
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void SaveProducts(IEnumerable<TEntity> products);
        void DeleteProducts();
        void DeleteProduct();
        void UpdateProducts();
        void UpdateProduct();
        IEnumerable<IProduct> GetProducts();
        void CheckHighestPrice();
        void CheckLowestPrice();
        void CheckAvgPrice();
    }
}