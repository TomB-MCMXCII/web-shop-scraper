using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
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
        public async Task Create(IEnumerable<TEntity> products)
        {
            _dbSet.AddRange(products);       
            await _context.SaveChangesAsync(default);
        }
        public void Read(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task Update(IEnumerable<TEntity> entity)
        {
            _dbSet.UpdateRange(entity);
            await _context.SaveChangesAsync(default);
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

        public async Task<IEnumerable<TEntity>> Read()
        {
            var dbset = await _dbSet.ToListAsync();

            return dbset;
        }

        //public IEnumerable<TEntity> Read()
        //{
        //    _dbSet.
        //}
    }
}
