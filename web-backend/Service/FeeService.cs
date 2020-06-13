using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Model;
using web_backend.Models;

namespace web_backend.Service
{
    public static class FeeService
    {
        public static async Task<float> getFee(int roomID, CoreDbContext dbContext)
        {
            var requests = await ACServices.getControllRequest(roomID, dbContext);
            requests.OrderBy(s => s.time);
            IEnumerator<ControllRequest> i = requests.GetEnumerator();

            float fee = 0;

            while (i.MoveNext())
            {
                ControllRequest cur = i.Current;
                if(cur.status == false) continue;
                if(System.Math.Abs((float)(cur.targetTemp - cur.nowTemp)) < 0.01) //温度稳定
                    fee += (float)0.5;
                else if(cur.fanSpeed <= 200) fee += (float)1;
                else if(cur.fanSpeed <= 400) fee += (float)0.5;
                else fee += (float)0.3333333;
            }

            return fee;
        }
    }
}