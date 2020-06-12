using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace web_backend.Model
{
    public class Order
    {
        [Key]
        public int id { get; set; }
        public int roomID { get; set; }
        public DateTime checkInTime { get; set; }
        public DateTime checkOutTime { get; set; }
        public double fee { get; set; }

        public bool finished { get; set; }
    }
}
