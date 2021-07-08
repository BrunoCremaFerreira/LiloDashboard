using System;
using System.IO;
using LiloDash.Domain.Core.Models;
using LiloDash.Domain.Model;
using LiloDash.Infra.Data.Context;
using LiloDash.Tests.DatabaseSeeds;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace LiloDash.Tests
{
    public abstract class Test<TEntity> where TEntity : IEntity
    {
        private readonly LiloDataContext _context;

        public LiloDataContext Context => _context;

        public Test(LiloDataContext context)
        {
            _context = context;
            CreateDatabaseSeed();
        }

        protected virtual void CreateDatabaseSeed()
        {
            if(typeof(TEntity) == typeof(Building))
                this.CreateBuildingDatabaseSeed();
        }
    }
}
