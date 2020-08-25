using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class Repository : IRepository
    {
        private readonly IDbService _service;
        public Repository(IDbService service)
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
    }
}
