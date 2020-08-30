using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class ElectricScooter
    {
        public int Id { get; set; }
        public decimal AvgPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ShopName Shop { get; set; }
    }

    public enum ProductCategory
    {
        ElectricScooter,
    }
    public enum ShopName
    {
        Shop1A,
        Shop220,
        ShopRDElectronics
    }
}
