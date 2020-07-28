using System;
using System.Collections.Generic;
using LiloDash.Application.ViewModels;

namespace LiloDash.Application.Interfaces.Services
{
    public interface IUserAppService: IDisposable
    {
        void Register(UserViewModel userViewModel);

        IEnumerable<UserViewModel> GetAll();

        UserViewModel GetById(Guid id);

        void Update(UserViewModel userViewModel);

        void Remove(Guid id);
    }
}