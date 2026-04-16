using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Tables_MigrateIntoEnforceOneToOneRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaTrungThau_GoiThau_GoiThauId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropIndex(
                name: "IX_ThanhToan_NghiemThuId",
                table: "ThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_TamUng_HopDongId",
                table: "TamUng");

            migrationBuilder.DropIndex(
                name: "IX_KetQuaTrungThau_GoiThauId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong");

            migrationBuilder.DropIndex(
                name: "IX_DangTaiKeHoachLcntLenMang_KeHoachLuaChonNhaThauId",
                table: "DangTaiKeHoachLcntLenMang");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_NghiemThuId",
                table: "ThanhToan",
                column: "NghiemThuId",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_TamUng_HopDongId",
                table: "TamUng",
                column: "HopDongId",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaTrungThau_GoiThauId",
                table: "KetQuaTrungThau",
                column: "GoiThauId",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong",
                column: "GoiThauId",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DangTaiKeHoachLcntLenMang_KeHoachLuaChonNhaThauId",
                table: "DangTaiKeHoachLcntLenMang",
                column: "KeHoachLuaChonNhaThauId",
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaTrungThau_GoiThau_GoiThauId",
                table: "KetQuaTrungThau",
                column: "GoiThauId",
                principalTable: "GoiThau",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaTrungThau_GoiThau_GoiThauId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropIndex(
                name: "IX_ThanhToan_NghiemThuId",
                table: "ThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_TamUng_HopDongId",
                table: "TamUng");

            migrationBuilder.DropIndex(
                name: "IX_KetQuaTrungThau_GoiThauId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong");

            migrationBuilder.DropIndex(
                name: "IX_DangTaiKeHoachLcntLenMang_KeHoachLuaChonNhaThauId",
                table: "DangTaiKeHoachLcntLenMang");

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
                name: "IX_KetQuaTrungThau_GoiThauId",
                table: "KetQuaTrungThau",
                column: "GoiThauId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong",
                column: "GoiThauId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DangTaiKeHoachLcntLenMang_KeHoachLuaChonNhaThauId",
                table: "DangTaiKeHoachLcntLenMang",
                column: "KeHoachLuaChonNhaThauId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaTrungThau_GoiThau_GoiThauId",
                table: "KetQuaTrungThau",
                column: "GoiThauId",
                principalTable: "GoiThau",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
