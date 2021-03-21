using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using LiloDash.Application.ViewModels;
using LiloDash.Application.ViewModels.Building;

namespace LiloDash.Application.Interfaces.Services
{
    public interface IBuildingAppService : IDisposable
    {
        BuildingViewModel GetById(Guid id);
        
        IEnumerable<BuildingViewModel> GetAll();

        Task<AddResultViewModel<Guid>> Add(BuildingAddViewModel roomViewModel);
        
        Task<ValidationResult> Update(BuildingUpdateViewModel roomViewModel);

        Task<ValidationResult> Remove(Guid id);
    }
}