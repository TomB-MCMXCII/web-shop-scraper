using System.Collections.Generic;

namespace WebShopScraper.Core
{
    public interface IScooterService
    {
        void SaveProducts(IEnumerable<ElectricScooter> products);
    }
}