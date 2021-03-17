using System;
using LiloDash.Infra.Data.Context;
using LiloDash.Domain.Interfaces.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using LiloDash.Domain.Model;

namespace LiloDash.Infra.Data.Repository
{
    public class BuildingRepository: IBuildingRepository
    {
        private readonly LiloDataContext _context;

        public BuildingRepository(LiloDataContext context)
        {
            _context = context;
        }
    }
}