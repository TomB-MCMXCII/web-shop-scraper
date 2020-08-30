using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public TEntity ReadByName(string name)
        {
            var product = _dbSet.Where(x => x.Name == name).FirstOrDefault(null);
            return product;
        }

        public void Read()
        {
            throw new NotImplementedException();
        }
    }
}
