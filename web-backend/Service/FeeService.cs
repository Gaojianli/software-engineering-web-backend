using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Model;
using web_backend.Models;

namespace web_backend.Service
{
    public static class FeeService
    {
        public static float getFee(int roomID, CoreDbContext dbContext)
        {
            var requests = ACServices.getControllRequest(roomID, dbContext);
            requests.OrderBy(s => s.time);
            float fee = 0;
            foreach (var cur in requests)
            {
                if (cur.status == false) continue;
                if (System.Math.Abs((float)(cur.targetTemp - cur.nowTemp)) < 0.01) //温度稳定
                    fee += (float)0.5;
                else if (cur.fanSpeed <= 200) fee += 1/3;
                else if (cur.fanSpeed <= 400) fee += (float)0.5;
                else fee += 1;
            }
            return fee;
        }
    }
}