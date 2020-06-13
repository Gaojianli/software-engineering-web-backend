using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Model;

namespace web_backend.DataRepo
{
    public class RoomRepo : BaseRepo<RoomRepo>
    {
        public async Task<bool> Update(Room room)
        {
            dbContext.Room.Attach(room);
            return 0 < await dbContext.SaveChangesAsync();
        }

        public async Task<Room> findById(int id) => await dbContext.Room.FindAsync(id);
    }
}
