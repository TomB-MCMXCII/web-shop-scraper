using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class Product
    {
        public int Id { get; set; }
        public ProductType ProductType { get; set; }
        public ShopName Shop { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal LowPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal AvgPrice { get; set; }
    }

    public enum ProductType
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
