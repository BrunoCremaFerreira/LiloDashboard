using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LiloDash.Infra.IOC;

namespace LiloDash.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers();
            
            services
                .AddSwagger()
                .RegisterServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.
                UseSwaggerAndSetConfig().
                UseHttpsRedirection().
                UseRouting().
                UseAuthorization().
                UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
