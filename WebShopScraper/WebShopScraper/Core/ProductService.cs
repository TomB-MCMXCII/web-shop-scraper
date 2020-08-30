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
            foreach(var p in products)
            {
                var product = ProductExists(p);
                if(product!= null)
                {
                    SetHighPrice(product);
                }
                else
                {
                    _repository.Create(products);
                }
            }
            
        }

        public void SetAvgPrice(TEntity product)
        {
            throw new NotImplementedException();
        }

        public void SetHighPrice(TEntity product)
        {
            
        }

        public void SetLowPrice(TEntity product)
        {
            throw new NotImplementedException();
        }
        public TEntity ProductExists(TEntity product)
        {
            var product1 = _repository.ReadByName(product.Name);
            if(product1 != null && product.Shop == product1.Shop)
            {
                return product1;
            }
            else
            {
                return null;
            }
        }
    }
}
