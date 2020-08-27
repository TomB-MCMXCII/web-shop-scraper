using System.Collections;
using System.Collections.Generic;

namespace WebShopScraper
{
    public interface IRepository
    {
        void SaveProducts(IEnumerable<Product> products);
        void DeleteProducts();
        void DeleteProduct();
        void UpdateProducts();
        void UpdateProduct();
        void GetProducts();
        void CheckHighestPrice();
        void CheckLowestPrice();
        void CheckAvgPrice();
    }
}