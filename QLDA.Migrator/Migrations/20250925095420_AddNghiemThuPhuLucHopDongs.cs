using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class AddNghiemThuPhuLucHopDongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NghiemThuPhuLucHopDong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NghiemThuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhuLucHopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NghiemThuPhuLucHopDong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NghiemThuPhuLucHopDong_NghiemThu_NghiemThuId",
                        column: x => x.NghiemThuId,
                        principalTable: "NghiemThu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NghiemThuPhuLucHopDong_PhuLucHopDong_PhuLucHopDongId",
                        column: x => x.PhuLucHopDongId,
                        principalTable: "PhuLucHopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThuPhuLucHopDong_NghiemThuId",
                table: "NghiemThuPhuLucHopDong",
                column: "NghiemThuId");

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThuPhuLucHopDong_PhuLucHopDongId",
                table: "NghiemThuPhuLucHopDong",
                column: "PhuLucHopDongId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NghiemThuPhuLucHopDong");
        }
    }
}
