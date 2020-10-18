using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using RestSharp;
using System.IO;
using Microsoft.EntityFrameworkCore;
using WebShopScraper.Core;

namespace WebShopScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);
            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Build())
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();

            var host = CreateHostBuilder(args)
                .UseSerilog()
                .Build();
          
            var controller = ActivatorUtilities.CreateInstance<Application>(host.Services);
            controller.StartApplication();
        }
        //Method with this exact signature is called when adding new migration
        public static IHostBuilder CreateHostBuilder(string[] args) 
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddDbContext<WebShopScraperDbContext>(options =>
                        options.UseSqlServer("Server=tcp:scrapertomb.database.windows.net,1433;Initial Catalog=Scraper;Persist Security Info=False;User ID=tomb;Password=pendulum08!@#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
                    services.AddTransient<IWebClient, WebClient>();
                    services.AddHttpClient();
                    services.AddScoped<IShopService, ShopService>();
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
