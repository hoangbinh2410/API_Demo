using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.EF
{
    public  static class db
    {
         public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Nhanvien>().HasData(
                new Nhanvien() { ID = 1, Ten = "Hoang Tien Binh", Manv = "CT010304", Gioitinh = "Nam", Diachi = "Bac Ninh", Ngaysinh = new DateTime(1998, 10, 24), Phong = "PM" },
                new Nhanvien() { ID = 2, Ten = "Hoang Thanh Binh", Manv = "CT010305", Gioitinh = "Nam", Diachi = "Thai Binh", Ngaysinh = new DateTime(1998, 01, 24), Phong = "PM" },
                new Nhanvien() { ID = 3, Ten = "Hoang Thi Binh", Manv = "CT010306", Gioitinh = "Nu", Diachi = "Bac Ninh", Ngaysinh = new DateTime(1998, 11, 14), Phong = "App" },
                new Nhanvien() { ID = 4, Ten = "Nguyen Thi A", Manv = "CT010307", Gioitinh = "Nu", Diachi = "Ha Noi", Ngaysinh = new DateTime(1998, 10, 24), Phong = "Mobile" }
            );
            modelBuilder.Entity<User1>().HasData(
                new User1() { ID = 1, Name = "binhht2", Pass = "1234", Manv = "CT010304" },
                new User1() { ID = 2, Name = "binhht1", Pass = "1234", Manv = "CT010305" },
                new User1() { ID = 3, Name = "admin", Pass = "admin", Manv = "CT010306" }
                );


        }
    }
}
