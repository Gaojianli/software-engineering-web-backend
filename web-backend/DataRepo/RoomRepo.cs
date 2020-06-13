using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Model;

namespace web_backend.DataRepo
{
    public class RoomRepo : baseRepo<RoomRepo>
    {
        public async Task<bool> Update(Room room)
        {
            dbContext.Room.Attach(room);
            return 0 < await dbContext.SaveChangesAsync();
        }

        public async Task<Room> findById(int id) => await (from r in dbContext.Room where r.id == id select r).FirstOrDefaultAsync() ;
    }
}
