using System;
using System.Collections.Generic;
using Application.ViewModels;

namespace Application.Interfaces.Services
{
    public interface IRoomAppService : IDisposable
    {
        RoomViewModel GetById(Guid id);
        
        IEnumerable<RoomViewModel> GetAll();
        
        void Register(RoomViewModel roomViewModel);

        void Update(RoomViewModel roomViewModel);
        
        void Remove(Guid id);
    }
}