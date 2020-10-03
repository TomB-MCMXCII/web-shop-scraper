using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            _dbSet.AddRange(products);       
            _context.SaveChanges();
        }
        public void Read(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IEnumerable<TEntity> entity)
        {
            _dbSet.UpdateRange(entity);
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

        public IEnumerable<TEntity> Read()
        {
            var dbset = _dbSet.ToList();

            return dbset;
        }

        //public IEnumerable<TEntity> Read()
        //{
        //    _dbSet.
        //}
    }
}
