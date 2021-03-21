using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using LiloDash.Application.ViewModels;

namespace LiloDash.Application.Interfaces.Services
{
    public interface IBuildingAppService : IDisposable
    {
        BuildingViewModel GetById(Guid id);
        
        IEnumerable<BuildingViewModel> GetAll();

        Task<AddResultViewModel<Guid>> Add(BuildingViewModel roomViewModel);
        
        Task<ValidationResult> Update(BuildingViewModel roomViewModel);

        Task<ValidationResult> Remove(Guid id);
    }
}