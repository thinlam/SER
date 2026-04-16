using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Update_DuAn_TepDinhKem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachLuaChonNhaThau_DuAn_DuAnId1",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropIndex(
                name: "IX_KeHoachLuaChonNhaThau_DuAnId1",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "DuAnId1",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "TepDinhKem",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianKhoiCong",
                table: "DuAn",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ThoiGianHoanThanh",
                table: "DuAn",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "TepDinhKem");

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId1",
                table: "KeHoachLuaChonNhaThau",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianKhoiCong",
                table: "DuAn",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ThoiGianHoanThanh",
                table: "DuAn",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachLuaChonNhaThau_DuAnId1",
                table: "KeHoachLuaChonNhaThau",
                column: "DuAnId1");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachLuaChonNhaThau_DuAn_DuAnId1",
                table: "KeHoachLuaChonNhaThau",
                column: "DuAnId1",
                principalTable: "DuAn",
                principalColumn: "Id");
        }
    }
}
