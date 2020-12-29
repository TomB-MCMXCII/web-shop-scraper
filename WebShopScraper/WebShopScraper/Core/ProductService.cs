using System.Collections.Generic;
using WebShopScraper.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<TEntity>> GetProducts()
        {
            return await _repository.Read();
        }

        public async Task SaveProducts(IEnumerable<TEntity> products)
        {
            var (productsToUpdate, productsToCreate) = _productComparer.CompareProducts(products);

            if(productsToCreate.Any())
            {
                await _repository.Create(productsToCreate);
            }
            if(productsToUpdate.Any())
            {
                await _repository.Update(productsToUpdate);
            }
           

        }
    }
}
