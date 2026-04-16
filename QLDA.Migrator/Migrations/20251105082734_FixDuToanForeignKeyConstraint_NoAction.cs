using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class FixDuToanForeignKeyConstraint_NoAction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAn_DuToan_DuToanHienTaiId",
                table: "DuAn");

            migrationBuilder.AddForeignKey(
                name: "FK_DuAn_DuToan_DuToanHienTaiId",
                table: "DuAn",
                column: "DuToanHienTaiId",
                principalTable: "DuToan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAn_DuToan_DuToanHienTaiId",
                table: "DuAn");

            migrationBuilder.AddForeignKey(
                name: "FK_DuAn_DuToan_DuToanHienTaiId",
                table: "DuAn",
                column: "DuToanHienTaiId",
                principalTable: "DuToan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
