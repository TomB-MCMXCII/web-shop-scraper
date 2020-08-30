using System.Collections;
using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper
{
    public interface IRepository<TEntity> where TEntity : Product
    {
        void Create(TEntity entity);
        void Read(TEntity entity);
        TEntity ReadByName(string name);
        void Read();
        void Update(TEntity entity);
        void Delete();
    }
}