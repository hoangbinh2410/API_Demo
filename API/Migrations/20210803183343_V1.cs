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
                    Ngaysinh = table.Column<DateTime>(type: "Date", nullable: false),
                    Gioitinh = table.Column<string>(type: "char(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nhanvien", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nhanvien");
        }
    }
}
