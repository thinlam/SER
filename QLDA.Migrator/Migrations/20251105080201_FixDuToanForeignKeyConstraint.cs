using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class FixDuToanForeignKeyConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DuToanHienTaiId",
                table: "DuAn",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DuToan",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoDuToan = table.Column<long>(type: "bigint", nullable: false),
                    NamDuToan = table.Column<int>(type: "int", nullable: false),
                    SoQuyetDinhDuToan = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayKyDuToan = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuToan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuToan_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_DuToanHienTaiId",
                table: "DuAn",
                column: "DuToanHienTaiId",
                unique: true,
                filter: "[DuToanHienTaiId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DuToan_DuAnId",
                table: "DuToan",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_DuToan_Index",
                table: "DuToan",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_DuAn_DuToan_DuToanHienTaiId",
                table: "DuAn",
                column: "DuToanHienTaiId",
                principalTable: "DuToan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAn_DuToan_DuToanHienTaiId",
                table: "DuAn");

            migrationBuilder.DropTable(
                name: "DuToan");

            migrationBuilder.DropIndex(
                name: "IX_DuAn_DuToanHienTaiId",
                table: "DuAn");

            migrationBuilder.DropColumn(
                name: "DuToanHienTaiId",
                table: "DuAn");
        }
    }
}
