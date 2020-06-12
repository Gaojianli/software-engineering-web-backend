using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Model;

namespace web_backend.DataRepo
{
    public class OrderRepo:baseRepo
    {
        public async Task<Order> Add(Order toAdd)
        {
            dbContext.Order.Add(toAdd);
            await dbContext.SaveChangesAsync();
            return await dbContext.Order.FindAsync(toAdd.id);
        }
    }
}
