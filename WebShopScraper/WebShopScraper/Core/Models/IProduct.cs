using WebShopScraper.Core.Models;

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
        int Shop { get; set; }
        public decimal TotalSum { get; set; }
        public int TimesAdded { get; set; }
    }
}