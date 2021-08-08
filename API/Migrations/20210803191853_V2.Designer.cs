﻿// <auto-generated />
using System;
using API.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(NVcontext))]
    [Migration("20210803191853_V2")]
    partial class V2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("API.EF.Nhanvien", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Diachi")
                        .HasColumnType("char(30)");

                    b.Property<string>("Gioitinh")
                        .HasColumnType("char(10)");

                    b.Property<string>("Manv")
                        .HasColumnType("char(10)");

                    b.Property<DateTime>("Ngaysinh")
                        .HasColumnType("Date");

                    b.Property<string>("Ten")
                        .HasColumnType("char(20)");

                    b.HasKey("ID");

                    b.ToTable("Nhanvien");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Diachi = "Bac Ninh",
                            Gioitinh = "Nam",
                            Manv = "CT010304",
                            Ngaysinh = new DateTime(1998, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Ten = "Hoang Tien Binh"
                        },
                        new
                        {
                            ID = 2,
                            Diachi = "Thai Binh",
                            Gioitinh = "Nam",
                            Manv = "CT010305",
                            Ngaysinh = new DateTime(1998, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Ten = "Hoang Thanh Binh"
                        },
                        new
                        {
                            ID = 3,
                            Diachi = "Bac Ninh",
                            Gioitinh = "Nu",
                            Manv = "CT010306",
                            Ngaysinh = new DateTime(1998, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Ten = "Hoang Thi Binh"
                        },
                        new
                        {
                            ID = 4,
                            Diachi = "Ha Noi",
                            Gioitinh = "Nu",
                            Manv = "CT010307",
                            Ngaysinh = new DateTime(1998, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Ten = "Nguyen Thi A"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}