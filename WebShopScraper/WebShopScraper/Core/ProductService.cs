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

        public TEntity ComparePrice(TEntity product, TEntity newProduct)
        {
            throw new NotImplementedException();
        }

        public ServiceResult ProductExists(TEntity product)
        {
            throw new NotImplementedException();
        }

        public void SaveProducts(IEnumerable<TEntity> products)
        {
            _repository.Create(products);
        }

        //public void SaveProducts(IEnumerable<TEntity> products)
        //{
        //    foreach(var newProduct in products)
        //    {
        //        var oldProduct = ProductExists(newProduct);
        //        if(oldProduct!= null)
        //        {
        //            var toUpdate = ComparePrice(oldProduct,newProduct);

        //            _repository.Update(toUpdate);                   
        //        }
        //        else
        //        {
        //            newProduct.TimesAdded++;
        //            newProduct.TotalSum = newProduct.Price;
        //            newProduct.HighPrice = newProduct.Price;
        //            newProduct.LowPrice = newProduct.Price;
        //            _repository.Create(newProduct);
        //        }
        //    }  
        //}

        //public ServiceResult ProductExists(TEntity product)
        //{
        //    var product1 = _repository.ReadByName(product.Name);
        //    if(product1 != null && product.Shop == product1.Shop)
        //    {
        //        return product1;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        //public TEntity ComparePrice(TEntity foundProduct, TEntity newProduct)
        //{
        //    var relativeValue = decimal.Compare(foundProduct.Price, newProduct.Price);

        //    if (relativeValue < 0)
        //    {
        //        foundProduct.TotalSum += newProduct.Price;
        //        foundProduct.TimesAdded++;
        //        foundProduct.HighPrice = newProduct.Price;
        //        foundProduct.Price = newProduct.Price;
        //        foundProduct.AvgPrice = foundProduct.TotalSum / foundProduct.TimesAdded;
        //        return foundProduct;
        //    }
        //    if (relativeValue > 0)
        //    {
        //        foundProduct.TotalSum += newProduct.Price;
        //        foundProduct.TimesAdded++;
        //        foundProduct.LowPrice = newProduct.Price;
        //        foundProduct.Price = newProduct.Price;
        //        foundProduct.AvgPrice = foundProduct.TotalSum / foundProduct.TimesAdded;
        //        return foundProduct;
        //    }
        //    else
        //    {
        //        return foundProduct;
        //    }

        //}
    }
}
