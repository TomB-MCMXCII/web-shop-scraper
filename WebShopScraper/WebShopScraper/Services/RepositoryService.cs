using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class DataAccess : IDataAccess
    {
        private readonly IDbAccess _dbAccess;
        public DataAccess(IDbAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public void Add(IEnumerable<Product> products)
        {
            _dbAccess.Products.AddRange(products);
            _dbAccess.SaveChanges();
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
