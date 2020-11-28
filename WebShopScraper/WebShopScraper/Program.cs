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

namespace WebShopScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            BuildConfig(configBuilder);

            var host = CreateHostBuilder(args)
                .Build();
          
            var scraper = ActivatorUtilities.CreateInstance<Scraper>(host.Services);
            scraper.Build().Start();
        }
        //Method with this exact signature is called when adding new migration. Had erros when adding new migration
        public static IHostBuilder CreateHostBuilder(string[] args) 
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<WebShopScraperDbContext>(options => options.UseSqlServer(hostContext.Configuration.GetConnectionString("azure")));
                    services.AddScoped<IWebClient, WebClient>();
                    services.AddHttpClient();
                    services.AddScoped<IProductProcessor, ProductProcessor>();
                    services.AddScoped<IProductDataProvider, ProductDataProvider>();
                    services.AddScoped(typeof(IProductComparer<>), typeof(ProductComparer<>));
                    services.AddScoped<IShopCreator, ShopCreator>();
                    services.AddScoped<IScraper, Scraper>();
                    services.AddScoped(typeof(IProductService<>), typeof(ProductService<>));
                    services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
                    services.AddScoped<IDbContext, WebShopScraperDbContext>();
                });

            return host;
        }
        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                .AddEnvironmentVariables();
        }
    }
}
