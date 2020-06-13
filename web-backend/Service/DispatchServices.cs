using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using web_backend.Model;
using web_backend.Models;


namespace web_backend.Service
{
    public static class DispatcherService
    {
        const int AIRNUM = 8;
        const int AIRLIMIT = 3;
        const int HIGH = 600;
        const int MIDDLE = 400;
        const int LOW = 200;
        static int[] status = new int[AIRNUM];

        static int countSpeed(int speed)
        {
            int cur = 0;
            for(int i = 0; i < AIRNUM; i++) {
                if(status[i] == speed) cur += 1;
            }
            return cur;
        }

        static void turnoff(int speed)
        {
            // turen off low speed
            if(speed >= MIDDLE)
            {
                for(int i = 0; i < AIRNUM; i++) {
                    if(status[i] == LOW) {
                        status[i] = 0;
                        return;
                    }
                }
            }

            //turn off midlle speed
            if(speed == HIGH)
            {
                for(int i = 0; i < AIRNUM; i++) {
                    if(status[i] == MIDDLE) {
                        status[i] = 0;
                        return;
                    }
                }
            }

        }
        public static async Task<bool> airAvaiable(int roomID, bool curStatus,int? speed)
        {
            if(curStatus == false){
                status[roomID] = 0;
                return true;
            }
            if(status[roomID] != 0) return true; //此空调正在运行
            
            int cur = countSpeed(HIGH);
            if(cur >= AIRLIMIT) return false; //high = AIRLIMIT
            if(speed == HIGH) { // not full, turn off middle or low one
                turnoff(HIGH);
                status[roomID] = HIGH;
                return true;
            }
            if(speed == MIDDLE) {
                cur += countSpeed(MIDDLE);
                if(cur >= AIRLIMIT) return false; //high + middle = AIRLIMIT
                turnoff(MIDDLE); // not full, turn off lower one
                status[roomID] = MIDDLE;
                return true;
            }
            // speed == LOW
            cur += countSpeed(LOW);
            if(cur < AIRLIMIT) {
                status[roomID] = LOW;
                return true;
            }
            return false;

        }
    }
}