using System.Collections.Generic;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public interface IShopService
    {
        void ScrapeScooters(List<IShop> shops);
        void ScrapeLaptops(List<IShop> shops);
        void ScrapeCpus(List<IShop> shops);
    }
}