using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGoiThauHopDongToOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong");

            migrationBuilder.AddColumn<Guid>(
                name: "GoiThauId",
                table: "NghiemThu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThu_GoiThauId",
                table: "NghiemThu",
                column: "GoiThauId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong",
                column: "GoiThauId",
                unique: true,
                filter: "[GoiThauId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_NghiemThu_GoiThau_GoiThauId",
                table: "NghiemThu",
                column: "GoiThauId",
                principalTable: "GoiThau",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NghiemThu_GoiThau_GoiThauId",
                table: "NghiemThu");

            migrationBuilder.DropIndex(
                name: "IX_NghiemThu_GoiThauId",
                table: "NghiemThu");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "GoiThauId",
                table: "NghiemThu");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong",
                column: "GoiThauId");
        }
    }
}
