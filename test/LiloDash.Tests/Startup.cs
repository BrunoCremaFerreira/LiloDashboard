using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LiloDash.Domain.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

        }

        private IConfiguration LoadConfiguration()
            => new ConfigurationBuilder()
                //.SetBasePath(Directory.GetCurrentDirectory())
                //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
    }
}
