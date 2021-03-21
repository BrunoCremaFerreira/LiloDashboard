using LiloDash.Domain.Core.Bus;
using LiloDash.Infra.Data.Repository;
using LiloDash.Application.Interfaces.Services;
using MediatR;
using LiloDash.Domain.Interfaces;
using LiloDash.Domain.Interfaces.Repository.Data;
using LiloDash.Infra.Data.UOW;
using Microsoft.Extensions.DependencyInjection;
using LiloDash.Infra.Data.Context;
using LiloDash.Application.Services.User;
using LiloDash.Infra.Bus;
using System;
using LiloDash.Application.AutoMapper;

namespace LiloDash.Infra.IOC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {

            var assembly = AppDomain.CurrentDomain.Load("LiloDash.Domain");
            var config = AutoMapperConfig.RegisterMappings();
            
            return services
                //Domain Bus (Mediator)
                .AddScoped<IMediatorHandler, InMemoryBus>()
                .AddMediatR(assembly)
            
                //Application Services
                .AddScoped<IBuildingAppService, BuildingAppService>()
            
                //Infra - Data
                .AddScoped<IBuildingRepository, BuildingRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<LiloDataContext>()
                
                //AutoMapper
                .AddSingleton(config.CreateMapper());

        }
    }
}