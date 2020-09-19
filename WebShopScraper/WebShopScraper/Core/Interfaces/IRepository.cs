using System.Collections;
using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper
{
    public interface IRepository<TEntity>
    {
        void Create(IEnumerable<TEntity> entity);
        void Read(TEntity entity);
        TEntity ReadByName(string name);
        IEnumerable<TEntity> Read();
        void Update(IEnumerable<TEntity> entity);
        void Delete();
    }
}