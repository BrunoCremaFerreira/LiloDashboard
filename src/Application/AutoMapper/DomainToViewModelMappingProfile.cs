using AutoMapper;
using Application.ViewModels;
using Domain.Model;

namespace Application.AutoMapper
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