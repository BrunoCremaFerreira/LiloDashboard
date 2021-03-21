using AutoMapper;
using LiloDash.Application.ViewModels;
using LiloDash.Application.ViewModels.Building;
using LiloDash.Domain.Commands.Building;
using LiloDash.Domain.Commands.Device;
using LiloDash.Domain.Commands.Room;

namespace LiloDash.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            //Building
            CreateMap<BuildingAddViewModel, BuildingAddCommand>()
                .ConstructUsing(c=> new BuildingAddCommand(c.Name));
            CreateMap<BuildingUpdateViewModel, BuildingUpdateCommand>()
                .ConstructUsing(c=> new BuildingUpdateCommand(c.Id, c.Name));
            
            //Room
            CreateMap<RoomViewModel, RoomAddCommand>()
                .ConstructUsing(c=> new RoomAddCommand(c.Name));
            CreateMap<RoomViewModel, RoomUpdateCommand>()
                .ConstructUsing(c=> new RoomUpdateCommand(c.Id, c.Name));
            
            //Device
            CreateMap<DeviceViewModel, DeviceAddCommand>()
                .ConstructUsing(c=> new DeviceAddCommand(c.Name, c.HardwareAddress));
            CreateMap<DeviceViewModel, DeviceUpdateCommand>()
                .ConstructUsing(c=> new DeviceUpdateCommand(c.Id, c.Name, c.HardwareAddress));
        }
    }
}