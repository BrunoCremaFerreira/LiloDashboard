using LiloDash.Domain.Core.Bus;
using LiloDash.Domain.Core.Notifications;
using LiloDash.Infra.Data.Repository;
using LiloDash.Infra.Data.Repository.User;
using LiloDash.Application.Interfaces.Services;
using LiloDash.Domain.Events.User;
using LiloDash.Domain.EventHandlers;
using MediatR;
using LiloDash.Domain.Commands.User;
using LiloDash.Domain.CommandHandlers;
using LiloDash.Domain.Interfaces;
using LiloDash.Domain.Interfaces.Repository.Data;
using LiloDash.Infra.Data.UOW;
using LiloDash.Application.Services;
using LiloDash.Domain.Interfaces.Model;
using LiloDash.Domain.Model;
using LiloDash.Domain.Events.Building;
using LiloDash.Domain.EventHandlers.Building;
using LiloDash.Domain.Commands.Building;
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
                .AddScoped<IUserAppService, UserAppService>()
                .AddScoped<IBuildingAppService, BuildingAppService>()
            
                //Domain - Events
                .AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>()
                .AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>()
                .AddScoped<INotificationHandler<UserUpdatedEvent>, UserEventHandler>()
                .AddScoped<INotificationHandler<UserRemovedEvent>, UserEventHandler>()

                .AddScoped<INotificationHandler<BuildingRegisteredEvent>, BuildingEventHandler>()
                .AddScoped<INotificationHandler<BuildingUpdatedEvent>, BuildingEventHandler>()
                .AddScoped<INotificationHandler<BuildingRemovedEvent>, BuildingEventHandler>()
            
                //Domain - Commands
                .AddScoped<IRequestHandler<RegisterNewUserCommand>, UserCommandHandler>()
                .AddScoped<IRequestHandler<UpdateUserCommand>, UserCommandHandler>()
                .AddScoped<IRequestHandler<RemoveUserCommand>, UserCommandHandler>()

                .AddScoped<IRequestHandler<RegisterNewBuildingCommand>, BuildingCommandHandler>()
                .AddScoped<IRequestHandler<UpdateBuildingCommand>, BuildingCommandHandler>()
                .AddScoped<IRequestHandler<RemoveBuildingCommand>, BuildingCommandHandler>()
            
                //Infra - Data
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IBuildingRepository, BuildingRepository>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<LiloDataContext>()
            
                //Infra - Identity
                .AddScoped<IUser, User>()
                
                //AutoMapper
                .AddSingleton(config.CreateMapper());

        }
    }
}