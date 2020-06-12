using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.DataRepo;
using web_backend.Model;
using web_backend.Models;
using web_backend.Util;

namespace web_backend.Service
{
    public static class RoomServices
    {
        static public async Task<bool> checkIn(int roomID,CoreDbContext dbContext)
        {
            var dataRepo = OrderRepo.getInstance<OrderRepo>(dbContext);
            var result = await dataRepo.Add(new Order
            {
                roomID = roomID,
                checkInTime = DateTime.Now
            });
            if (result != null)
                return true;
            else
                return false;
        }
    }
}
