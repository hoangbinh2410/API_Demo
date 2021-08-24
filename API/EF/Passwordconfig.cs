using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EF
{
    public class Passwordconfig : IEntityTypeConfiguration<User1>
    {
        public void Configure(EntityTypeBuilder<User1> builder)
        {
             builder.ToTable("User");
                builder.HasKey(x => x.ID);
                builder.Property(x => x.Name).HasColumnType("char(10)");
                builder.Property(x => x.Pass).HasColumnType("char(10)");
                builder.Property(x => x.Manv).HasColumnType("char(8)");
            
        }
    }
}
