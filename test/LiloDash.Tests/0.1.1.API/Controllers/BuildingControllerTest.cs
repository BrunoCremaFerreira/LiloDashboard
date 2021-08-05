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

namespace LiloDash.Tests.API.Controllers
{
    public class BuildingControllerTest: Test<Building>
    {
        private readonly BuildingController _controller;

        public BuildingControllerTest(LiloDataContext context,
            BuildingController controller)
            :base(context)
        {
            _controller = controller;
        }

        [Fact(DisplayName = "GetById - Should return Building")]
        [Trait("Category", "BuildingController")]
        public async Task Building_GetBuilding_ShouldReturnBuildingById()
        {
            //Arrange
            var building = await Context.Buildings.FirstOrDefaultAsync();

            //Act
            var result = await _controller.BuildingGetById(building.Id) 
                as ObjectResult;

            //Assert
            Assert.True(result.StatusCode == 200);
            Assert.NotNull(result.Value);
            Assert.Equal(((BuildingViewModel) result.Value).Id, building.Id);
        }
    }
}
