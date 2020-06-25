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
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserAppService _userAppService;

        public UserController(ILogger<UserController> logger, IUserAppService userAppService)
        {
            _logger = logger;
            _userAppService = userAppService;
        }

        [HttpPost]
        public IActionResult CreateUser(UserViewModel user)
        {
            _userAppService.Register(user);
            return Ok();
        }
    }
}
