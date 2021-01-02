using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using RestSharp;
using System.IO;
using Microsoft.EntityFrameworkCore;
using WebShopScraper.Core;
using WebShopScraper.Models;
using WebShopScraper.Core.Models;
using System.Threading.Tasks;

namespace WebShopScraper
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var host = CreateHostBuilder(args)
                .Build();
            
            var scraper = ActivatorUtilities.CreateInstance<Scraper>(host.Services);
            await scraper.Start();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                //ervices.AddHostedService<Scraper>();
                
                services.AddDbContext<WebShopScraperDbContext>(options => options.UseSqlServer(hostContext.Configuration.GetConnectionString("local")));
                services.AddScoped<IWebClient, WebClient>();
                services.AddHttpClient();
                services.AddScoped<IProductProcessor, ProductProcessor>();
                services.AddScoped<IProductDataProvider, ProductDataProvider>();
                services.AddScoped(typeof(IProductComparer<>), typeof(ProductComparer<>));
                services.AddScoped<IShopCreator, ShopCreator>();

                services.AddScoped(typeof(IProductService<>), typeof(ProductService<>));
                services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
                services.AddScoped<IDbContext, WebShopScraperDbContext>();
            })
            .ConfigureAppConfiguration(x => x.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables());
    }
}
