using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class AddNewFieldsToKetQuaTrungThau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GiamSatHoatDongDauThau",
                table: "KetQuaTrungThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThoiGianBatDauToChucLuaChonNhaThau",
                table: "KetQuaTrungThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThoiGianThucHienGoiThau",
                table: "KetQuaTrungThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TomTatCongViecChinhGoiThau",
                table: "KetQuaTrungThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TuyChonMuaThem",
                table: "KetQuaTrungThau",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiamSatHoatDongDauThau",
                table: "KetQuaTrungThau");

            migrationBuilder.DropColumn(
                name: "ThoiGianBatDauToChucLuaChonNhaThau",
                table: "KetQuaTrungThau");

            migrationBuilder.DropColumn(
                name: "ThoiGianThucHienGoiThau",
                table: "KetQuaTrungThau");

            migrationBuilder.DropColumn(
                name: "TomTatCongViecChinhGoiThau",
                table: "KetQuaTrungThau");

            migrationBuilder.DropColumn(
                name: "TuyChonMuaThem",
                table: "KetQuaTrungThau");
        }
    }
}
