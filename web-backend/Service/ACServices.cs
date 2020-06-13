using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.DataRepo;
using web_backend.Model;
using web_backend.Models;

namespace web_backend.Service
{
    public static class ACServices
    {
        public static async Task changeStatusAsync(int roomID, bool status, ControllRequest.MODE? mode, float? targetTemp, int? fanSpeed, float? nowTemp, CoreDbContext dbContext)
        {
            var request = new ControllRequest
            {
                roomID = roomID,
                status = status,
                mode = mode,
                targetTemp = targetTemp,
                fanSpeed = fanSpeed,
                nowTemp = nowTemp,
                time = DateTime.Now
            };
            var requsetDataRepo = ControllRequestRepo.getInstance(dbContext);
            var result = await requsetDataRepo.Add(request);
            var roomRepo = RoomRepo.getInstance(dbContext);
            var room = await roomRepo.findById(result.roomID);
            room.latestRequest = result.id;
            await roomRepo.Update(room);
        }

        public static async Task<ControllRequest> getLatestRequest(int roomID,CoreDbContext dbContext)
        {
            var room = await RoomRepo.getInstance(dbContext).findById(roomID);
            return await ControllRequestRepo.getInstance(dbContext).findByID(room.latestRequest);
        }
    }
}
