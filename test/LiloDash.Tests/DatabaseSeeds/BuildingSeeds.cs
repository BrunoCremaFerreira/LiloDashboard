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
using LiloDash.Domain.Core.Models;

namespace LiloDash.Tests.DatabaseSeeds
{
    public static class BuildingSeeds
    {
        public static async void CreateBuildingDatabaseSeed<TEntity>(this Test<TEntity> source)
            where TEntity : IEntity
        {
            source.Context.Database.EnsureDeleted();
            source.Context.Buildings.Add(new Building(Guid.NewGuid(), "House"));
            await source.Context.Commit();
        }
    }
}
