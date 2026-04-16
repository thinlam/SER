using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNghiemThuThanhToanToOneToOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NghiemThuThanhToan");

            migrationBuilder.AddColumn<Guid>(
                name: "NghiemThuId",
                table: "ThanhToan",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ThanhToanId",
                table: "NghiemThu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_NghiemThuId",
                table: "ThanhToan",
                column: "NghiemThuId",
                unique: true,
                filter: "[NghiemThuId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToan_NghiemThu_NghiemThuId",
                table: "ThanhToan",
                column: "NghiemThuId",
                principalTable: "NghiemThu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToan_NghiemThu_NghiemThuId",
                table: "ThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_ThanhToan_NghiemThuId",
                table: "ThanhToan");

            migrationBuilder.DropColumn(
                name: "NghiemThuId",
                table: "ThanhToan");

            migrationBuilder.DropColumn(
                name: "ThanhToanId",
                table: "NghiemThu");

            migrationBuilder.CreateTable(
                name: "NghiemThuThanhToan",
                columns: table => new
                {
                    NghiemThuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NghiemThuThanhToan", x => new { x.NghiemThuId, x.ThanhToanId });
                    table.ForeignKey(
                        name: "FK_NghiemThuThanhToan_NghiemThu_NghiemThuId",
                        column: x => x.NghiemThuId,
                        principalTable: "NghiemThu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NghiemThuThanhToan_ThanhToan_ThanhToanId",
                        column: x => x.ThanhToanId,
                        principalTable: "ThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThuThanhToan_ThanhToanId",
                table: "NghiemThuThanhToan",
                column: "ThanhToanId");
        }
    }
}
