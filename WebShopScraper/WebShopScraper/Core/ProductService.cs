using System.Collections.Generic;
using WebShopScraper.Core.Models;
using System;

namespace WebShopScraper.Core
{
    public class ProductService<TEntity> : IProductService<TEntity> where TEntity : Product
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IProductComparer<TEntity> _productComparer;

        public ProductService(IRepository<TEntity> repository, IProductComparer<TEntity> productComparer)
        {
            _repository = repository;
            _productComparer = productComparer;
        }

        public IEnumerable<TEntity> GetProducts()
        {
            return _repository.Read();
        }

        public void SaveProducts(IEnumerable<TEntity> products)
        {
            var comparedProducts = _productComparer.CompareProducts(products);

            _repository.Create(comparedProducts.productsToCreate);
            _repository.Update(comparedProducts.productsToUpdate);

        }
    }
}
