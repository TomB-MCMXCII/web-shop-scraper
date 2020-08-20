using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Models
{
    public interface IShop
    {
        void SetBaseUrl();
        void SetCategories();
    }
}
