using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_backend.DataRepo;
using web_backend.Models;
using web_backend.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CoreDbContext dbContext;
        public UserController(CoreDbContext context) => dbContext = context;
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST api/<UserController>
        [HttpPost("login")]
        public IActionResult Post()
        {
            var body = Request.Form;

            if (body.ContainsKey("username") && body.ContainsKey("password"))
            {
                var userRepo = UserRepo.getInstance(dbContext);
                var result = userRepo.Login(body["username"], body["password"]);
                if (result == null)
                {
                    return new JsonResult(new
                    {
                        code = 401,
                        msg = "Invaild password."
                    });
                }
                else
                {
                    //HttpContext.Session.SetInt32("UserId", result.id);
                    return new JsonResult(new
                    {
                        code = 200,
                        data = result
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

        // PUT api/<UserController>
        [HttpPut]
        public async Task<IActionResult> Put()
        {
            var body = Request.Form;
            if (body.ContainsKey("username") && body.ContainsKey("password"))
            {
                var userRepo = UserRepo.getInstance(dbContext);
                var username = body["username"].ToString();
                var password = body["password"].ToString();
                if (username.Length >= 20 || password.Length >= 30)
                {
                    Response.StatusCode = 406;
                    return new JsonResult(new
                    {
                        code = 406,
                        msg = "Password or username too long"
                    });
                }
                else
                {
                    var result = await userRepo.Add(username, password);
                    Response.StatusCode = 201;
                    return new JsonResult(new
                    {
                        code = 201,
                        data = result
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

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
