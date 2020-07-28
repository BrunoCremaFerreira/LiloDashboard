using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LiloDash.Application.Interfaces.Services;
using LiloDash.Application.ViewModels;

namespace LiloDash.API.Controllers
{
    /// <summary>
    /// Base API controller
    /// </summary>
    [ApiController]
    public abstract class BaseLiloApiController: ControllerBase
    {   
    }
}