using AutoMapper;
using LiloDash.Application.ViewModels;
using LiloDash.Application.ViewModels.Building;
using LiloDash.Domain.Model;

namespace LiloDash.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Building, BuildingViewModel>();
            CreateMap<Room, RoomViewModel>();
            CreateMap<Device, DeviceViewModel>();
        }
    }
}