using System;
using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Core
{
    public class ProductComparer<TEntity> : IProductComparer<TEntity> where TEntity : Product
    {
        private readonly IRepository<TEntity> _repository;
        List<TEntity> productsToUpdate = new List<TEntity>();
        List<TEntity> productsToCreate = new List<TEntity>();

        public ProductComparer(IRepository<TEntity> repository)
        {
            productsToUpdate = new List<TEntity>();
            productsToCreate = new List<TEntity>();
            _repository = repository;
        }

        public (List<TEntity> productsToUpdate, List<TEntity> productsToCreate) CompareProducts(IEnumerable<TEntity> products)
        {
            foreach (var p in products)
            {
                var product = _repository.ReadByName(p.Name);
                if (product != null)
                {
                    // todo add tests for new properties. create helper class to change properties
                    if (product.LowPrice > p.Price)
                    {
                        product.LowPrice = p.Price;
                        product.Price = p.Price;
                        product.TotalSum += p.Price;
                        product.TimesAdded += 1;
                        product.AvgPrice = product.TotalSum / product.TimesAdded;
                        product.LowPriceDate = DateTime.Now;
                        product.HighLowPriceDiff = product.HighPrice - product.LowPrice;
                        productsToUpdate.Add(product);
                    }
                    if (product.HighPrice < p.Price)
                    {
                        product.HighPrice = p.Price;
                        product.Price = p.Price;
                        product.TotalSum += p.Price;
                        product.TimesAdded += 1;
                        product.AvgPrice = product.TotalSum / product.TimesAdded;
                        product.HighPriceDate = DateTime.Now;
                        product.HighLowPriceDiff = product.HighPrice - product.LowPrice;
                        productsToUpdate.Add(product);

                    }
                    if (product.Url != p.Url)
                    {
                        product.Url = p.Url;
                        productsToUpdate.Add(product);
                    }
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

            return (productsToUpdate, productsToCreate);
        }
    }
}