using System.Collections;
using System.Collections.Generic;

namespace WebShopScraper
{
    public interface IRepository
    {
        void SaveProducts(IEnumerable<Product> products);
        void Delete();
        void Update();
        void CheckHighestPrice();
        void CheckLowestPrice();
        void CheckAvgPrice();
    }
}