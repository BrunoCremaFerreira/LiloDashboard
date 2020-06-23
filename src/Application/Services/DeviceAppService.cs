using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Repository.EventSourcing;
using AppService.Interfaces.Services;
using AppService.ViewModels;
using Domain.Commands.Device;
using Domain.Interfaces.Repository.Data;
using Domain.Core.Bus;

namespace Application.Services
{
    public class DeviceAppService : IDeviceAppService
    {
        private readonly IMapper _mapper;
        private readonly IDeviceRepository _deviceRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public DeviceAppService(IMapper mapper,
            IDeviceRepository deviceRepository,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _deviceRepository = deviceRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public DeviceViewModel GetById(Guid id)
        {
            return _mapper.Map<DeviceViewModel>(_deviceRepository.GetById(id));
        }

        public IEnumerable<DeviceViewModel> GetAll()
        {
            return _deviceRepository.GetAll().ProjectTo<DeviceViewModel>();
        }

        public void Register(DeviceViewModel deviceViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewDeviceCommand>(deviceViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(DeviceViewModel deviceViewModel)
        {
            var updateCommand = _mapper.Map<UpdateDeviceCommand>(deviceViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveDeviceCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}