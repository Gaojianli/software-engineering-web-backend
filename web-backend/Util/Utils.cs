using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_backend.Util
{
    public static class Utils
    {
        public static bool checkLogin(HttpContext httpContext)
        {
            return httpContext.Session.TryGetValue("UserId", out byte[] _);
        }

        public static long getTimestamp()
        {
            long ts = ConvertDateTimeToInt(DateTime.Now);
            return ts;
        }

        /// <summary>  
        /// 将DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {  
            long t = (time.Ticks - 621356256000000000) / 10000;
            return t;
        }
    }
}
