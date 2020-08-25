using System.Collections.Generic;

namespace WebShopScraper
{
    public interface IDbService
    {
        void Add(IEnumerable<Product> products);
        void Delete();
        void Update();
    }
}