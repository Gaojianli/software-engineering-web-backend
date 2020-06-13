using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace web_backend.Model
{
    public class Room
    {
        [Key]
        public int id { get; set; }
        public int orderID { get; set; }
        public int latestRequest { get; set; }
    }
}
