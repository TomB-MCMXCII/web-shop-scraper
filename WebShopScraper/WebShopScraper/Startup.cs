using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using System.Net.Http;

namespace WebShopScraper
{
    public class Startup
    {
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
