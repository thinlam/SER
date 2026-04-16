using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_DanhMucBuoc_DuAnBuoc_part2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PartialView",
                table: "DuAnBuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenBuoc",
                table: "DuAnBuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Used",
                table: "DuAnBuoc",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DuAnBuocManHinh",
                columns: table => new
                {
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuocId = table.Column<int>(type: "int", nullable: false),
                    ManHinhId = table.Column<int>(type: "int", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAnBuocManHinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAnBuocManHinh_DuAnBuoc_BuocId",
                        column: x => x.BuocId,
                        principalTable: "DuAnBuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DuAnBuocManHinh_E_ManHinh_ManHinhId",
                        column: x => x.ManHinhId,
                        principalTable: "E_ManHinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocManHinh_BuocId",
                table: "DuAnBuocManHinh",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocManHinh_Index",
                table: "DuAnBuocManHinh",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocManHinh_ManHinhId",
                table: "DuAnBuocManHinh",
                column: "ManHinhId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "PartialView",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "TenBuoc",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "Used",
                table: "DuAnBuoc");
        }
    }
}
