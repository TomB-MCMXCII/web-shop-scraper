using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShopScraper.Api.Models;
using WebShopScraper.Core.Models;

namespace WebShopScraper.Api.Repository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly IDbContext _context;

        public StatisticsRepository(IDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TimesAddedStatisticsItem> GetAddedCountData()
        {
            var cpus220 = GetGetShop220AddedCount();
            var cpus1a = GetShop1AAddedCount();
            return new List<TimesAddedStatisticsItem>
            {
                cpus1a,
                cpus220
            };
        }

        private TimesAddedStatisticsItem GetShop1AAddedCount()
        {
            var cpus = _context.Cpus.Where(x => x.Shop == ShopName.Shop1A);
            var scooters = _context.ElectricScooters.Where(x => x.Shop == ShopName.Shop1A);

            return new TimesAddedStatisticsItem
            {
                ShopId = (int)cpus.First().Shop,
                TimesAddedSum = cpus.Sum(x => x.TimesAdded) + scooters.Sum(x => x.TimesAdded),
                CategoryId = (int)ProductCategory.Cpu,
                ShopName = ShopName.Shop1A.ToString()
            };
        }

        private TimesAddedStatisticsItem GetGetShop220AddedCount()
        {
            var cpus = _context.Cpus.Where(x => x.Shop == ShopName.Shop220);
            var scooters = _context.ElectricScooters.Where(x => x.Shop == ShopName.Shop220);

            return new TimesAddedStatisticsItem
            {
                ShopId = (int)cpus.First().Shop,
                TimesAddedSum = cpus.Sum(x => x.TimesAdded) + scooters.Sum(x => x.TimesAdded),
                CategoryId = (int)ProductCategory.Cpu,
                ShopName = ShopName.Shop220.ToString()
            };
        }
    }
}
