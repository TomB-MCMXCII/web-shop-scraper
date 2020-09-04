using WebShopScraper.Core.Models;

namespace WebShopScraper.Core
{
    public class ServiceResult
    {
        public bool Result { get; }
        public Product Product { get; }
        public ServiceResult()
        {

        }
        public ServiceResult(bool result)
        {
            Result = result;
        }
        public ServiceResult(bool result,Product product)
        {
            Result = result;
            Product = product;
        }
        public ServiceResult(Product product)
        {
            Product = product;
        }
    }
}