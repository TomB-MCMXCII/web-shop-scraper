using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using RestSharp;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace WebShopScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();

            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Build())
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();

            var host = CreateHostBuilder(args)
                .UseSerilog()
                .Build();
          
            var controller = ActivatorUtilities.CreateInstance<Controller>(host.Services);
            controller.StartApplication();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) 
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<WebShopScraperDbContext>(options =>
                       options.UseSqlServer("Server =.\\SQLEXPRESS; Database = Scraper; Trusted_Connection = True;"));
                    services.AddScoped<IWebClient, WebClient>();
                    services.AddHttpClient();
                    services.AddScoped<IShopService, ShopService>();
                    services.AddScoped<IProductService, ProductService>();
                    services.AddScoped<IRepository, Repository>();
                    services.AddScoped<IWebShopScraperDbContext>(provider => provider.GetService<WebShopScraperDbContext>());
                    services.AddScoped<IRepositoryService, DbService>();
                });

            return host;
        }

    }
}
