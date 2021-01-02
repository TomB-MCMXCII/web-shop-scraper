using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebShopScraper.Core.Models;

namespace WebShopScraper
{
    public class WebShopScraperDbContext: DbContext, IDbContext
    {
        public DbSet<Product> Products { get; set; }

        public WebShopScraperDbContext(DbContextOptions<WebShopScraperDbContext> options ) : base(options)
        {

        }

    }
}
