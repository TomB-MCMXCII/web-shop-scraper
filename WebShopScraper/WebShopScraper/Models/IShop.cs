using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper.Models
{
    public interface IShop
    {
        Uri BaseUrl { get; set; }
        List<Category> Categories { get; set; }
        void SetBaseUrl();
        void SetCategories();
    }
}
