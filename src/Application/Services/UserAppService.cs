using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Repository.EventSourcing;
using Application.EventSourcedNormalizers.User;
using Application.Interfaces.Services;
using Application.ViewModels;
using Domain.Commands.User;
using Domain.Interfaces.Repository.Data;
using Domain.Core.Bus;

namespace Application.Services
{
    public class UserAppService: IUserAppService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public UserAppService(IMapper mapper,
            IUserRepository userRepository,
            IMediatorHandler bus,
            IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            return _userRepository.GetAll().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider);
        }

        public UserViewModel GetById(Guid id)
        {
            return _mapper.Map<UserViewModel>(_userRepository.GetById(id));
        }

        public void Register(UserViewModel userViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewUserCommand>(userViewModel);
            Bus.SendCommand(registerCommand);
        }

        public void Update(UserViewModel userViewModel)
        {
            var updateCommand = _mapper.Map<UpdateUserCommand>(userViewModel);
            Bus.SendCommand(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveUserCommand(id);
            Bus.SendCommand(removeCommand);
        }

        public IList<UserHistoryData> GetAllHistory(Guid id)
        {
            return UserHistory.ToJavaScriptHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}