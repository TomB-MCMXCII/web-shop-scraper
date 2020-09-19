using System.Collections.Generic;
using WebShopScraper.Core.Models;
using System;

namespace WebShopScraper.Core
{
    public class ProductService<TEntity> : IProductService<TEntity> where TEntity : Product
    {
        private readonly IRepository<TEntity> _repository;

        public ProductService(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public IEnumerable<TEntity> GetProducts()
        {
            _repository.Read();
            return new List<TEntity>();
        }

        public void SaveProducts(IEnumerable<TEntity> products)
        {
            List<TEntity> productsToUpdate = new List<TEntity>();
            List<TEntity> productsToCreate = new List<TEntity>();
           
            foreach(var p in products)
            {
                var product = _repository.ReadByName(p.Name);
                if(product != null)
                {
                    if(product.LowPrice > p.Price)
                    {
                        product.LowPrice = p.Price;
                        product.Price = p.Price;
                        product.TotalSum += p.Price;
                        product.TimesAdded += 1;
                        product.AvgPrice = product.TotalSum / product.TimesAdded;   
                    }
                    if(product.HighPrice < p.Price)
                    {
                        product.HighPrice = p.Price;
                        product.Price = p.Price;
                        product.TotalSum += p.Price;
                        product.TimesAdded += 1;
                        product.AvgPrice = product.TotalSum / product.TimesAdded;
                    }
                    productsToUpdate.Add(product);
                }
                else
                {
                    p.LowPrice = p.Price;
                    p.HighPrice = p.Price;
                    p.TotalSum = p.Price;
                    p.TimesAdded = 1;
                    productsToCreate.Add(p);
                }
            }
            _repository.Create(productsToCreate);
            _repository.Update(productsToUpdate);

        }
    }
}
