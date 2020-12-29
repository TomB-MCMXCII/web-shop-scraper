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
            await host.StartAsync();
            await host.StopAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Scraper>();
                
                services.AddDbContext<WebShopScraperDbContext>(options => options.UseSqlServer(hostContext.Configuration.GetConnectionString("azure")));
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
