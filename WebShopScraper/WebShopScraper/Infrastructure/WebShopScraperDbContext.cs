using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebShopScraper
{
    public class WebShopScraperDbContext: DbContext, IDbAccess
    {
        public DbSet<Product> Products { get; set; }
        public WebShopScraperDbContext(DbContextOptions options) : base(options)
        {

        }
        
    }
}
