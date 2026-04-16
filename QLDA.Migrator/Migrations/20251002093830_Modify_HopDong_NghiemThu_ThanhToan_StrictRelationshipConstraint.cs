using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_HopDong_NghiemThu_ThanhToan_StrictRelationshipConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ThanhToan_NghiemThuId",
                table: "ThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_TamUng_HopDongId",
                table: "TamUng");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong");

            migrationBuilder.AlterColumn<Guid>(
                name: "NghiemThuId",
                table: "ThanhToan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HopDongId",
                table: "TamUng",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "HopDongId",
                table: "NghiemThu",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "GoiThauId",
                table: "HopDong",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_NghiemThuId",
                table: "ThanhToan",
                column: "NghiemThuId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TamUng_HopDongId",
                table: "TamUng",
                column: "HopDongId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong",
                column: "GoiThauId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ThanhToan_NghiemThuId",
                table: "ThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_TamUng_HopDongId",
                table: "TamUng");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong");

            migrationBuilder.AlterColumn<Guid>(
                name: "NghiemThuId",
                table: "ThanhToan",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "HopDongId",
                table: "TamUng",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "HopDongId",
                table: "NghiemThu",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "GoiThauId",
                table: "HopDong",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_NghiemThuId",
                table: "ThanhToan",
                column: "NghiemThuId",
                unique: true,
                filter: "[NghiemThuId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TamUng_HopDongId",
                table: "TamUng",
                column: "HopDongId",
                unique: true,
                filter: "[HopDongId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong",
                column: "GoiThauId",
                unique: true,
                filter: "[GoiThauId] IS NOT NULL");
        }
    }
}
