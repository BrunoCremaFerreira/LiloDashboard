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
    /// <summary>
    /// Base API controller
    /// </summary>
    [ApiController]
    public abstract class BaseLiloApiController: ControllerBase
    {   
    }
}