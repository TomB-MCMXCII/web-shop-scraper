﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Core.Models
{
    public class Product 
    {
        public Product()
        {

        }
        public decimal AvgPrice { get; set; }
        public decimal HighPrice { get; set; }
        public decimal LowPrice { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Shop { get; set; }
        public decimal TotalSum { get; set; }
        public int TimesAdded { get; set; }
        public int Id { get; set; }
        public string Url { get; set; }
        public decimal HighLowPriceDiff { get; set; }
        public DateTime HighPriceDate { get; set; }
        public DateTime LowPriceDate { get; set; }
        public int Category { get; set; }
    }
}
