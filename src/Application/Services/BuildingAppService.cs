using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiloDash.Application.Interfaces.Services;
using LiloDash.Application.ViewModels;
using LiloDash.Application.ViewModels.Building;
using LiloDash.Domain.Commands.Building;
using LiloDash.Domain.Interfaces.Repository.Data;
using LiloDash.Domain.Core.Bus;
using System.Threading.Tasks;
using FluentValidation.Results;
using LiloDash.Domain.Model;

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

        public async Task<BuildingViewModel> GetById(Guid id)
            => _mapper.Map<BuildingViewModel>(await _buildingRepository.GetById(id));
        
        public async Task<IEnumerable<BuildingViewModel>> GetAll()
        { 
            var result = await _buildingRepository.GetAll();
            return _mapper.Map<IEnumerable<BuildingViewModel>>(result);
        }

        public async Task<AddResultViewModel<Guid>> Add(BuildingAddViewModel buildingViewModel)
        {
            var addCommand = _mapper.Map<BuildingAddCommand>(buildingViewModel);
            var result = await Bus.SendCommand(addCommand);
            return new AddResultViewModel<Guid>(result, addCommand.Id);
        }

        public async Task<ValidationResult> Update(BuildingUpdateViewModel buildingViewModel)
        {
            var updateCommand = _mapper.Map<BuildingUpdateCommand>(buildingViewModel);
            return await (Task<ValidationResult>)Bus.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new BuildingRemoveCommand(id);
            return await (Task<ValidationResult>)Bus.SendCommand(removeCommand);
        }

        public void Dispose()
            => GC.SuppressFinalize(this);
    }
}