using System;
using LiloDash.Infra.Data.Context;
using LiloDash.Domain.Interfaces.Repository.Data;
using LiloDash.Domain.Model;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace LiloDash.Infra.Data.Repository
{
    public class BuildingRepository: RepositoryBase, IBuildingRepository
    {
        public BuildingRepository(LiloDataContext context)
            :base(context)
        {
        }

        public async Task Add(Building building)
            => await AddAsync<Building>(building);

        public bool Exists(Expression<Func<Building, bool>> predicate)
            => Exists<Building>(predicate);

        public Task<Building> GetById(Guid id)
            => Task.FromResult(
                this.FindFirst<Building>(e=> e.Id == id));

        public async void Remove(Guid Id)
        {
            var building = await GetById(Id);

            if(building == null)
                return;

            Context.Buildings.Remove(building);
        }

        public void Update(Building building)
            => Update<Building>(building);
    }
}