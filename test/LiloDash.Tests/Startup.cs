using System;
using Xunit;

namespace LiloDash.Domain.Tests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

        }

        private IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
