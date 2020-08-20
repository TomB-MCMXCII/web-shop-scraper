using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Models
{
    public abstract class ShopCreator
    {
        public abstract IShop GetShop();
    }
}
