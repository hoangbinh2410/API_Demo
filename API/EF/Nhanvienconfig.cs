using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EF
{
    public class Nhanvienconfig : IEntityTypeConfiguration<Nhanvien>
    {
        public void Configure(EntityTypeBuilder<Nhanvien> builder)
        {
            builder.ToTable("Nhanvien");
            builder.HasKey(x => x.ID);
            builder.Property(x => x.Ten).HasColumnType("char(20)");
            builder.Property(x => x.Diachi).HasColumnType("char(30)");
            builder.Property(x => x.Gioitinh).HasColumnType("char(10)");
            builder.Property(x => x.Manv).HasColumnType("char(10)");
            builder.Property(x => x.Ngaysinh).HasColumnType("Date");

        }
    }
}
