using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_GoiThau_RemoveWrongForeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NghiemThu_GoiThau_GoiThauId",
                table: "NghiemThu");

            migrationBuilder.DropIndex(
                name: "IX_NghiemThu_GoiThauId",
                table: "NghiemThu");

            migrationBuilder.DropColumn(
                name: "GoiThauId",
                table: "NghiemThu");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GoiThauId",
                table: "NghiemThu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThu_GoiThauId",
                table: "NghiemThu",
                column: "GoiThauId");

            migrationBuilder.AddForeignKey(
                name: "FK_NghiemThu_GoiThau_GoiThauId",
                table: "NghiemThu",
                column: "GoiThauId",
                principalTable: "GoiThau",
                principalColumn: "Id");
        }
    }
}
