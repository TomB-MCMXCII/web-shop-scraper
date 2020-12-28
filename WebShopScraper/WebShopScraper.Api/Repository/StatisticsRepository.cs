using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void GetAddedCountData()
        {
            var cpus220 = GetGetShop220CpuAddedCount();
            var cpus1a = GetShop1ACpuAddedCount();
        }

        private int GetShop1ACpuAddedCount()
        {
            var timesAddedSum = _context.Cpus.Where(x => x.Shop == ShopName.Shop1A).Sum(x => x.TimesAdded);
            return timesAddedSum;
        }

        private int GetGetShop220CpuAddedCount()
        {
            var timesAddedSum = _context.Cpus.Where(x => x.Shop == ShopName.Shop220).Sum(x => x.TimesAdded);
            return timesAddedSum;
        }
    }
}
