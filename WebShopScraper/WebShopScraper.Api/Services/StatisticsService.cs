using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopScraper.Api.Interfaces;
using WebShopScraper.Api.Models;
using WebShopScraper.Api.Repository;

namespace WebShopScraper.Api.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsService(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public ShopPriceChangeDto GetShopPriceChangeData()
        {
            _statisticsRepository.GetAddedCountData();

            return new ShopPriceChangeDto();
        }
    }
}
