using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Update_HoSoMoiThau_TrangThai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DaDang",
                table: "HoSoMoiThau");

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiId",
                table: "HoSoMoiThau",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TrangThaiId",
                table: "HoSoMoiThau");

            migrationBuilder.AddColumn<bool>(
                name: "DaDang",
                table: "HoSoMoiThau",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
