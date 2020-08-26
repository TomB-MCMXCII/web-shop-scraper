using System.Collections.Generic;

namespace WebShopScraper
{
    public interface IRepositoryService
    {
        void Add(IEnumerable<Product> products);
        void Delete();
        void Update();
        void GetByName();
    }
}