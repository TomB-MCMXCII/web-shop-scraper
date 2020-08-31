using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Core.Models
{
    public abstract class Product
    {
        public Product()
        {

        }
        public decimal AvgPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ShopName Shop { get; set; }
        public decimal TotalSum { get; set; }
        public int TimesAdded { get; set; }
    }
}
