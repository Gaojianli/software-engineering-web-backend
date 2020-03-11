using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace web_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelloworldController : ControllerBase
    {
        ILogger<HelloworldController> _logger;

        public HelloworldController(ILogger<HelloworldController> logger)
        {
            _logger = logger;
        }
        public IActionResult Get()
        {
            return Ok(new
            {
                code = 200,
                message = "Hellow"
            });
        }

        [HttpPost("postTest")]
        public IActionResult postTest()
        {
            var context=ControllerContext.HttpContext;
            var toReturn = new Dictionary<string,string>();
            foreach(var item in context.Request.Form)
            {
                toReturn.Add(item.Key, item.Value);
            }
            return Ok(toReturn);
        }

    }
}