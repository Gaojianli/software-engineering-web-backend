using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Model;

namespace web_backend.DataRepo
{
    public class OrderRepo : BaseRepo<OrderRepo>
    {
        public async Task<Order> Add(Order toAdd)
        {
            dbContext.Order.Add(toAdd);
            await dbContext.SaveChangesAsync();
            return await dbContext.Order.FindAsync(toAdd.id);
        }

        public Order getUnfinised(int roomId)
        {
            var toReturn = from Order in dbContext.Order
                           where Order.roomID == roomId && Order.finished == false
                           select Order;
            if (toReturn.Count() == 0)
                return null;
            else
                return toReturn.Single();
        }

        public async Task<bool> Update(Order order)
        {
            dbContext.Order.Attach(order);
            return 0 < await dbContext.SaveChangesAsync();
        }
    }
}
