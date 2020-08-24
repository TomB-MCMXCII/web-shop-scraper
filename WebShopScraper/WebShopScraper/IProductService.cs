using System.Collections;

namespace WebShopScraper
{
    public interface IProductService
    {
        void AddProducts(IEnumerable products);
        void GetProducts();
    }
}