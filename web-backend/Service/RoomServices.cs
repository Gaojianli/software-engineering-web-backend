﻿using Microsoft.EntityFrameworkCore;
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
        static public async Task<(bool,string)> checkIn(int roomID,CoreDbContext dbContext)
        {
            var dataRepo = OrderRepo.getInstance<OrderRepo>(dbContext);
            if (dataRepo.getUnfinised(roomID) == null)
            {
                var result = await dataRepo.Add(new Order
                {
                    roomID = roomID,
                    checkInTime = DateTime.Now
                });
                if (result != null)
                    return (true, "Check in successfully!");
                else
                    return (false, "Unknown error");
            }
            else
                return (false, "You have already checked in.");
        }

        static public async Task<(bool, string)> checkOut(int roomID, CoreDbContext dbContext)
        {
            var dataRepo = OrderRepo.getInstance<OrderRepo>(dbContext);
            var target = dataRepo.getUnfinised(roomID);
            if (target == null)
                return (false, "Room not checked in.");
            else
            {
                target.checkOutTime = DateTime.Now;
                target.finished = true;
                if (await dataRepo.Update(target))
                    return (true, "check out successfully");
                else
                    return (false, "Unknown error");
            }
        }
    }
}
