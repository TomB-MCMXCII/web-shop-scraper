using System.Collections.Generic;
using WebShopScraper.Api.Models;

namespace WebShopScraper.Api.Repository
{
    public interface IStatisticsRepository
    {
        IEnumerable<TimesAddedStatisticsItem> GetAddedCountData();
    }
}