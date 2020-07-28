using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LiloDash.Application.Interfaces.Services;
using LiloDash.Application.ViewModels;

namespace API.Controllers
{
    public class BuildingController: BaseLiloApiController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IBuildingAppService _buildingAppService;

        public BuildingController(ILogger<UserController> logger, IBuildingAppService buildingAppService)
        {
            _logger = logger;
            _buildingAppService = buildingAppService;
        }

        [HttpGet]
        [Route("v1/[controller]/building/{id}")]
        public BuildingViewModel GetBuilding(Guid id)
        {
            return _buildingAppService.GetById(id);
        }

        [HttpPost]
        [Route("v1/[controller]/building")]
        public IActionResult CreateBuilding(BuildingViewModel building)
        {
            _buildingAppService.Register(building);
            return Ok();
        }

        [HttpPut]
        [Route("v1/[controller]/building")]
        public IActionResult UpdateBuilding(BuildingViewModel building)
        {
            _buildingAppService.Update(building);
            return Ok();
        }

        [HttpDelete]
        [Route("v1/[controller]/building/{id}")]
        public IActionResult DeleteBuilding(Guid id)
        {
            _buildingAppService.Remove(id);
            return Ok();
        }
    }
}
