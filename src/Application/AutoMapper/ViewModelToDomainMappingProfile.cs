using AutoMapper;
using LiloDash.Application.ViewModels;
using LiloDash.Domain.Commands.Building;
using LiloDash.Domain.Commands.Device;
using LiloDash.Domain.Commands.Room;
using LiloDash.Domain.Commands.User;

namespace LiloDash.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //User
            CreateMap<UserViewModel, RegisterNewUserCommand>().
                ConstructUsing(c=> new RegisterNewUserCommand(c.Name, c.Email, c.IsAdmin));
            CreateMap<UserViewModel, UpdateUserCommand>().
                ConstructUsing(c=> new UpdateUserCommand(c.Id, c.Name, c.Email));
            
            //Building
            CreateMap<BuildingViewModel, RegisterNewBuildingCommand>().
                ConstructUsing(c=> new RegisterNewBuildingCommand(c.Name));
            CreateMap<BuildingViewModel, UpdateBuildingCommand>().
                ConstructUsing(c=> new UpdateBuildingCommand(c.Id, c.Name));
            
            //Room
            CreateMap<RoomViewModel, RegisterNewRoomCommand>().
                ConstructUsing(c=> new RegisterNewRoomCommand(c.Name));
            CreateMap<RoomViewModel, UpdateRoomCommand>().
                ConstructUsing(c=> new UpdateRoomCommand(c.Id, c.Name));
            
            //Device
            CreateMap<DeviceViewModel, RegisterNewDeviceCommand>().
                ConstructUsing(c=> new RegisterNewDeviceCommand(c.Name, c.HardwareAddress));
            CreateMap<DeviceViewModel, UpdateDeviceCommand>().
                ConstructUsing(c=> new UpdateDeviceCommand(c.Id, c.Name, c.HardwareAddress));
        }
    }
}