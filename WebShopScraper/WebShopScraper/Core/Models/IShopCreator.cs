using System.Collections;
using System.Collections.Generic;

namespace WebShopScraper.Models
{
    public interface IShopCreator
    {
        IEnumerable<IShop> CreateShops();
    }
}