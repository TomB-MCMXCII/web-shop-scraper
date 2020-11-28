using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper.Core
{
    public class ProductProcessor : IProductProcessor
    {

        private readonly IProductDataProvider _productDataProvider;
        private readonly IServiceProvider _serviceProvider;
        private IEnumerable<IShop> _Shops;
        private static bool nextPage = true;
        public ProductProcessor(IProductDataProvider productDataProvider, IServiceProvider serviceProvider)
        {
            _productDataProvider = productDataProvider;
            _serviceProvider = serviceProvider;
        }

        public IProductProcessor SetShops(IEnumerable<IShop> shops)
        {
            _Shops = shops;
            return this;
        }

        public void Scrape<TEntity>() where TEntity : Product, new()
        {
            IProductService<TEntity> _productService = (IProductService<TEntity>)_serviceProvider.GetService(typeof(IProductService<TEntity>));
            nextPage = true;
            var parsedProducts = new List<TEntity>();
            foreach (var shop in _Shops)
            {
                var pageNumber = 0;
                var p = new BaseParser();
                p.Stop += ScrapeNextPage;

                while(nextPage)
                {
                    pageNumber++;
                    var productData = _productDataProvider.GetProductData<TEntity>(shop, pageNumber);
                    var parser = ShopProductParserFactory.GetShopParserInstance<TEntity>(shop);
                    var productsList = parser.ParseHtmlStringToProducts<TEntity>(productData);

                    if (productsList.Count == 0)
                    {
                        ScrapeNextPage(this, EventArgs.Empty);
                    }
                    else
                    {
                        parsedProducts.AddRange(productsList);
                    }
                }
            }

            _productService.SaveProducts(parsedProducts);
        }
        private static void ScrapeNextPage(object sender, EventArgs e)
        {
            nextPage = false;
        }


    }
}
