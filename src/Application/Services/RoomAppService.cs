using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Application.Interfaces.Services;
using Application.ViewModels;
using Domain.Commands.Room;
using Domain.Interfaces.Repository.Data;
using Domain.Core.Bus;

namespace Application.Services.User
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
        {
            return _mapper.Map<RoomViewModel>(_roomRepository.GetById(id));
        }

        public IEnumerable<RoomViewModel> GetAll()
        {
            return _roomRepository.
                GetAll().ProjectTo<RoomViewModel>(_mapper.ConfigurationProvider);
        }

        public void Register(RoomViewModel roomViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewRoomCommand>(roomViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(RoomViewModel roomViewModel)
        {
            var updateCommand = _mapper.Map<UpdateRoomCommand>(roomViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveRoomCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}