using WebShopScraper.Api.Models;

namespace WebShopScraper.Api.Interfaces
{
    public interface IStatisticsService
    {
        ShopPriceChangeDto GetShopPriceChangeData();
    }
}