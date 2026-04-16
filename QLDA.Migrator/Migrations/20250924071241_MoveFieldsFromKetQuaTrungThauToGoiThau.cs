using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class MoveFieldsFromKetQuaTrungThauToGoiThau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "GiamSatHoatDongDauThau",
                table: "GoiThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThoiGianBatDauToChucLuaChonNhaThau",
                table: "GoiThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThoiGianThucHienGoiThau",
                table: "GoiThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TomTatCongViecChinhGoiThau",
                table: "GoiThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TuyChonMuaThem",
                table: "GoiThau",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiamSatHoatDongDauThau",
                table: "GoiThau");

            migrationBuilder.DropColumn(
                name: "ThoiGianBatDauToChucLuaChonNhaThau",
                table: "GoiThau");

            migrationBuilder.DropColumn(
                name: "ThoiGianThucHienGoiThau",
                table: "GoiThau");

            migrationBuilder.DropColumn(
                name: "TomTatCongViecChinhGoiThau",
                table: "GoiThau");

            migrationBuilder.DropColumn(
                name: "TuyChonMuaThem",
                table: "GoiThau");

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
    }
}
