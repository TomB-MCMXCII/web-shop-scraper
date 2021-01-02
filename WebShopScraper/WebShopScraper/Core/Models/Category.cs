using System;
using System.Collections.Generic;
using System.Text;
using WebShopScraper.Core.Enums;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Models
{
    public class Category
    {
        public ProductCategory ProductCategory { get; set; }
        public string Path { get; set; }
    }
}
