using System;
using System.IO;
using Xunit;
using LiloDash.Domain.Interfaces.Repository.Data;
using Microsoft.EntityFrameworkCore;
using LiloDash.Infra.Data.Context;
using Bogus;
using LiloDash.Domain.Commands.Building;
using LiloDash.Domain.Model;

namespace LiloDash.Tests.Data.Repository
{
    public class BuildingRepositoryTest: Test<Building>
    {

        private readonly IBuildingRepository _buildingRepository;

        public BuildingRepositoryTest(LiloDataContext context,
            IBuildingRepository buildingRepository)
            : base(context)
        {
            _buildingRepository = buildingRepository;
        }

        [Fact]
        [Trait("Category", "BuildingRepository")]
        public async void Building_GetById_ShouldReturnExistentBuild()
        {
            //Arrange
            var building = await Context.Buildings.FirstOrDefaultAsync();

            //Act
            var result = _buildingRepository.GetById(building.Id);

            //Assert
            Assert.NotNull(result);
        }
    }
}