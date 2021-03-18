using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using LiloDash.Application.Interfaces.Services;
using LiloDash.Application.ViewModels;
using LiloDash.Domain.Commands.Room;
using LiloDash.Domain.Interfaces.Repository.Data;
using LiloDash.Domain.Core.Bus;

namespace LiloDash.Application.Services.User
{
    public class RoomAppService : IRoomAppService
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IMediatorHandler Bus;

        public RoomAppService(IMapper mapper,
            IRoomRepository roomRepository,
            IMediatorHandler bus)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
            Bus = bus;
        }

        public RoomViewModel GetById(Guid id)
         => _mapper.Map<RoomViewModel>(_roomRepository.GetById(id));

        public IEnumerable<RoomViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Register(RoomViewModel roomViewModel)
        {
            var registerCommand = _mapper.Map<RoomAddCommand>(roomViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(RoomViewModel roomViewModel)
        {
            var updateCommand = _mapper.Map<RoomUpdateCommand>(roomViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RoomRemoveCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
            => GC.SuppressFinalize(this);
    }
}