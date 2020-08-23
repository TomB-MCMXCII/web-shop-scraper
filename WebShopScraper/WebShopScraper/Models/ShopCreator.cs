namespace WebShopScraper.Models
{
    public abstract class ShopCreator
    {
        public IShop Shop { get; set; }
        public abstract IShop CreateInstance();
       
        public void Create()
        {
            var shop = CreateInstance();
            Shop = shop;
            shop.SetBaseUrl();
            shop.SetCategories();
        }
        
    }
}
