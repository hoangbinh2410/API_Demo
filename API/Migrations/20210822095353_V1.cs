using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nhanvien",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ten = table.Column<string>(type: "char(20)", nullable: true),
                    Manv = table.Column<string>(type: "char(10)", nullable: true),
                    Diachi = table.Column<string>(type: "char(30)", nullable: true),
                    Gioitinh = table.Column<string>(type: "char(4)", nullable: true),
                    Ngaysinh = table.Column<DateTime>(type: "Date", nullable: false),
                    Phong = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanvien", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Passwords",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pass = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manv = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passwords", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Nhanvien",
                columns: new[] { "ID", "Diachi", "Gioitinh", "Manv", "Ngaysinh", "Phong", "Ten" },
                values: new object[,]
                {
                    { 1, "Bac Ninh", "Nam", "CT010304", new DateTime(1998, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "PM", "Hoang Tien Binh" },
                    { 2, "Thai Binh", "Nam", "CT010305", new DateTime(1998, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "PM", "Hoang Thanh Binh" },
                    { 3, "Bac Ninh", "Nu", "CT010306", new DateTime(1998, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "App", "Hoang Thi Binh" },
                    { 4, "Ha Noi", "Nu", "CT010307", new DateTime(1998, 10, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mobile", "Nguyen Thi A" }
                });

            migrationBuilder.InsertData(
                table: "Passwords",
                columns: new[] { "ID", "Manv", "Name", "Pass" },
                values: new object[,]
                {
                    { 1, "CT010304", "binhht2", "1234" },
                    { 2, "CT010305", "binhht1", "1234" },
                    { 3, "CT010306", "admin", "admin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhanvien");

            migrationBuilder.DropTable(
                name: "Passwords");
        }
    }
}
