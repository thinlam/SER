using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_BaoCaoKhoKhanVuongMac_AddMucDoKhoKhan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MucDoKhoKhanId",
                table: "BaoCaoKhoKhanVuongMac",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DmMucDoKhoKhan",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmMucDoKhoKhan", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoKhoKhanVuongMac_MucDoKhoKhanId",
                table: "BaoCaoKhoKhanVuongMac",
                column: "MucDoKhoKhanId");

            migrationBuilder.CreateIndex(
                name: "IX_DmMucDoKhoKhan_Index",
                table: "DmMucDoKhoKhan",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoKhoKhanVuongMac_DmMucDoKhoKhan_MucDoKhoKhanId",
                table: "BaoCaoKhoKhanVuongMac",
                column: "MucDoKhoKhanId",
                principalTable: "DmMucDoKhoKhan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoKhoKhanVuongMac_DmMucDoKhoKhan_MucDoKhoKhanId",
                table: "BaoCaoKhoKhanVuongMac");

            migrationBuilder.DropTable(
                name: "DmMucDoKhoKhan");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoKhoKhanVuongMac_MucDoKhoKhanId",
                table: "BaoCaoKhoKhanVuongMac");

            migrationBuilder.DropColumn(
                name: "MucDoKhoKhanId",
                table: "BaoCaoKhoKhanVuongMac");
        }
    }
}
