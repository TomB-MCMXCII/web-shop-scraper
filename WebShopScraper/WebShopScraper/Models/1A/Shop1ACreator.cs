using Microsoft.Extensions.Configuration;

namespace WebShopScraper.Models._1A
{
    public class Shop1ACreator : ShopCreator
    {
        private readonly IConfiguration _config;
        public Shop1ACreator(IConfiguration config)
        {
            _config = config;
        }
        public override IShop CreateInstance()
        {
            Shop = new Shop1A(_config);
            return Shop;
        }

       
    }
}
