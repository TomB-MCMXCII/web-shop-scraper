using System.Collections;
using System.Collections.Generic;

namespace WebShopScraper
{
    public interface IProductService
    {
        void AddProducts(IEnumerable<Product> products);
        void GetProducts();
    }
}