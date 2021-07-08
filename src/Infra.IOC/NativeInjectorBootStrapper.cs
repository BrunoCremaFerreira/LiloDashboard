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
using Microsoft.EntityFrameworkCore;
using LiloDash.Infra.Data.Repository.Users;
using Microsoft.AspNetCore.Http;

namespace LiloDash.Infra.IOC
{
    public static class NativeInjectorBootStrapper
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            var config = AutoMapperConfig.RegisterMappings();
            
            return services
                .RegisterMediator()
                .RegisterServiceBroker()

                //Application Services
                .AddScoped<IBuildingAppService, BuildingAppService>()
            
                //Infra - Data
                .AddScoped<IBuildingRepository, BuildingRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<LiloDataContext>()
                
                //AutoMapper
                .AddSingleton(config.CreateMapper());

        }

        public static IServiceCollection RegisterServicesTestProjects(this IServiceCollection services, DbContextOptions contextOptions)
        {
            var config = AutoMapperConfig.RegisterMappings();
            
            return services
                .RegisterMediator()
                .RegisterServiceBroker()

                //Application Services
                .AddScoped<IBuildingAppService, BuildingAppService>()
            
                //Infra - Data
                .AddScoped<IBuildingRepository, BuildingRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(e=> new LiloDataContext
                (
                    new UserLoggedRepository
                    (
                        new HttpContextAccessor
                        {
                            HttpContext = new DefaultHttpContext()
                        }
                    ),
                    contextOptions
                ))
                
                //AutoMapper
                .AddSingleton(config.CreateMapper());

        }

        #region :: Mediator

        private static IServiceCollection RegisterMediator(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("LiloDash.Domain");
            return services
                //Domain Bus (Mediator)
                .AddScoped<IMediatorHandler, InMemoryBus>()
                //Attach mediator commands by assembly
                .AddMediatR(assembly);
        }

        #endregion

        #region :: Service Broker

        private static IServiceCollection RegisterServiceBroker(this IServiceCollection services)
            => services.AddSingleton<IMessageHandler, ServiceBrokerBus>();

        #endregion
    }
}