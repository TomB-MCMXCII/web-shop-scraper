using System.Collections.Generic;
using WebShopScraper.Api.Models;

namespace WebShopScraper.Api.Interfaces
{
    public interface IStatisticsService
    {
        IEnumerable<TimesAddedStatisticsItem> GetShopPriceChangeData();
    }
}