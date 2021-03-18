using System;
using LiloDash.Infra.Data.Context;
using LiloDash.Domain.Interfaces.Repository.Data;
using LiloDash.Domain.Model;
using System.Threading.Tasks;

namespace LiloDash.Infra.Data.Repository
{
    public class BuildingRepository: RepositoryBase<Building>, IBuildingRepository
    {
        private readonly LiloDataContext _context;

        public BuildingRepository(LiloDataContext context)
        {
            _context = context;
        }

        public void Add(Building building)
        {
            throw new NotImplementedException();
        }

        public Task<Building> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Building building)
        {
            throw new NotImplementedException();
        }
    }
}