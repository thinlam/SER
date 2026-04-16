using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_DuAn_AddGiaiDoanHienTai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DmBuoc_DmGiaiDoan_GiaiDoanId",
                table: "DmBuoc");

            migrationBuilder.AddColumn<int>(
                name: "GiaiDoanHienTaiId",
                table: "DuAn",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_GiaiDoanHienTaiId",
                table: "DuAn",
                column: "GiaiDoanHienTaiId");

            migrationBuilder.AddForeignKey(
                name: "FK_DmBuoc_DmGiaiDoan_GiaiDoanId",
                table: "DmBuoc",
                column: "GiaiDoanId",
                principalTable: "DmGiaiDoan",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_DuAn_DmGiaiDoan_GiaiDoanHienTaiId",
                table: "DuAn",
                column: "GiaiDoanHienTaiId",
                principalTable: "DmGiaiDoan",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DmBuoc_DmGiaiDoan_GiaiDoanId",
                table: "DmBuoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DuAn_DmGiaiDoan_GiaiDoanHienTaiId",
                table: "DuAn");

            migrationBuilder.DropIndex(
                name: "IX_DuAn_GiaiDoanHienTaiId",
                table: "DuAn");

            migrationBuilder.DropColumn(
                name: "GiaiDoanHienTaiId",
                table: "DuAn");

            migrationBuilder.AddForeignKey(
                name: "FK_DmBuoc_DmGiaiDoan_GiaiDoanId",
                table: "DmBuoc",
                column: "GiaiDoanId",
                principalTable: "DmGiaiDoan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
