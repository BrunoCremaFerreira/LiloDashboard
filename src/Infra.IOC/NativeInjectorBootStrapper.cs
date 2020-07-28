using LiloDash.Domain.Core.Bus;
using LiloDash.Domain.Core.Notifications;
using LiloDash.Domain.Core.Events;
using Bus;
using Data.EventSourcing;
using Data.Repository;
using Data.Repository.EventSourcing;
using Data.Repository.User;
using LiloDash.Application.Interfaces.Services;
using LiloDash.Domain.Events.User;
using LiloDash.Domain.EventHandlers;
using MediatR;
using LiloDash.Domain.Commands.User;
using LiloDash.Domain.CommandHandlers;
using LiloDash.Domain.Interfaces;
using LiloDash.Domain.Interfaces.Repository.Data;
using Data.UOW;
using LiloDash.Application.Services;
using LiloDash.Domain.Interfaces.Model;
using LiloDash.Domain.Model;
using LiloDash.Domain.Events.Building;
using LiloDash.Domain.EventHandlers.Building;
using LiloDash.Domain.Commands.Building;
using Microsoft.Extensions.DependencyInjection;
using Data.Context;
using LiloDash.Application.Services.User;

namespace IOC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            
            // Application
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IBuildingAppService, BuildingAppService>();
            
            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<UserRegisteredEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UserUpdatedEvent>, UserEventHandler>();
            services.AddScoped<INotificationHandler<UserRemovedEvent>, UserEventHandler>();

            services.AddScoped<INotificationHandler<BuildingRegisteredEvent>, BuildingEventHandler>();
            services.AddScoped<INotificationHandler<BuildingUpdatedEvent>, BuildingEventHandler>();
            services.AddScoped<INotificationHandler<BuildingRemovedEvent>, BuildingEventHandler>();
            
            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewUserCommand>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserCommand>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveUserCommand>, UserCommandHandler>();

            services.AddScoped<IRequestHandler<RegisterNewBuildingCommand>, BuildingCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateBuildingCommand>, BuildingCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveBuildingCommand>, BuildingCommandHandler>();
            
            // Infra - Data
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<LiloDataContext>();
            
            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            
            // Infra - Identity
            services.AddScoped<IUser, User>();
        }
    }
}