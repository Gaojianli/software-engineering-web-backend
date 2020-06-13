using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace web_backend.Model
{
    public class ControllRequest
    {
        [Key]
        public int id { get; set; }
        public int roomID { get; set; }
        public bool status { get; set; }
        public MODE? mode { get; set; }
        public float? targetTemp { get; set; }
        public int? fanSpeed { get; set; }
        public float? nowTemp { get; set; }

        public DateTime time { get; set; }

        public int orderId { get; set; }

        public enum MODE
        {
            HOT=1,
            COLD=2
        }
    }
}
