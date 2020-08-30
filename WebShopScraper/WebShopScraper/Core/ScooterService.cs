using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Core
{
    public class ProductService<TEntity> : IProductService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public ProductService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public void SaveProducts(IEnumerable<TEntity> products)
        {
            _repository.SaveProducts(products);
        }

        public void SetAvgPrice()
        {
            throw new NotImplementedException();
        }

        public void SetHighPrice()
        {
            throw new NotImplementedException();
        }

        public void SetLowPrice()
        {
            throw new NotImplementedException();
        }
    }
}
