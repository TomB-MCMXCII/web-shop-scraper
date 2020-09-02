using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebShopScraper
{
    public class WebShopScraperDbContext: DbContext, IDbContext
    {
        public DbSet<ElectricScooter> ElectricScooters { get; set; }
        public DbSet<Cpu> Cpus { get; set; }

        public WebShopScraperDbContext(DbContextOptions<WebShopScraperDbContext> options ) : base(options)
        {

        }

    }
}
