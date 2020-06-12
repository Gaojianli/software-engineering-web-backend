using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_backend.Models;
using web_backend.Service;

namespace web_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        [HttpGet("{id}/checkin")]
        public async Task<IActionResult> checkIn(int id, [FromServices] CoreDbContext dbContext)
        {
            var (status, msg) = await RoomServices.checkIn(id, dbContext);
            if (status)
            {
                return Ok(new
                {
                    code = 200,
                    msg
                });
            }
            else
            {
                Response.StatusCode = 403;
                return new JsonResult(new
                {
                    code = 403,
                    msg
                });
            }
        }

        [HttpGet("{id}/checkout")]
        public async Task<IActionResult> checkOut(int id, [FromServices] CoreDbContext dbContext)
        {
            var (status, msg) = await RoomServices.checkOut(id, dbContext);
            if (status)
            {
                return Ok(new
                {
                    code = 200,
                    msg
                });
            }
            else
            {
                Response.StatusCode = 406;
                return new JsonResult(new
                {
                    code = 406,
                    msg
                });
            }

        }
    }
}
