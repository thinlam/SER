using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_ForeignReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoBanGiaoSanPham_DuAnBuoc_BuocId",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoBanGiaoSanPham_DuAn_DuAnId",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoBaoHanhSanPham_DuAnBuoc_BuocId",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoBaoHanhSanPham_DuAn_DuAnId",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoTienDo_DuAnBuoc_BuocId",
                table: "BaoCaoTienDo");

            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoTienDo_DuAn_DuAnId",
                table: "BaoCaoTienDo");

            migrationBuilder.DropForeignKey(
                name: "FK_GoiThau_DuAn_DuAnId",
                table: "GoiThau");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DuAn_DuAnId",
                table: "HopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaTrungThau_DuAn_DuAnId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropForeignKey(
                name: "FK_NghiemThu_DuAn_DuAnId",
                table: "NghiemThu");

            migrationBuilder.DropForeignKey(
                name: "FK_PheDuyetDuToan_DuAn_DuAnId",
                table: "PheDuyetDuToan");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuLucHopDong_DuAn_DuAnId",
                table: "PhuLucHopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_TamUng_DuAn_DuAnId",
                table: "TamUng");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToan_DuAn_DuAnId",
                table: "ThanhToan");

            migrationBuilder.DropTable(
                name: "KhoKhanVuongMac");

            migrationBuilder.DropIndex(
                name: "IX_PheDuyetDuToan_DuAnId",
                table: "PheDuyetDuToan");

            migrationBuilder.DropIndex(
                name: "IX_PheDuyetDuToan_Index",
                table: "PheDuyetDuToan");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoTienDo_BuocId",
                table: "BaoCaoTienDo");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoTienDo_DuAnId",
                table: "BaoCaoTienDo");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoTienDo_Index",
                table: "BaoCaoTienDo");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoBaoHanhSanPham_BuocId",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoBaoHanhSanPham_DuAnId",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoBaoHanhSanPham_Index",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoBanGiaoSanPham_BuocId",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoBanGiaoSanPham_DuAnId",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoBanGiaoSanPham_Index",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "BuocId",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "DuAnId",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "NgayKy",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "NgayVanBan",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "NguoiKy",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "SoVanBan",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "TrichYeu",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "PheDuyetDuToan");

            migrationBuilder.DropColumn(
                name: "BuocId",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "DuAnId",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "Ngay",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "NoiDung",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "BaoCaoTienDo");

            migrationBuilder.DropColumn(
                name: "BuocId",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "DuAnId",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "Ngay",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "NoiDung",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropColumn(
                name: "BuocId",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "DuAnId",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "Ngay",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "NoiDung",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PheDuyetDuToan",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AddColumn<int>(
                name: "DuAnBuocId",
                table: "NghiemThu",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DuAnBuocId",
                table: "GoiThau",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SoNgayThucHien",
                table: "DmBuoc",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCaoTienDo",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCaoBaoHanhSanPham",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCaoBanGiaoSanPham",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.CreateTable(
                name: "BaoCao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuocId = table.Column<int>(type: "int", nullable: true),
                    Ngay = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaoCao_DuAnBuoc_BuocId",
                        column: x => x.BuocId,
                        principalTable: "DuAnBuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaoCao_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaoCaoKhoKhanVuongMac",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TinhTrangId = table.Column<int>(type: "int", nullable: true),
                    HuongXuLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetQuaXuLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgayXuLy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaoKhoKhanVuongMac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaoCaoKhoKhanVuongMac_BaoCao_Id",
                        column: x => x.Id,
                        principalTable: "BaoCao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BaoCaoKhoKhanVuongMac_DmTinhTrangKhoKhan_TinhTrangId",
                        column: x => x.TinhTrangId,
                        principalTable: "DmTinhTrangKhoKhan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_VanBanQuyetDinh_BuocId",
                table: "VanBanQuyetDinh",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_ThanhToan_BuocId",
                table: "ThanhToan",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_TamUng_BuocId",
                table: "TamUng",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_PhuLucHopDong_BuocId",
                table: "PhuLucHopDong",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThu_DuAnBuocId",
                table: "NghiemThu",
                column: "DuAnBuocId");

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaTrungThau_BuocId",
                table: "KetQuaTrungThau",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_BuocId",
                table: "HopDong",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_GoiThau_DuAnBuocId",
                table: "GoiThau",
                column: "DuAnBuocId");

            migrationBuilder.CreateIndex(
                name: "IX_DangTaiKeHoachLcntLenMang_BuocId",
                table: "DangTaiKeHoachLcntLenMang",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoBanGiaoSanPham_DonViBanGiaoId",
                table: "BaoCaoBanGiaoSanPham",
                column: "DonViBanGiaoId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCao_BuocId",
                table: "BaoCao",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCao_DuAnId",
                table: "BaoCao",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoKhoKhanVuongMac_TinhTrangId",
                table: "BaoCaoKhoKhanVuongMac",
                column: "TinhTrangId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoBanGiaoSanPham_BaoCao_Id",
                table: "BaoCaoBanGiaoSanPham",
                column: "Id",
                principalTable: "BaoCao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoBanGiaoSanPham_DmNhaThau_DonViBanGiaoId",
                table: "BaoCaoBanGiaoSanPham",
                column: "DonViBanGiaoId",
                principalTable: "DmNhaThau",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoBaoHanhSanPham_BaoCao_Id",
                table: "BaoCaoBaoHanhSanPham",
                column: "Id",
                principalTable: "BaoCao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoTienDo_BaoCao_Id",
                table: "BaoCaoTienDo",
                column: "Id",
                principalTable: "BaoCao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DangTaiKeHoachLcntLenMang_DuAnBuoc_BuocId",
                table: "DangTaiKeHoachLcntLenMang",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GoiThau_DuAnBuoc_DuAnBuocId",
                table: "GoiThau",
                column: "DuAnBuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoiThau_DuAn_DuAnId",
                table: "GoiThau",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DuAnBuoc_BuocId",
                table: "HopDong",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DuAn_DuAnId",
                table: "HopDong",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaTrungThau_DuAnBuoc_BuocId",
                table: "KetQuaTrungThau",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaTrungThau_DuAn_DuAnId",
                table: "KetQuaTrungThau",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NghiemThu_DuAnBuoc_DuAnBuocId",
                table: "NghiemThu",
                column: "DuAnBuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NghiemThu_DuAn_DuAnId",
                table: "NghiemThu",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PheDuyetDuToan_VanBanQuyetDinh_Id",
                table: "PheDuyetDuToan",
                column: "Id",
                principalTable: "VanBanQuyetDinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuLucHopDong_DuAnBuoc_BuocId",
                table: "PhuLucHopDong",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuLucHopDong_DuAn_DuAnId",
                table: "PhuLucHopDong",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TamUng_DuAnBuoc_BuocId",
                table: "TamUng",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TamUng_DuAn_DuAnId",
                table: "TamUng",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToan_DuAnBuoc_BuocId",
                table: "ThanhToan",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToan_DuAn_DuAnId",
                table: "ThanhToan",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VanBanQuyetDinh_DuAnBuoc_BuocId",
                table: "VanBanQuyetDinh",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoBanGiaoSanPham_BaoCao_Id",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoBanGiaoSanPham_DmNhaThau_DonViBanGiaoId",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoBaoHanhSanPham_BaoCao_Id",
                table: "BaoCaoBaoHanhSanPham");

            migrationBuilder.DropForeignKey(
                name: "FK_BaoCaoTienDo_BaoCao_Id",
                table: "BaoCaoTienDo");

            migrationBuilder.DropForeignKey(
                name: "FK_DangTaiKeHoachLcntLenMang_DuAnBuoc_BuocId",
                table: "DangTaiKeHoachLcntLenMang");

            migrationBuilder.DropForeignKey(
                name: "FK_GoiThau_DuAnBuoc_DuAnBuocId",
                table: "GoiThau");

            migrationBuilder.DropForeignKey(
                name: "FK_GoiThau_DuAn_DuAnId",
                table: "GoiThau");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DuAnBuoc_BuocId",
                table: "HopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_DuAn_DuAnId",
                table: "HopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaTrungThau_DuAnBuoc_BuocId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaTrungThau_DuAn_DuAnId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropForeignKey(
                name: "FK_NghiemThu_DuAnBuoc_DuAnBuocId",
                table: "NghiemThu");

            migrationBuilder.DropForeignKey(
                name: "FK_NghiemThu_DuAn_DuAnId",
                table: "NghiemThu");

            migrationBuilder.DropForeignKey(
                name: "FK_PheDuyetDuToan_VanBanQuyetDinh_Id",
                table: "PheDuyetDuToan");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuLucHopDong_DuAnBuoc_BuocId",
                table: "PhuLucHopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_PhuLucHopDong_DuAn_DuAnId",
                table: "PhuLucHopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_TamUng_DuAnBuoc_BuocId",
                table: "TamUng");

            migrationBuilder.DropForeignKey(
                name: "FK_TamUng_DuAn_DuAnId",
                table: "TamUng");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToan_DuAnBuoc_BuocId",
                table: "ThanhToan");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhToan_DuAn_DuAnId",
                table: "ThanhToan");

            migrationBuilder.DropForeignKey(
                name: "FK_VanBanQuyetDinh_DuAnBuoc_BuocId",
                table: "VanBanQuyetDinh");

            migrationBuilder.DropTable(
                name: "BaoCaoKhoKhanVuongMac");

            migrationBuilder.DropTable(
                name: "BaoCao");

            migrationBuilder.DropIndex(
                name: "IX_VanBanQuyetDinh_BuocId",
                table: "VanBanQuyetDinh");

            migrationBuilder.DropIndex(
                name: "IX_ThanhToan_BuocId",
                table: "ThanhToan");

            migrationBuilder.DropIndex(
                name: "IX_TamUng_BuocId",
                table: "TamUng");

            migrationBuilder.DropIndex(
                name: "IX_PhuLucHopDong_BuocId",
                table: "PhuLucHopDong");

            migrationBuilder.DropIndex(
                name: "IX_NghiemThu_DuAnBuocId",
                table: "NghiemThu");

            migrationBuilder.DropIndex(
                name: "IX_KetQuaTrungThau_BuocId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_BuocId",
                table: "HopDong");

            migrationBuilder.DropIndex(
                name: "IX_GoiThau_DuAnBuocId",
                table: "GoiThau");

            migrationBuilder.DropIndex(
                name: "IX_DangTaiKeHoachLcntLenMang_BuocId",
                table: "DangTaiKeHoachLcntLenMang");

            migrationBuilder.DropIndex(
                name: "IX_BaoCaoBanGiaoSanPham_DonViBanGiaoId",
                table: "BaoCaoBanGiaoSanPham");

            migrationBuilder.DropColumn(
                name: "DuAnBuocId",
                table: "NghiemThu");

            migrationBuilder.DropColumn(
                name: "DuAnBuocId",
                table: "GoiThau");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PheDuyetDuToan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BuocId",
                table: "PheDuyetDuToan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "PheDuyetDuToan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "PheDuyetDuToan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId",
                table: "PheDuyetDuToan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "PheDuyetDuToan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PheDuyetDuToan",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayKy",
                table: "PheDuyetDuToan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayVanBan",
                table: "PheDuyetDuToan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiKy",
                table: "PheDuyetDuToan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoVanBan",
                table: "PheDuyetDuToan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrichYeu",
                table: "PheDuyetDuToan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "PheDuyetDuToan",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "PheDuyetDuToan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "PheDuyetDuToan",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<int>(
                name: "SoNgayThucHien",
                table: "DmBuoc",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCaoTienDo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BuocId",
                table: "BaoCaoTienDo",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "BaoCaoTienDo",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BaoCaoTienDo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId",
                table: "BaoCaoTienDo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "BaoCaoTienDo",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BaoCaoTienDo",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Ngay",
                table: "BaoCaoTienDo",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiDung",
                table: "BaoCaoTienDo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "BaoCaoTienDo",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BaoCaoTienDo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "BaoCaoTienDo",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCaoBaoHanhSanPham",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BuocId",
                table: "BaoCaoBaoHanhSanPham",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "BaoCaoBaoHanhSanPham",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BaoCaoBaoHanhSanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId",
                table: "BaoCaoBaoHanhSanPham",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "BaoCaoBaoHanhSanPham",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BaoCaoBaoHanhSanPham",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Ngay",
                table: "BaoCaoBaoHanhSanPham",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiDung",
                table: "BaoCaoBaoHanhSanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "BaoCaoBaoHanhSanPham",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BaoCaoBaoHanhSanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "BaoCaoBaoHanhSanPham",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCaoBanGiaoSanPham",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BuocId",
                table: "BaoCaoBanGiaoSanPham",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "BaoCaoBanGiaoSanPham",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BaoCaoBanGiaoSanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId",
                table: "BaoCaoBanGiaoSanPham",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "BaoCaoBanGiaoSanPham",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BaoCaoBanGiaoSanPham",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "Ngay",
                table: "BaoCaoBanGiaoSanPham",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NoiDung",
                table: "BaoCaoBanGiaoSanPham",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "BaoCaoBanGiaoSanPham",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BaoCaoBanGiaoSanPham",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "BaoCaoBanGiaoSanPham",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.CreateTable(
                name: "KhoKhanVuongMac",
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
                    TinhTrangId = table.Column<int>(type: "int", nullable: true),
                    BuocId = table.Column<int>(type: "int", nullable: true),
                    HuongXuLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KetQuaXuLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ngay = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NgayXuLy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoKhanVuongMac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhoKhanVuongMac_DmTinhTrangKhoKhan_TinhTrangId",
                        column: x => x.TinhTrangId,
                        principalTable: "DmTinhTrangKhoKhan",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KhoKhanVuongMac_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PheDuyetDuToan_DuAnId",
                table: "PheDuyetDuToan",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_PheDuyetDuToan_Index",
                table: "PheDuyetDuToan",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoTienDo_BuocId",
                table: "BaoCaoTienDo",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoTienDo_DuAnId",
                table: "BaoCaoTienDo",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoTienDo_Index",
                table: "BaoCaoTienDo",
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
                name: "IX_KhoKhanVuongMac_DuAnId",
                table: "KhoKhanVuongMac",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoKhanVuongMac_Index",
                table: "KhoKhanVuongMac",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_KhoKhanVuongMac_TinhTrangId",
                table: "KhoKhanVuongMac",
                column: "TinhTrangId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoBanGiaoSanPham_DuAnBuoc_BuocId",
                table: "BaoCaoBanGiaoSanPham",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoBanGiaoSanPham_DuAn_DuAnId",
                table: "BaoCaoBanGiaoSanPham",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoBaoHanhSanPham_DuAnBuoc_BuocId",
                table: "BaoCaoBaoHanhSanPham",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoBaoHanhSanPham_DuAn_DuAnId",
                table: "BaoCaoBaoHanhSanPham",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoTienDo_DuAnBuoc_BuocId",
                table: "BaoCaoTienDo",
                column: "BuocId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BaoCaoTienDo_DuAn_DuAnId",
                table: "BaoCaoTienDo",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GoiThau_DuAn_DuAnId",
                table: "GoiThau",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_DuAn_DuAnId",
                table: "HopDong",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaTrungThau_DuAn_DuAnId",
                table: "KetQuaTrungThau",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NghiemThu_DuAn_DuAnId",
                table: "NghiemThu",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PheDuyetDuToan_DuAn_DuAnId",
                table: "PheDuyetDuToan",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhuLucHopDong_DuAn_DuAnId",
                table: "PhuLucHopDong",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TamUng_DuAn_DuAnId",
                table: "TamUng",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhToan_DuAn_DuAnId",
                table: "ThanhToan",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
