using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebShopScraper
{
    // add IDesignTimeDbContextFactory<WebShopScraperDbContext> if you wish to run add-migration or other commands
    public class WebShopScraperDbContextFactory
    {
        public WebShopScraperDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WebShopScraperDbContext>();
            optionsBuilder.UseSqlServer("Server =.\\SQLEXPRESS; Database = Scraper; Trusted_Connection = True;");

            return new WebShopScraperDbContext(optionsBuilder.Options);
        }
    }
}
