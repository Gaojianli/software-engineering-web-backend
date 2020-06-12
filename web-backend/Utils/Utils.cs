using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_backend.Utils
{
    public static class Utils
    {
        public static bool checkLogin(HttpContext httpContext)
        {
            return httpContext.Session.TryGetValue("UserId", out byte[] _);
        }
    }
}
