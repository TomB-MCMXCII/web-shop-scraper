using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    public class WebShopScraperDbContext: DbContext
    {
        DbSet<Product> Products { get; set; }

        public WebShopScraperDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
