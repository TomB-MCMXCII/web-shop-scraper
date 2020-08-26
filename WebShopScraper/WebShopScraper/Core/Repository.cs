using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class Repository : IRepository
    {
        private readonly IRepositoryService _service;
        public Repository(IRepositoryService service)
        {
            _service = service;
        }
        public void Add(IEnumerable<Product> products)
        {
            _service.Add(products);
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
