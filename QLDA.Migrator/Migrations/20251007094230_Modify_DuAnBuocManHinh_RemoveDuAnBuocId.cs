using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_DuAnBuocManHinh_RemoveDuAnBuocId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAnBuocManHinh_DuAnBuoc_DuAnBuocId",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropIndex(
                name: "IX_DuAnBuocManHinh_DuAnBuocId",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "DuAnBuocId",
                table: "DuAnBuocManHinh");

            migrationBuilder.CreateIndex(
                name: "IX_E_ManHinh_Ten",
                table: "E_ManHinh",
                column: "Ten",
                unique: true,
                filter: "[Ten] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnBuocManHinh_DuAnBuoc_BuocId",
                table: "DuAnBuocManHinh",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAnBuocManHinh_DuAnBuoc_BuocId",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropIndex(
                name: "IX_E_ManHinh_Ten",
                table: "E_ManHinh");

            migrationBuilder.AddColumn<int>(
                name: "DuAnBuocId",
                table: "DuAnBuocManHinh",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocManHinh_DuAnBuocId",
                table: "DuAnBuocManHinh",
                column: "DuAnBuocId");

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnBuocManHinh_DuAnBuoc_DuAnBuocId",
                table: "DuAnBuocManHinh",
                column: "DuAnBuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id");
        }
    }
}
