using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using web_backend.Model;

namespace web_backend.Models
{
    public class CoreDbContext : DbContext
    {
        public string ConnectionString;
        public virtual DbSet<User> User { get; set; }
        public CoreDbContext(DbContextOptions options):base(options)
        {
        }
    }
}