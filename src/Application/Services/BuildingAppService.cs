using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiloDash.Application.Interfaces.Services;
using LiloDash.Application.ViewModels;
using LiloDash.Domain.Commands.Building;
using LiloDash.Domain.Interfaces.Repository.Data;
using LiloDash.Domain.Core.Bus;
using System.Threading.Tasks;
using FluentValidation.Results;

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
            => _mapper.Map<BuildingViewModel>(_buildingRepository.GetById(id));
        
        public IEnumerable<BuildingViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<AddResultViewModel<Guid>> Add(BuildingViewModel buildingViewModel)
        {
            var addCommand = _mapper.Map<BuildingAddCommand>(buildingViewModel);
            var result = await Bus.SendCommand(addCommand);
            return new AddResultViewModel<Guid>(result, addCommand.Id);
        }

        public async Task<ValidationResult> Update(BuildingViewModel buildingViewModel)
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