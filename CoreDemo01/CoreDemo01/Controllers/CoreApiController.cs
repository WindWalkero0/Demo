using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo01.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CoreApiController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}