using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebShopScraper.Core.Models;

namespace WebShopScraper
{
    public interface IRepository<TEntity>
    {
        Task Create(IEnumerable<TEntity> entity);
        void Read(TEntity entity);
        TEntity ReadByName(string name);
        Task<IEnumerable<TEntity>> Read();
        Task Update(IEnumerable<TEntity> entity);
        void Delete();
    }
}