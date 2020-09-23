using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;

namespace WebShopScraper.WebApi
{
    public class ProductProcessor<TEntity> where TEntity : Product
    {
        private readonly IProductService<TEntity> _productService;
        public ProductProcessor(IProductService<TEntity> productService)
        {
            _productService = productService;
        }
        public void GetProducts()
        {
            _productService.GetProducts();
        }
        public void GetLargestPriceDifferenceProducts()
        {
            GetProducts();
        }

    }
}
