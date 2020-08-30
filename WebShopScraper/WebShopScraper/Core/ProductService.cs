using System;
using System.Collections.Generic;
using System.Text;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Core
{
    public class ProductService<TEntity> : IProductService<TEntity> where TEntity : Product
    {
        private readonly IRepository<TEntity> _repository;

        public ProductService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public void SaveProducts(IEnumerable<TEntity> products)
        {
            _repository.Create(products);
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
        public bool ProductExists(TEntity product)
        {
            var product1 = _repository.ReadByName(product.Name);
            if(product1 != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
