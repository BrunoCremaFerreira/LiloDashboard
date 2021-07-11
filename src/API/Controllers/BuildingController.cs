using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LiloDash.Application.Interfaces.Services;
using LiloDash.Application.ViewModels.Building;

namespace LiloDash.API.Controllers
{
    public class BuildingController: BaseLiloApiController
    {
        private readonly IBuildingAppService _buildingAppService;

        public BuildingController(IBuildingAppService buildingAppService)
            => _buildingAppService = buildingAppService;
        
        [HttpGet]
        [Route("v1/[controller]/building")]
        public async Task<IActionResult> BuildingGetAll()
            => Ok(await _buildingAppService.GetAll());

        [HttpGet]
        [Route("v1/[controller]/building/{id}")]
        public async Task<IActionResult> BuildingGetById(Guid id)
            => Ok(await _buildingAppService.GetById(id));
        
        [HttpPost]
        [Route("v1/[controller]/building")]
        public async Task<IActionResult> BuildingAdd(BuildingAddViewModel building)
        {
            var result = await _buildingAppService.Add(building);
            return Ok(result);
        }

        [HttpPut]
        [Route("v1/[controller]/building/{id}")]
        public async Task<IActionResult> BuildingUpdate(BuildingUpdateViewModel building)
        {
            var result = await _buildingAppService.Update(building);
            return Ok(result);
        }

        [HttpDelete]
        [Route("v1/[controller]/building/{id}")]
        public async Task<IActionResult> BuildingDelete(Guid id)
        {
            var result = await _buildingAppService.Remove(id);
            return Ok(result);
        }
    }
}