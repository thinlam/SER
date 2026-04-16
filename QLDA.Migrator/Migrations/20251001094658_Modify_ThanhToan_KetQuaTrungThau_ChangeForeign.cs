using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_ThanhToan_KetQuaTrungThau_ChangeForeign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KetQuaTrungThau_GoiThauId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropColumn(
                name: "ThanhToanId",
                table: "NghiemThu");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaTrungThau_GoiThauId",
                table: "KetQuaTrungThau",
                column: "GoiThauId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_KetQuaTrungThau_GoiThauId",
                table: "KetQuaTrungThau");

            migrationBuilder.AddColumn<Guid>(
                name: "ThanhToanId",
                table: "NghiemThu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaTrungThau_GoiThauId",
                table: "KetQuaTrungThau",
                column: "GoiThauId");
        }
    }
}
