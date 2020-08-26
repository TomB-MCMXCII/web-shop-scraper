using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class DbService : IRepositoryService
    {
        private readonly IWebShopScraperDbContext _context;
        public DbService(IWebShopScraperDbContext context)
        {
            _context = context;
        }

        public void Add(IEnumerable<Product> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
        public void GetByName()
        {
            throw new NotImplementedException();
        }
    }
}
