using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_NghiemThu_ThanhToan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_ThanhToan_ThanhToanId",
                table: "HopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_NghiemThu_ThanhToan_ThanhToanId",
                table: "NghiemThu");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuLucHopDong_ThanhToan_ThanhToanId",
                table: "PhuLucHopDong");

            migrationBuilder.DropTable(
                name: "NghiemThu_PhuLucHopDong");

            migrationBuilder.DropIndex(
                name: "IX_PhuLucHopDong_ThanhToanId",
                table: "PhuLucHopDong");

            migrationBuilder.DropIndex(
                name: "IX_NghiemThu_ThanhToanId",
                table: "NghiemThu");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_ThanhToanId",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "KhongCoHopDong",
                table: "ThanhToan");

            migrationBuilder.DropColumn(
                name: "ThanhToanId",
                table: "PhuLucHopDong");

            migrationBuilder.DropColumn(
                name: "ThanhToanId",
                table: "NghiemThu");

            migrationBuilder.DropColumn(
                name: "ThanhToanId",
                table: "HopDong");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KhongCoHopDong",
                table: "ThanhToan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ThanhToanId",
                table: "PhuLucHopDong",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ThanhToanId",
                table: "NghiemThu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ThanhToanId",
                table: "HopDong",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NghiemThu_PhuLucHopDong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NghiemThuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhuLucHopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NghiemThu_PhuLucHopDong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NghiemThu_PhuLucHopDong_NghiemThu_NghiemThuId",
                        column: x => x.NghiemThuId,
                        principalTable: "NghiemThu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NghiemThu_PhuLucHopDong_PhuLucHopDong_PhuLucHopDongId",
                        column: x => x.PhuLucHopDongId,
                        principalTable: "PhuLucHopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhuLucHopDong_ThanhToanId",
                table: "PhuLucHopDong",
                column: "ThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThu_ThanhToanId",
                table: "NghiemThu",
                column: "ThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ThanhToanId",
                table: "HopDong",
                column: "ThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThu_PhuLucHopDong_NghiemThuId",
                table: "NghiemThu_PhuLucHopDong",
                column: "NghiemThuId");

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThu_PhuLucHopDong_PhuLucHopDongId",
                table: "NghiemThu_PhuLucHopDong",
                column: "PhuLucHopDongId");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_ThanhToan_ThanhToanId",
                table: "HopDong",
                column: "ThanhToanId",
                principalTable: "ThanhToan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NghiemThu_ThanhToan_ThanhToanId",
                table: "NghiemThu",
                column: "ThanhToanId",
                principalTable: "ThanhToan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuLucHopDong_ThanhToan_ThanhToanId",
                table: "PhuLucHopDong",
                column: "ThanhToanId",
                principalTable: "ThanhToan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
