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
            var room = await roomRepo.findById(roomID);
            if (status && (mode == null || targetTemp == null || nowTemp == null || fanSpeed == null))
            {
                var previousRequest = await requsetDataRepo.findByID(room.latestRequest);
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
            var result = await requsetDataRepo.Add(request);
            room.latestRequest = result.id;
            await roomRepo.Update(room);
        }

        public static async Task<ControllRequest> getLatestRequest(int roomID, CoreDbContext dbContext)
        {
            var room = await RoomRepo.getInstance(dbContext).findById(roomID);
            return await ControllRequestRepo.getInstance(dbContext).findByID(room.latestRequest);
        }
        public static async Task<IEnumerable<ControllRequest>> getControllRequest(int roomID, CoreDbContext dbContext)
        {
            var room = await RoomRepo.getInstance(dbContext).findById(roomID);
            return ControllRequestRepo.getInstance(dbContext).Fetch(request => request.orderId == room.orderID);
        }
    }
}
