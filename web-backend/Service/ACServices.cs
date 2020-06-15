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
            var requsetDataRepo = ControllRequestRepo.getInstance(dbContext);
            var roomRepo = RoomRepo.getInstance(dbContext);
            var room = dbContext.Room.Find(roomID);
            if (status && (mode == null || targetTemp == null || nowTemp == null || fanSpeed == null))
            {
                var previousRequest = requsetDataRepo.findByID(room.latestRequest);
                mode ??= previousRequest.mode;
                targetTemp ??= previousRequest.targetTemp;
                nowTemp ??= previousRequest.nowTemp;
                fanSpeed ??= previousRequest.fanSpeed;
            }
            var request = new ControllRequest
            {
                roomID = roomID,
                status = status,
                mode = mode,
                targetTemp = targetTemp,
                fanSpeed = fanSpeed,
                nowTemp = nowTemp,
                time = DateTime.Now,
                orderId = room.orderID
            };
            var result = requsetDataRepo.Add(request);
            await dbContext.SaveChangesAsync();
            room.latestRequest = result.id;
            roomRepo.Update(room);
        }

        public static async Task<ControllRequest> getLatestRequest(int roomID, CoreDbContext dbContext)
        {
            return await dbContext.ControllRequest.FindAsync((dbContext.Room.Find(roomID).latestRequest));
        }
        public static IEnumerable<ControllRequest> getControllRequest(int roomID, CoreDbContext dbContext)
        {
            var room = dbContext.Room.Find(roomID);
            return ControllRequestRepo.getInstance(dbContext).Fetch(request => request.orderId == room.orderID);
        }
    }
}
