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
        [Route("v1/[controller]")]
        public async Task<IActionResult> BuildingGetAll()
            => Ok(await _buildingAppService.GetAll());

        [HttpGet]
        [Route("v1/[controller]/{id}")]
        public async Task<IActionResult> BuildingGetById(Guid id)
        {
            var result = await _buildingAppService.GetById(id);
            return result != null
                ? Ok(result)
                : NoContent();
        }
        
        [HttpPost]
        [Route("v1/[controller]")]
        public async Task<IActionResult> BuildingAdd(BuildingAddViewModel building)
        {
            var result = await _buildingAppService.Add(building);
            return result.Result.IsValid
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpPut]
        [Route("v1/[controller]/{id}")]
        public async Task<IActionResult> BuildingUpdate(BuildingUpdateViewModel building)
        {
            var result = await _buildingAppService.Update(building);
            return result.IsValid
                ? Ok(result)
                : BadRequest(result);
        }

        [HttpDelete]
        [Route("v1/[controller]/{id}")]
        public async Task<IActionResult> BuildingDelete(Guid id)
        {
            var result = await _buildingAppService.Remove(id);
            return result.IsValid
                ? Ok(result)
                : BadRequest(result);
        }
    }
}