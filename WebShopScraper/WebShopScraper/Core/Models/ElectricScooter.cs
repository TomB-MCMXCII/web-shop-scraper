using System;
using System.Collections.Generic;
using System.Text;
using WebShopScraper.Core.Models;

namespace WebShopScraper
{
    public class ElectricScooter : BaseProduct 
    {
        public int Id { get; set; }
       
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
