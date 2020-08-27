using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class Repository : IRepository
    {
        private readonly IDbContext _context;
        public Repository(IDbContext context)
        {
            _context = context;
        }
        public void SaveProducts(IEnumerable<Product> products)
        {
            _context.Products.AddRange(products);
            _context.SaveChanges();
        }
        public void DeleteProducts()
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void UpdateProducts()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct()
        {
            throw new NotImplementedException();
        }

        public void GetProducts()
        {
            throw new NotImplementedException();
        }
        public void CheckAvgPrice()
        {
            throw new NotImplementedException();
        }

        public void CheckHighestPrice()
        {
            throw new NotImplementedException();
        }

        public void CheckLowestPrice()
        {
            throw new NotImplementedException();
        }

        
    }
}
