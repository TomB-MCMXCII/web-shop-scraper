using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;

namespace WebShopScraper.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //private readonly IProductService _productService; 
        public ProductController(IProductProcessor productProcessor)
        {

        }
        /// <summary>
        /// Returns all product of given type
        /// </summary>
        /// <param name="productType">The type of product</param>
        [HttpGet]
        [Route("")]
        public void GetProducts(ProductType productType)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="count">The count indicates how many products to return</param>
        /// <param name="productType">The type of product</param>
        [HttpGet]
        [Route("")]
        public void GetLargestPriceDifferenceProducts(int count,ProductType productType)
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="productType"></param>
        [HttpGet]
        [Route("")]
        public void GetTodaysPriceChanges(ProductType productType)
        {

        }
    }
}
