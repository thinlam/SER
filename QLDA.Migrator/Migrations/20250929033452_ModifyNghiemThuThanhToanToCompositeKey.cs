using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class ModifyNghiemThuThanhToanToCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NghiemThuThanhToan_NghiemThu_NghiemThuId",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NghiemThuThanhToan",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_NghiemThuThanhToan_Index",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_NghiemThuThanhToan_NghiemThuId",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "NghiemThuThanhToan");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NghiemThuThanhToan",
                table: "NghiemThuThanhToan",
                columns: new[] { "NghiemThuId", "ThanhToanId" });

            migrationBuilder.AddForeignKey(
                name: "FK_NghiemThuThanhToan_NghiemThu_NghiemThuId",
                table: "NghiemThuThanhToan",
                column: "NghiemThuId",
                principalTable: "NghiemThu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NghiemThuThanhToan_NghiemThu_NghiemThuId",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NghiemThuThanhToan",
                table: "NghiemThuThanhToan");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "NghiemThuThanhToan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "NghiemThuThanhToan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NghiemThuThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "NghiemThuThanhToan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NghiemThuThanhToan",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "NghiemThuThanhToan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "NghiemThuThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NghiemThuThanhToan",
                table: "NghiemThuThanhToan",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThuThanhToan_Index",
                table: "NghiemThuThanhToan",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThuThanhToan_NghiemThuId",
                table: "NghiemThuThanhToan",
                column: "NghiemThuId");

            migrationBuilder.AddForeignKey(
                name: "FK_NghiemThuThanhToan_NghiemThu_NghiemThuId",
                table: "NghiemThuThanhToan",
                column: "NghiemThuId",
                principalTable: "NghiemThu",
                principalColumn: "Id");
        }
    }
}
