using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using RestSharp;
using System.IO;

namespace WebShopScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            //BuildConfig(builder);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Build())
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            var host = Host.CreateDefaultBuilder()
                 .ConfigureServices((context, services) =>
                 {
                     services.AddScoped<IRestClient, RestClient>();
                 })
                 .UseSerilog()
                 .Build();

            var controller = ActivatorUtilities.CreateInstance<Controller>(host.Services);
            controller.Run();

            //static void BuildConfig(IConfigurationBuilder builder)
            //{
            //    builder.SetBasePath(Directory.GetCurrentDirectory())
            //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            //        .AddEnvironmentVariables();
            //}
        }
    }
}
