using System.Collections;
using System.Collections.Generic;

namespace WebShopScraper
{
    public interface IRepository
    {
        void Add(IEnumerable<Product> products);
        void Delete();
        void Update();
        void CheckHighestPrice();
        void CheckLowestPrice();
        void CheckAvgPrice();
    }
}