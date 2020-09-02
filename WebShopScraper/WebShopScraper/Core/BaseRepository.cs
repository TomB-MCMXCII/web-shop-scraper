using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Core
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Product
    {
        internal IDbContext _context;
        internal DbSet<TEntity> _dbSet;
        public BaseRepository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public void Create(IEnumerable<TEntity> products)
        {
            foreach(var p in products)
            {
                _dbSet.Add(p);
            }            
            _context.SaveChanges();
        }
        public void Read(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public TEntity ReadByName(string name)
        {
            var product = _dbSet.Where(x => x.Name == name).FirstOrDefault();
            return product;
        }

        public void Read()
        {
            throw new NotImplementedException();
        }
    }
}
