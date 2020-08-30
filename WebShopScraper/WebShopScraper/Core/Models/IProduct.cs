namespace WebShopScraper
{
    public interface IProduct
    {
        public int Id { get; set; }
        decimal AvgPrice { get; set; }
        decimal HighPrice { get; set; }
        decimal LowPrice { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
        ShopName Shop { get; set; }
    }
}