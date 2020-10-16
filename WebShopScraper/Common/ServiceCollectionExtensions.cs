using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebShopScraper;
using WebShopScraper.Core;

namespace Common
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebShopScraperDbContext>(options =>
                        options.UseSqlServer("Server =.\\SQLEXPRESS; Database = Scraper; Trusted_Connection = True;"));
            services.AddTransient<IWebClient, WebClient>();
            services.AddHttpClient();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped(typeof(IProductService<>), typeof(ProductService<>));
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IDbContext, WebShopScraperDbContext>();
        }
    }
}
