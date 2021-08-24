using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EF
{
    public class NVcontext : DbContext
    {
        public DbSet<Nhanvien> Nhanviens { get; set; }
        public DbSet<User1> Passwords { get; set; }

        public NVcontext(DbContextOptions options) : base(options)
        {

        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Nhanvienconfig());
            modelBuilder.Seed();
        }
               
    }
}
