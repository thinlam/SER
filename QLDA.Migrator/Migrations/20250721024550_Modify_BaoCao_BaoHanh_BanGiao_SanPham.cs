using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_BaoCao_BaoHanh_BanGiao_SanPham : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LanhDaoPhuTrachId",
                table: "BaoCaoBanGiaoSanPham",
                newName: "DonViNhanBanGiaoId");

            migrationBuilder.AddColumn<Guid>(
                name: "DonViBanGiaoId",
                table: "BaoCaoBanGiaoSanPham",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DonViBanGiaoId",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.RenameColumn(
                name: "DonViNhanBanGiaoId",
                table: "BaoCaoBanGiaoSanPham",
                newName: "LanhDaoPhuTrachId");
        }
    }
}
