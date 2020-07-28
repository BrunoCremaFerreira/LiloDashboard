using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiloDash.Application.Interfaces.Services;
using LiloDash.Application.ViewModels;
using LiloDash.Domain.Commands.Building;
using LiloDash.Domain.Interfaces.Repository.Data;
using LiloDash.Domain.Core.Bus;

namespace LiloDash.Application.Services.User
{
    public class BuildingAppService : IBuildingAppService
    {
        private readonly IMapper _mapper;
        private readonly IBuildingRepository _buildingRepository;
        
        private readonly IMediatorHandler Bus;

        public BuildingAppService(IMapper mapper,
            IBuildingRepository buildingRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _buildingRepository = buildingRepository;
            Bus = bus;
        }

        public BuildingViewModel GetById(Guid id)
        {
            return _mapper.Map<BuildingViewModel>(_buildingRepository.GetById(id));
        }

        public IEnumerable<BuildingViewModel> GetAll()
        {
            return _buildingRepository.
                GetAll().
                ProjectTo<BuildingViewModel>(_mapper.ConfigurationProvider);
        }

        public async void Register(BuildingViewModel buildingViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewBuildingCommand>(buildingViewModel);
            await Bus.SendCommand(registerCommand);
        }

        public async void Update(BuildingViewModel buildingViewModel)
        {
            var updateCommand = _mapper.Map<UpdateBuildingCommand>(buildingViewModel);
            await Bus.SendCommand(updateCommand);
        }

        public async void Remove(Guid id)
        {
            var removeCommand = new RemoveBuildingCommand(id);
            await Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}