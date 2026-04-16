using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_BaoCaoBanGiaoSanPham_BaoCaoBaoHanhSanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaoCaoBanGiaoSanPham",
                columns: table => new
                {
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuocId = table.Column<int>(type: "int", nullable: true),
                    Ngay = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanhDaoPhuTrachId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaoBanGiaoSanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaoCaoBanGiaoSanPham_DuAnBuoc_BuocId",
                        column: x => x.BuocId,
                        principalTable: "DuAnBuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaoCaoBanGiaoSanPham_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaoCaoBaoHanhSanPham",
                columns: table => new
                {
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuocId = table.Column<int>(type: "int", nullable: true),
                    Ngay = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanhDaoPhuTrachId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaoBaoHanhSanPham", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaoCaoBaoHanhSanPham_DuAnBuoc_BuocId",
                        column: x => x.BuocId,
                        principalTable: "DuAnBuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaoCaoBaoHanhSanPham_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoTienDo_BuocId",
                table: "BaoCaoTienDo",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoBanGiaoSanPham_BuocId",
                table: "BaoCaoBanGiaoSanPham",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoBanGiaoSanPham_DuAnId",
                table: "BaoCaoBanGiaoSanPham",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoBanGiaoSanPham_Index",
                table: "BaoCaoBanGiaoSanPham",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoBaoHanhSanPham_BuocId",
                table: "BaoCaoBaoHanhSanPham",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoBaoHanhSanPham_DuAnId",
                table: "BaoCaoBaoHanhSanPham",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoBaoHanhSanPham_Index",
                table: "BaoCaoBaoHanhSanPham",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoTienDo_DuAnBuoc_BuocId",
                table: "BaoCaoTienDo",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoTienDo_DuAnBuoc_BuocId",
                table: "BaoCaoTienDo");

            migrationBuilder.DropTable(
                name: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropTable(
                name: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoTienDo_BuocId",
                table: "BaoCaoTienDo");
        }
    }
}
