using System;
using System.IO;
using LiloDash.API.Controllers;
using LiloDash.Infra.Data.Context;
using LiloDash.Infra.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LiloDash.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddScoped<BuildingController>()
                .AddScoped<ControllerContext>()
                .AddScoped<DefaultHttpContext>()
                .RegisterServicesTestProjects(GetInMemoryDatabaseOptions())
                .AddSingleton(LoadConfiguration());
                
        }

        private IConfiguration LoadConfiguration()
            => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

        private DbContextOptions GetInMemoryDatabaseOptions()
        {
            var builder = new DbContextOptionsBuilder<LiloDataContext>();
            builder.UseInMemoryDatabase(databaseName: "TestContext");
            return builder.Options;
        }
    }
}
