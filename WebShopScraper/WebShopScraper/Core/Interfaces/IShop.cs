using System;
using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Models
{
    public interface IShop
    {
        ShopName ShopName { get;}
        Uri BaseUrl { get; set; }
        List<Category> Categories { get; set; }
        void SetBaseUrl();
        void SetCategories();
    }
}
