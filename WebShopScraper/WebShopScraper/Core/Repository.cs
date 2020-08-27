using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class Repository : IRepository
    {
        private readonly IDataAccess _dataAccess;
        public Repository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void SaveProducts(IEnumerable<Product> products)
        {
            _dataAccess.Add(products);
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public void Update()
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
