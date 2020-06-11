using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace web_backend.Model
{
    public class User
    {
        [Key]
        public int id { get; set; }
        [MaxLength(20)]
        public string name { get; set; }
        [MaxLength(100)]
        public string password { get; set; }
        [MaxLength(10)]
        [DefaultValue("manager")]
        public string role { get; set; } = "manager";
    }
}
