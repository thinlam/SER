using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_DuAn_DuAnBuoc_AddDuAnThoiGianBatDau_AddDabSoNgayThucHien : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoNgayThucHien",
                table: "DuAnBuoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayBatDau",
                table: "DuAn",
                type: "datetimeoffset",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoNgayThucHien",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "NgayBatDau",
                table: "DuAn");
        }
    }
}
