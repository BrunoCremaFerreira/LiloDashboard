using System;
using System.Collections.Generic;
using Application.ViewModels;

namespace Application.Interfaces.Services
{
    public interface IDeviceAppService: IDisposable
    {
        DeviceViewModel GetById(Guid id);
        
        IEnumerable<DeviceViewModel> GetAll();
        
        void Register(DeviceViewModel deviceViewModel);

        void Update(DeviceViewModel deviceViewModel);

        void Remove(Guid id);

    }
}