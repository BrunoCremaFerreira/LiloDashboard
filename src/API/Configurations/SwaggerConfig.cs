using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiloDash.API
{
    /// <summary>
    /// Swagger configuration
    /// </summary>
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            var version = "V" + thisAssembly.GetName().Version.ToString();

            return services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Lilo Dashboard API",
                        Version = "v1",
                        Description = $"(Build Version: {version})"
                    });

                c.AddSecurityDefinition("authToken", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "authToken",
                    Description = "API Authentication Token"
                });
            });
        }

        public static IApplicationBuilder UseSwaggerAndSetConfig(this IApplicationBuilder app)
        {
            return app.UseSwagger().
                UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lilo Dashboard API");
                    c.RoutePrefix = string.Empty;
                    c.SupportedSubmitMethods(SubmitMethod.Get, SubmitMethod.Head, SubmitMethod.Post, SubmitMethod.Delete, SubmitMethod.Put);
                });
        }
    }
}
