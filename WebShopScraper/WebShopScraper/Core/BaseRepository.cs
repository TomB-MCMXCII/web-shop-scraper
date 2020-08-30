using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Core
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal IDbContext _context;
        internal DbSet<TEntity> _dbSet;
        public BaseRepository(IDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        
        public void Create()
        {
            //_dbSet.Add()
        }
        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void DeleteProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> GetProducts()
        {
            throw new NotImplementedException();
        }

        public void SaveProducts(IEnumerable<TEntity> products)
        {
            _dbSet.AddRange(products);
            _context.SaveChanges();
        }

        public void UpdateProduct()
        {
            throw new NotImplementedException();
        }

        public void UpdateProducts()
        {
            throw new NotImplementedException();
        }
    }
}
