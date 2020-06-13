using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using web_backend.Model;
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

        [HttpPost("{id}/ac")]
        public async Task<IActionResult> ControllerAC(int id,[FromServices] CoreDbContext dbContext)
        {
            var form = HttpContext.Request.Form;
            if (form.ContainsKey("status"))
            {
                try
                {
                    bool status = Convert.ToBoolean(form["status"]);
                    float? nowTemp = null;
                    float? targetTemp = null;
                    int? fanSpeed = null;
                    ControllRequest.MODE? mode = null;
                    if (form.ContainsKey("targetTemp"))
                        targetTemp = Convert.ToSingle(form["targetTemp"]);
                    if (form.ContainsKey("nowTemp"))
                        nowTemp = Convert.ToSingle(form["nowTemp"]);
                    if (form.ContainsKey("fanSpeed"))
                        fanSpeed = Convert.ToInt32(form["fanSpeed"]);
                    if (form.ContainsKey("mode"))
                        mode = (ControllRequest.MODE)Convert.ToInt32(form["mode"]);
                    await ACServices.changeStatusAsync(id, status, mode, targetTemp, fanSpeed, nowTemp, dbContext);
                    return Ok(new
                    {
                        code = 200,
                        msg = "Accepted."
                    });
                }
                catch(Exception e)
                {
                    Response.StatusCode = 500;
                    return new JsonResult(new
                    {
                        code = 500,
                        msg = e.Message
                    });
                }
            }
            else
            {
                Response.StatusCode = 406;
                return new JsonResult(new
                {
                    code = 406,
                    msg = "Not Acceptable"
                });
            }
        }
    }
}
