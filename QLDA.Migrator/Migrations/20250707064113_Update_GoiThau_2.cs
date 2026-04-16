using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Update_GoiThau_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong",
                column: "GoiThauId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong",
                column: "GoiThauId",
                unique: true,
                filter: "[GoiThauId] IS NOT NULL");
        }
    }
}
