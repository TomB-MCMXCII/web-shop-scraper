using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;
        public ProductService(IRepository repository)
        {
            _repository = repository;
        }
        public void AddProducts(IEnumerable<Product> products)
        {
            _repository.Add(products);
        }
        public void GetProducts()
        {

        }
    }
}
