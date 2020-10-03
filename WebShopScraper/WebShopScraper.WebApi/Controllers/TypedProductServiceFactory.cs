using System;
using System.Collections.Generic;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;

namespace WebShopScraper.WebApi.Controllers
{
    public class TypedProductServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public TypedProductServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void GetCpuService<TEntity>() where TEntity :  Product, new()
        {
            IProductService<TEntity> _productService = (IProductService<TEntity>)
                _serviceProvider.GetService(typeof(IProductService<TEntity>));
            var products = _productService.GetProducts();

        }
      
    }
}