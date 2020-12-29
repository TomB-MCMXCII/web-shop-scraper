using System.Collections.Generic;
using System.Threading.Tasks;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Core
{
    public interface IProductService<TEntity> where TEntity : Product
    {
        Task SaveProducts(IEnumerable<TEntity> products);
        Task<IEnumerable<TEntity>> GetProducts();
    }
}