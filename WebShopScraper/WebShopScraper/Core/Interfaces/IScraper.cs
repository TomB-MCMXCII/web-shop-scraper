using System.Collections.Generic;
using WebShopScraper.Core;
using WebShopScraper.Core.Models;
using WebShopScraper.Models;

namespace WebShopScraper
{
    public interface IScraper
    {
        void Start();
        void Build();
    }
}