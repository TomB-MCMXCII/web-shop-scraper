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
            var startup = new Startup();
            startup.Configure();
        }
    }
}
