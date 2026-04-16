using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_E_ManHinh_MigrateIntoCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DmBuocManHinh_E_ManHinh_ManHinhId",
                table: "DmBuocManHinh");

            migrationBuilder.DropForeignKey(
                name: "FK_DuAnBuocManHinh_DuAnBuoc_BuocId",
                table: "DuAnBuocManHinh");

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
                name: "FK_DmBuocManHinh_E_ManHinh_ManHinhId",
                table: "DmBuocManHinh",
                column: "ManHinhId",
                principalTable: "E_ManHinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnBuocManHinh_DuAnBuoc_DuAnBuocId",
                table: "DuAnBuocManHinh",
                column: "DuAnBuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DmBuocManHinh_E_ManHinh_ManHinhId",
                table: "DmBuocManHinh");

            migrationBuilder.DropForeignKey(
                name: "FK_DuAnBuocManHinh_DuAnBuoc_DuAnBuocId",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropIndex(
                name: "IX_DuAnBuocManHinh_DuAnBuocId",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "DuAnBuocId",
                table: "DuAnBuocManHinh");

            migrationBuilder.AddForeignKey(
                name: "FK_DmBuocManHinh_E_ManHinh_ManHinhId",
                table: "DmBuocManHinh",
                column: "ManHinhId",
                principalTable: "E_ManHinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnBuocManHinh_DuAnBuoc_BuocId",
                table: "DuAnBuocManHinh",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
