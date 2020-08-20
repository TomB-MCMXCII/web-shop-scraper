namespace WebShopScraper.Models
{
    public abstract class ShopCreator
    {
        
        public abstract IShop CreateInstance();
       
        public void Create()
        {
            CreateInstance();
            
            shop.SetBaseUrl();
            shop.SetCategories();
        }
        
    }
}
