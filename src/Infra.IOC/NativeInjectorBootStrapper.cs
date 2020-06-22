using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Domain.Core.Bus;
using Domain.Core.Notifications;
using Bus;
using Data.Context;
using Data.EventSourcing;
using Data.Repository;
using Data.Repository.EventSourcing;
using Data.Repository.User;
using AppService.Interfaces.Services;
using AppService.Services;
using Domain.Events.User;
using Domain.EventHandlers.User;
using MediatR;
using Domain.Commands.User;
using Domain.CommandHandlers.User;
using Domain.Interfaces;
using Domain.Interfaces.Repository.Data;
using Data.UOW;
using Application.Services.User;
using Domain.Interfaces.Model;
using Domain.Model;
using Domain.Core.Events;
using Domain.Events.Building;
using Domain.EventHandlers.Building;
using Domain.Commands.Building;
using Domain.CommandHandlers;

namespace IOC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
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
            services.AddScoped<ProjectManagerDataContext>();
            
            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();
            
            // Infra - Identity
            services.AddScoped<IUser, User>();
        }
    }
}