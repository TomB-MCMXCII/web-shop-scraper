using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebShopScraper
{
    public interface IWebShopScraperDbContext
    {
        DbSet<Product> Products { get; set; }
        public int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
