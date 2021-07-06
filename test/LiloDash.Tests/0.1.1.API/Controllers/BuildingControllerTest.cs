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

namespace LiloDash.Domain.Tests.API.Controllers
{
    public class BuildingControllerTest: Test<Building>
    {
        protected readonly DefaultHttpContext _httpContext;
        protected readonly ControllerContext _controllerContext;
        protected readonly BuildingController _controller;

        public BuildingControllerTest(LiloDataContext context,
            DefaultHttpContext httpContext,
            ControllerContext controllerContext,
            BuildingController controller)
            :base(context)
        {
            _httpContext = httpContext;
            _controllerContext = controllerContext;
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
            Assert.Equal((result.Value as BuildingViewModel).Id, building.Id);
        }

        protected async override void CreateDatabaseSeed()
        {
            Context.Database.EnsureDeleted();
            Context.Buildings.Add(new Building(Guid.NewGuid(), "House"));
            await Context.Commit();
        }
    }
}
