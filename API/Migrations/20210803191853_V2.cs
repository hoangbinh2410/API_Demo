using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Nhanvien",
                columns: new[] { "ID", "Diachi", "Gioitinh", "Manv", "Ngaysinh", "Ten" },
                values: new object[,]
                {
                    { 1, "Bac Ninh", "Nam", "CT010304", new DateTime(1998, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoang Tien Binh" },
                    { 2, "Thai Binh", "Nam", "CT010305", new DateTime(1998, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoang Thanh Binh" },
                    { 3, "Bac Ninh", "Nu", "CT010306", new DateTime(1998, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hoang Thi Binh" },
                    { 4, "Ha Noi", "Nu", "CT010307", new DateTime(1998, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nguyen Thi A" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Nhanvien",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nhanvien",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Nhanvien",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Nhanvien",
                keyColumn: "ID",
                keyValue: 4);
        }
    }
}
