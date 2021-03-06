using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiloDash.Application.Interfaces.Services;
using LiloDash.Application.ViewModels;
using LiloDash.Domain.Interfaces.Repository.Data;
using LiloDash.Domain.Core.Bus;
using LiloDash.Domain.Commands.Device;

namespace LiloDash.Application.Services
{
    public class DeviceAppService : IDeviceAppService
    {
        private readonly IMapper _mapper;
        private readonly IDeviceRepository _deviceRepository;
        
        private readonly IMediatorHandler Bus;

        public DeviceAppService(IMapper mapper,
            IDeviceRepository deviceRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _deviceRepository = deviceRepository;
            Bus = bus;
        }

        public DeviceViewModel GetById(Guid id)
            => _mapper.Map<DeviceViewModel>(_deviceRepository.GetById(id));
        
        public IEnumerable<DeviceViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Register(DeviceViewModel deviceViewModel)
        {
            var registerCommand = _mapper.Map<DeviceAddCommand>(deviceViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(DeviceViewModel deviceViewModel)
        {
            var updateCommand = _mapper.Map<DeviceUpdateCommand>(deviceViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new DeviceRemoveCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
            => GC.SuppressFinalize(this);
    }
}