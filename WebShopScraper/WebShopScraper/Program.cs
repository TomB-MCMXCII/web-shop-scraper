using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

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

            var host = Host.CreateDefaultBuilder()
                 .ConfigureServices((context, services) =>
                 {

                 })
                 .UseSerilog()
                 .Build();

            var controller = ActivatorUtilities.CreateInstance<Controller>(host.Services);
        }
    }
}
