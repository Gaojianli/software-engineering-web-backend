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
            if (await RoomServices.checkIn(id, dbContext))
            {
                return Ok(new
                {
                    code = 200,
                    msg = "Check in successfully!"
                });
            }
            else
            {
                Response.StatusCode = 500;
                return new JsonResult(new
                {
                    code = 500,
                    msg = "check in failed!"
                });
            }
        }
    }
}
