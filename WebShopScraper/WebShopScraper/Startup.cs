using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;

namespace WebShopScraper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private IConfiguration Configuration { get; }
        public void Configure()
        {
            var builder = new ConfigurationBuilder();

            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(builder.Build())
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateLogger();

            var host = Host.CreateDefaultBuilder()
                 .ConfigureServices((context, services) =>
                 {
                     services.AddDbContext<WebShopScraperDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("myconn")));
                     services.AddScoped<IWebClient, WebClient>();
                     services.AddHttpClient();
                     services.AddScoped<IShopService, ShopService>();
                 })
                 .UseSerilog()
                 .Build();

            var controller = ActivatorUtilities.CreateInstance<Controller>(host.Services);
            controller.StartApplication();

        }
    }
}
