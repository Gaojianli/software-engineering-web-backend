using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_backend.Model;

namespace web_backend.DataRepo
{
    public class RoomRepo : BaseRepo<RoomRepo>
    {
        public bool Update(Room room)
        {
            dbContext.Room.Attach(room);
            return 0 < dbContext.SaveChanges();
        }

        public Room findById(int id) => dbContext.Room.Find(id);
    }
}
