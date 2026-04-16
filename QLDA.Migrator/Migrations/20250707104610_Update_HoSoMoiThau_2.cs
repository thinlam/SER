using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Update_HoSoMoiThau_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoSoMoiThau_GoiThau_GoiThauId",
                table: "HoSoMoiThau");

            migrationBuilder.RenameColumn(
                name: "GoiThauId",
                table: "HoSoMoiThau",
                newName: "KeHoachLuaChonNhaThauId");

            migrationBuilder.RenameIndex(
                name: "IX_HoSoMoiThau_GoiThauId",
                table: "HoSoMoiThau",
                newName: "IX_HoSoMoiThau_KeHoachLuaChonNhaThauId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayEHSMT",
                table: "HoSoMoiThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoMoiThau_KeHoachLuaChonNhaThau_KeHoachLuaChonNhaThauId",
                table: "HoSoMoiThau",
                column: "KeHoachLuaChonNhaThauId",
                principalTable: "KeHoachLuaChonNhaThau",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoSoMoiThau_KeHoachLuaChonNhaThau_KeHoachLuaChonNhaThauId",
                table: "HoSoMoiThau");

            migrationBuilder.DropColumn(
                name: "NgayEHSMT",
                table: "HoSoMoiThau");

            migrationBuilder.RenameColumn(
                name: "KeHoachLuaChonNhaThauId",
                table: "HoSoMoiThau",
                newName: "GoiThauId");

            migrationBuilder.RenameIndex(
                name: "IX_HoSoMoiThau_KeHoachLuaChonNhaThauId",
                table: "HoSoMoiThau",
                newName: "IX_HoSoMoiThau_GoiThauId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoMoiThau_GoiThau_GoiThauId",
                table: "HoSoMoiThau",
                column: "GoiThauId",
                principalTable: "GoiThau",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
