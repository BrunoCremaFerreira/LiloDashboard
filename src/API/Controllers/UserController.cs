using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Interfaces.Services;
using Application.ViewModels;

namespace API.Controllers
{
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserAppService _userAppService;

        public UserController(ILogger<UserController> logger, IUserAppService userAppService)
        {
            _logger = logger;
            _userAppService = userAppService;
        }

        [HttpGet]
        [Route("v1/[controller]/user/{id}")]
        public UserViewModel GetUser(Guid id)
        {
            return _userAppService.GetById(id);
        }

        [HttpPost]
        [Route("v1/[controller]/user")]
        public IActionResult CreateUser(UserViewModel user)
        {
            _userAppService.Register(user);
            return Ok();
        }

        [HttpPut]
        [Route("v1/[controller]/user")]
        public IActionResult UpdateUser(UserViewModel user)
        {
            _userAppService.Update(user);
            return Ok();
        }

        [HttpDelete]
        [Route("v1/[controller]/user/{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            _userAppService.Remove(id);
            return Ok();
        }
    }
}
