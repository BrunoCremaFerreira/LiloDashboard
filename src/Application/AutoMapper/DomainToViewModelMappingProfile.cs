using AutoMapper;
using LiloDash.Application.ViewModels;
using LiloDash.Domain.Model;

namespace LiloDash.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Building, BuildingViewModel>();
            CreateMap<Room, RoomViewModel>();
            CreateMap<Device, DeviceViewModel>();
        }
    }
}