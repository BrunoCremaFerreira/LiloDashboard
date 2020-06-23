using System;
using System.Collections.Generic;
using Application.ViewModels;

namespace Application.Interfaces.Services
{
    public interface IBuildingAppService : IDisposable
    {
        BuildingViewModel GetById(Guid id);
        
        IEnumerable<BuildingViewModel> GetAll();

        void Register(BuildingViewModel roomViewModel);
        
        void Update(BuildingViewModel roomViewModel);

        void Remove(Guid id);
    }
}