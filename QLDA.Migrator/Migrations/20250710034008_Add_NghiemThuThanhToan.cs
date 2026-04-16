using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_NghiemThuThanhToan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NghiemThuThanhToan",
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
                    NghiemThuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NghiemThuThanhToan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NghiemThuThanhToan_NghiemThu_NghiemThuId",
                        column: x => x.NghiemThuId,
                        principalTable: "NghiemThu",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NghiemThuThanhToan_ThanhToan_ThanhToanId",
                        column: x => x.ThanhToanId,
                        principalTable: "ThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThuThanhToan_Index",
                table: "NghiemThuThanhToan",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThuThanhToan_NghiemThuId",
                table: "NghiemThuThanhToan",
                column: "NghiemThuId");

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThuThanhToan_ThanhToanId",
                table: "NghiemThuThanhToan",
                column: "ThanhToanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NghiemThuThanhToan");
        }
    }
}
