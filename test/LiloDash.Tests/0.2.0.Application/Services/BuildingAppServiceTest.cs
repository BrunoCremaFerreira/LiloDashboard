using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using LiloDash.Domain.Model;
using LiloDash.Infra.Data.Context;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using LiloDash.API.Controllers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiloDash.Application.ViewModels.Building;
using LiloDash.Application.Interfaces.Services;
using Bogus;

namespace LiloDash.Tests.Application.Services
{
    public class BuildingAppServiceTest: Test<Building>
    {
        private readonly IBuildingAppService _buildingAppService;

        public BuildingAppServiceTest(LiloDataContext context,
            IBuildingAppService buildingAppService)
            :base(context)
        {
            _buildingAppService = buildingAppService;
        }

        [Fact(DisplayName = "GetById - Should return Building")]
        [Trait("Category", "BuildingAppService")]
        public async Task Building_GetById_ShouldReturnBuildingById()
        {
            //Arrange
            var building = await Context.Buildings.FirstOrDefaultAsync();

            //Act
            var result = await _buildingAppService.GetById(building.Id);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(result.Id, building.Id);
        }

        [Fact(DisplayName = "Add - Should return Building")]
        [Trait("Category", "BuildingAppService")]
        public async Task Building_Add_ShouldAddWithSuccess()
        {
            //Arrange
            var buildingAddViewModel = BuildingAddViewModelGetNewInstance();

            //Act
            var result = await _buildingAppService.Add(buildingAddViewModel);

            //Assert
            Assert.True(result.Result.IsValid);
            Assert.NotEqual(default, result.Id);
            Assert.NotEqual(Guid.Empty, result.Id);
        }

        private BuildingAddViewModel BuildingAddViewModelGetNewInstance()
            => new Faker<BuildingAddViewModel>().
                CustomInstantiator(e=> new BuildingAddViewModel
                {
                    Name = e.Name.FirstName()
                });
    }
}
