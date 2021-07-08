using System;
using System.IO;
using Xunit;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LiloDash.Application.ViewModels.Building;
using Bogus;
using LiloDash.Domain.Commands.Building;

namespace LiloDash.Tests.Domain.Commands
{
    public class BuildingAddCommandTest
    {
        [Fact]
        [Trait("Category", "BuildingCommands")]
        public void Building_BuildingAddCommand_IsValid()
        {
            //Arrange
            var commandAdd = BuildingAddCommandGetNewInstance();

            //Act
            var isValid = commandAdd.IsValid();

            //Assert
            Assert.True(isValid);
            Assert.True(commandAdd.ValidationResult.IsValid);
        }

        private BuildingAddCommand BuildingAddCommandGetNewInstance()
            => new Faker<BuildingAddCommand>().
                CustomInstantiator(e=> new BuildingAddCommand(e.Name.FirstName()));
    }
}