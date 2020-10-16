using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public class ShopService : IShopService 
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IServiceProvider _serviceProvider;
        public ShopService(IServiceProvider serviceProvider,IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _serviceProvider = serviceProvider;
        }
        public void ScrapeShops<TEntity>(List<IShop> shops) where TEntity : Product, new()
        {
            // todo test if this is disposed
            IProductService<TEntity> _productService = (IProductService<TEntity>)_serviceProvider.GetService(typeof(IProductService<TEntity>));

            var products = new List<TEntity>();
            foreach (var a in shops)
            {
                //todo put url setting in web client class.
                var _client = new WebClient(_httpClientFactory);
                _client.SetBaseUri(a.BaseUrl);
                
                switch (typeof(TEntity))
                {
                    case var cls when cls == typeof(ElectricScooter):
                        _client.SetPath(a.Categories.Where(x => x.ProductCategory == ProductCategory.ElectricScooter).FirstOrDefault().Path);
                        break;
                    case var cls when cls == typeof(Cpu):
                        _client.SetPath(a.Categories.Where(x => x.ProductCategory == ProductCategory.Cpu).FirstOrDefault().Path);
                        break;
                }

                var pageNumber = 1;
                var nextPage = true;
                while (nextPage)
                {
                    var response = _client.GetPageHtmlContent(pageNumber, a);
                    var parser = HtmlParserFactory.CreateInstance<TEntity>(a);
                    //todo 
                    var parsedProducts = parser.GetProducts(response.Result);

                    if (parsedProducts.Count == 0)
                    {
                        nextPage = false;
                    }
                    else
                    {
                        //todo this is redundant as get products allready returns new list with type TEntity
                        foreach (var c in parsedProducts)
                        {
                            products.Add(new TEntity()
                            {
                                Name = c.Name,
                                Price = c.Price,
                                Shop = c.Shop,
                            });
                        }
                        pageNumber++;
                    }
                }
            }
            _productService.SaveProducts(products);
        }
    }
}
