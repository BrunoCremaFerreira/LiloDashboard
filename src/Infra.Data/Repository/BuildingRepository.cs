using System;
using Data.Context;
using Domain.Interfaces.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Domain.Model;

namespace Data.Repository
{
    public class BuildingRepository: Repository<Domain.Model.Building>, IBuildingRepository
    {
        public BuildingRepository(LiloDataContext context)
            : base(context)
        {

        }
    }
}