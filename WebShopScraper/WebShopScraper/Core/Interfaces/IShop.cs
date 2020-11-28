using System;
using System.Collections.Generic;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Models
{
    public interface IShop
    {
        Uri BaseUrl { get; set; }
        List<Category> Categories { get; set; }
        ShopName ShopName { get; }

    }
}
