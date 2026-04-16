using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class MofifyEntities_NghiemThu_TamUng_KetQuaTrungThau_DuAn_AddColumns_VIFTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_CanBoDonVi_CanBo_CanBoId",
            //     table: "CanBoDonVi");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_CanBoDonVi_DM_DONVI_DonViId",
            //     table: "CanBoDonVi");

            migrationBuilder.DropForeignKey(
                name: "FK_NghiemThuPhuLucHopDong_NghiemThu_NghiemThuId",
                table: "NghiemThuPhuLucHopDong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NghiemThuPhuLucHopDong",
                table: "NghiemThuPhuLucHopDong");

            migrationBuilder.DropIndex(
                name: "IX_NghiemThuPhuLucHopDong_NghiemThuId",
                table: "NghiemThuPhuLucHopDong");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK_CanBo",
            //     table: "CanBo");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK_CanBoDonVi",
            //     table: "CanBoDonVi");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "VanBanQuyetDinh");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "ThanhVienBanQLDA");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "ThanhToan");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "TepDinhKem");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetDuAnNguonVon");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetDuAnHangMuc");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "PhuLucHopDong");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "NghiemThuThanhToan");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "NghiemThuPhuLucHopDong");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "NghiemThuPhuLucHopDong");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "NghiemThuPhuLucHopDong");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "NghiemThuPhuLucHopDong");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "NghiemThuPhuLucHopDong");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "NghiemThuPhuLucHopDong");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "NghiemThuPhuLucHopDong");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "NghiemThu");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "HoSoMoiThau");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "GoiThau");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmTrangThaiTienDo");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmTrangThaiDuAn");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmTinhTrangKhoKhan");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmQuyTrinh");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmPhuongThucLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmNhomDuAn");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmNhaThau");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmNguonVon");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmMucDoKhoKhan");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmLoaiVanBan");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmLoaiHopDong");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmLoaiGoiThau");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmLoaiDuAnTheoNam");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmLoaiDuAn");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmLinhVuc");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmHinhThucQuanLy");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmHinhThucLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmHinhThucDauTu");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmGiaiDoan");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmChuDauTu");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmChucVu");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmBuocTrangThaiTienDo");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmBuocManHinh");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DmBuoc");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "DangTaiKeHoachLcntLenMang");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "ChiuTrachNhiemXuLy");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "BaoCao");

            // migrationBuilder.RenameTable(
            //     name: "CanBo",
            //     newName: "CANBO");

            // migrationBuilder.RenameTable(
            //     name: "CanBoDonVi",
            //     newName: "CANBO_DONVI");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "TamUng",
                newName: "NgayKetThucBaoLanh");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "KetQuaTrungThau",
                newName: "NgayQuyetDinh");

            migrationBuilder.RenameColumn(
                name: "UpdatedDateTime",
                table: "DuAn",
                newName: "NgayKyDuToan");

            // migrationBuilder.RenameColumn(
            //     name: "SoBhxh",
            //     table: "CANBO",
            //     newName: "SoBHXH");

            // migrationBuilder.RenameColumn(
            //     name: "ConNguoiId",
            //     table: "CANBO",
            //     newName: "ConNguoiID");

            // migrationBuilder.RenameColumn(
            //     name: "ChucDanhId",
            //     table: "CANBO",
            //     newName: "ChucDanhID");

            // migrationBuilder.RenameColumn(
            //     name: "Id",
            //     table: "CANBO",
            //     newName: "CanBoID");

            // migrationBuilder.RenameColumn(
            //     name: "DonViId",
            //     table: "CANBO_DONVI",
            //     newName: "DonViID");

            // migrationBuilder.RenameColumn(
            //     name: "ChucVuId",
            //     table: "CANBO_DONVI",
            //     newName: "ChucVuID");

            // migrationBuilder.RenameColumn(
            //     name: "CanBoId",
            //     table: "CANBO_DONVI",
            //     newName: "CanBoID");

            // migrationBuilder.RenameColumn(
            //     name: "Id",
            //     table: "CANBO_DONVI",
            //     newName: "CanBoDonViID");

            // migrationBuilder.RenameIndex(
            //     name: "IX_CanBoDonVi_DonViId",
            //     table: "CANBO_DONVI",
            //     newName: "IX_CANBO_DONVI_DonViID");

            // migrationBuilder.RenameIndex(
            //     name: "IX_CanBoDonVi_CanBoId",
            //     table: "CANBO_DONVI",
            //     newName: "IX_CANBO_DONVI_CanBoID");

            

            migrationBuilder.AddColumn<string>(
                name: "SoBaoLanh",
                table: "TamUng",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GiaTri",
                table: "NghiemThu",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "SoQuyetDinh",
                table: "KetQuaTrungThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NamDuToan",
                table: "DuAn",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "SoDuToan",
                table: "DuAn",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "SoQuyetDinhDuToan",
                table: "DuAn",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "SoBHXH",
            //     table: "CANBO",
            //     type: "nvarchar(20)",
            //     maxLength: 20,
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "nvarchar(max)",
            //     oldNullable: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "NgheNghiep",
            //     table: "CANBO",
            //     type: "nvarchar(2000)",
            //     maxLength: 2000,
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "nvarchar(max)",
            //     oldNullable: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "MaSoCanBo",
            //     table: "CANBO",
            //     type: "nvarchar(20)",
            //     maxLength: 20,
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "nvarchar(max)",
            //     oldNullable: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "ChuyenMon",
            //     table: "CANBO",
            //     type: "nvarchar(2000)",
            //     maxLength: 2000,
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "nvarchar(max)",
            //     oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NghiemThuPhuLucHopDong",
                table: "NghiemThuPhuLucHopDong",
                columns: new[] { "NghiemThuId", "PhuLucHopDongId" });

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK_CANBO",
            //     table: "CANBO",
            //     column: "CanBoID");

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK_CANBO_DONVI",
            //     table: "CANBO_DONVI",
            //     column: "CanBoDonViID");

            // migrationBuilder.CreateTable(
            //     name: "DM_DUONG",
            //     columns: table => new
            //     {
            //         DuongID = table.Column<long>(type: "bigint", nullable: false),
            //         TenVietTat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //         TenDuong = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
            //         MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
            //         Used = table.Column<bool>(type: "bit", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //     });

            // migrationBuilder.CreateTable(
            //     name: "DM_PHUONGXA",
            //     columns: table => new
            //     {
            //         PhuongXaID = table.Column<long>(type: "bigint", nullable: false),
            //         MaPhuongXa = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
            //         TenPhuongXa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //         QuanHuyenID = table.Column<long>(type: "bigint", nullable: true),
            //         MoTa = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
            //         Used = table.Column<bool>(type: "bit", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //     });

            // migrationBuilder.CreateTable(
            //     name: "DM_QUANHUYEN",
            //     columns: table => new
            //     {
            //         QuanHuyenID = table.Column<long>(type: "bigint", nullable: false),
            //         MaQuanHuyen = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
            //         TenQuanHuyen = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //         TinhThanhID = table.Column<long>(type: "bigint", nullable: true),
            //         MoTa = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
            //         Used = table.Column<bool>(type: "bit", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //     });

            // migrationBuilder.CreateTable(
            //     name: "DM_TINHTHANH",
            //     columns: table => new
            //     {
            //         TinhThanhID = table.Column<long>(type: "bigint", nullable: false),
            //         QuocGiaID = table.Column<long>(type: "bigint", nullable: false),
            //         MaTinhThanh = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
            //         TenTinhThanh = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //         MoTa = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
            //         Used = table.Column<bool>(type: "bit", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //     });

            // migrationBuilder.CreateTable(
            //     name: "DUONG_PHUONG_QUAN",
            //     columns: table => new
            //     {
            //         DuongPhuongQuanID = table.Column<long>(type: "bigint", nullable: false),
            //         DuongID = table.Column<long>(type: "bigint", nullable: true),
            //         PhuongXaID = table.Column<long>(type: "bigint", nullable: true),
            //         QuanHuyenID = table.Column<long>(type: "bigint", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //     });

            // migrationBuilder.CreateTable(
            //     name: "E_CAPDONVI",
            //     columns: table => new
            //     {
            //         CapDonViID = table.Column<long>(type: "bigint", nullable: false),
            //         TenCapDonVi = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
            //         MoTa = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
            //         ThuTuHienThi = table.Column<int>(type: "int", nullable: true),
            //         Used = table.Column<bool>(type: "bit", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_E_CAPDONVI", x => x.CapDonViID);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "E_VAITROCHUCVU",
            //     columns: table => new
            //     {
            //         VaiTro = table.Column<int>(type: "int", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         ChucVu = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //         Cap = table.Column<int>(type: "int", nullable: true),
            //         Used = table.Column<bool>(type: "bit", nullable: true),
            //         MoTa = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_E_VAITROCHUCVU", x => x.VaiTro);
            //     });

            // migrationBuilder.AddForeignKey(
            //     name: "FK_CANBO_DONVI_CANBO_CanBoID",
            //     table: "CANBO_DONVI",
            //     column: "CanBoID",
            //     principalTable: "CANBO",
            //     principalColumn: "CanBoID");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_CANBO_DONVI_DM_DONVI_DonViID",
            //     table: "CANBO_DONVI",
            //     column: "DonViID",
            //     principalTable: "DM_DONVI",
            //     principalColumn: "DonViID");

            migrationBuilder.AddForeignKey(
                name: "FK_NghiemThuPhuLucHopDong_NghiemThu_NghiemThuId",
                table: "NghiemThuPhuLucHopDong",
                column: "NghiemThuId",
                principalTable: "NghiemThu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_CANBO_DONVI_CANBO_CanBoID",
            //     table: "CANBO_DONVI");

            // migrationBuilder.DropForeignKey(
            //     name: "FK_CANBO_DONVI_DM_DONVI_DonViID",
            //     table: "CANBO_DONVI");

            migrationBuilder.DropForeignKey(
                name: "FK_NghiemThuPhuLucHopDong_NghiemThu_NghiemThuId",
                table: "NghiemThuPhuLucHopDong");

            // migrationBuilder.DropTable(
            //     name: "DM_DUONG");

            // migrationBuilder.DropTable(
            //     name: "DM_PHUONGXA");

            // migrationBuilder.DropTable(
            //     name: "DM_QUANHUYEN");

            // migrationBuilder.DropTable(
            //     name: "DM_TINHTHANH");

            // migrationBuilder.DropTable(
            //     name: "DUONG_PHUONG_QUAN");

            // migrationBuilder.DropTable(
            //     name: "E_CAPDONVI");

            // migrationBuilder.DropTable(
            //     name: "E_VAITROCHUCVU");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NghiemThuPhuLucHopDong",
                table: "NghiemThuPhuLucHopDong");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK_CANBO",
            //     table: "CANBO");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK_CANBO_DONVI",
            //     table: "CANBO_DONVI");

            migrationBuilder.DropColumn(
                name: "NgayBaoLanh",
                table: "TamUng");

            migrationBuilder.DropColumn(
                name: "SoBaoLanh",
                table: "TamUng");

            migrationBuilder.DropColumn(
                name: "GiaTri",
                table: "NghiemThu");

            migrationBuilder.DropColumn(
                name: "SoQuyetDinh",
                table: "KetQuaTrungThau");

            migrationBuilder.DropColumn(
                name: "NamDuToan",
                table: "DuAn");

            migrationBuilder.DropColumn(
                name: "SoDuToan",
                table: "DuAn");

            migrationBuilder.DropColumn(
                name: "SoQuyetDinhDuToan",
                table: "DuAn");

            // migrationBuilder.RenameTable(
            //     name: "CANBO",
            //     newName: "CanBo");

            // migrationBuilder.RenameTable(
            //     name: "CANBO_DONVI",
            //     newName: "CanBoDonVi");

            migrationBuilder.RenameColumn(
                name: "NgayKetThucBaoLanh",
                table: "TamUng",
                newName: "UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "NgayQuyetDinh",
                table: "KetQuaTrungThau",
                newName: "UpdatedDateTime");

            migrationBuilder.RenameColumn(
                name: "NgayKyDuToan",
                table: "DuAn",
                newName: "UpdatedDateTime");

            // migrationBuilder.RenameColumn(
            //     name: "SoBHXH",
            //     table: "CanBo",
            //     newName: "SoBhxh");

            // migrationBuilder.RenameColumn(
            //     name: "ConNguoiID",
            //     table: "CanBo",
            //     newName: "ConNguoiId");

            // migrationBuilder.RenameColumn(
            //     name: "ChucDanhID",
            //     table: "CanBo",
            //     newName: "ChucDanhId");

            // migrationBuilder.RenameColumn(
            //     name: "CanBoID",
            //     table: "CanBo",
            //     newName: "Id");

            // migrationBuilder.RenameColumn(
            //     name: "DonViID",
            //     table: "CanBoDonVi",
            //     newName: "DonViId");

            // migrationBuilder.RenameColumn(
            //     name: "ChucVuID",
            //     table: "CanBoDonVi",
            //     newName: "ChucVuId");

            // migrationBuilder.RenameColumn(
            //     name: "CanBoID",
            //     table: "CanBoDonVi",
            //     newName: "CanBoId");

            // migrationBuilder.RenameColumn(
            //     name: "CanBoDonViID",
            //     table: "CanBoDonVi",
            //     newName: "Id");

            // migrationBuilder.RenameIndex(
            //     name: "IX_CANBO_DONVI_DonViID",
            //     table: "CanBoDonVi",
            //     newName: "IX_CanBoDonVi_DonViId");

            // migrationBuilder.RenameIndex(
            //     name: "IX_CANBO_DONVI_CanBoID",
            //     table: "CanBoDonVi",
            //     newName: "IX_CanBoDonVi_CanBoId");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "VanBanQuyetDinh",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "ThanhToan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "TepDinhKem",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "PhuLucHopDong",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "NghiemThuThanhToan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "NghiemThuPhuLucHopDong",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "NghiemThuPhuLucHopDong",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "NghiemThuPhuLucHopDong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "NghiemThuPhuLucHopDong",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "NghiemThuPhuLucHopDong",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "NghiemThuPhuLucHopDong",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "NghiemThuPhuLucHopDong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "NghiemThu",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "HoSoMoiThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "HopDong",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "GoiThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DuAnBuocManHinh",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DuAnBuoc",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmTrangThaiDuAn",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmTinhTrangKhoKhan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmQuyTrinh",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmNhomDuAn",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmNhaThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmNguonVon",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmMucDoKhoKhan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiVanBan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiHopDong",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiGoiThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiDuAnTheoNam",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiDuAn",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLinhVuc",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmHinhThucQuanLy",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmHinhThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmHinhThucDauTu",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmGiaiDoan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmChuDauTu",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmChucVu",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmBuocTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmBuocManHinh",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmBuoc",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DangTaiKeHoachLcntLenMang",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "ChiuTrachNhiemXuLy",
                type: "datetimeoffset",
                nullable: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "SoBhxh",
            //     table: "CanBo",
            //     type: "nvarchar(max)",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "nvarchar(20)",
            //     oldMaxLength: 20,
            //     oldNullable: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "NgheNghiep",
            //     table: "CanBo",
            //     type: "nvarchar(max)",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "nvarchar(2000)",
            //     oldMaxLength: 2000,
            //     oldNullable: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "MaSoCanBo",
            //     table: "CanBo",
            //     type: "nvarchar(max)",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "nvarchar(20)",
            //     oldMaxLength: 20,
            //     oldNullable: true);

            // migrationBuilder.AlterColumn<string>(
            //     name: "ChuyenMon",
            //     table: "CanBo",
            //     type: "nvarchar(max)",
            //     nullable: true,
            //     oldClrType: typeof(string),
            //     oldType: "nvarchar(2000)",
            //     oldMaxLength: 2000,
            //     oldNullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "BaoCao",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NghiemThuPhuLucHopDong",
                table: "NghiemThuPhuLucHopDong",
                column: "Id");

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK_CanBo",
            //     table: "CanBo",
            //     column: "Id");

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK_CanBoDonVi",
            //     table: "CanBoDonVi",
            //     column: "Id");

            migrationBuilder.UpdateData(
                table: "DmLoaiDuAnTheoNam",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "DmLoaiDuAnTheoNam",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "DmLoaiDuAnTheoNam",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "DmLoaiDuAnTheoNam",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "DmTrangThaiDuAn",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "DmTrangThaiDuAn",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "DmTrangThaiDuAn",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "DmTrangThaiDuAn",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedDateTime",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_NghiemThuPhuLucHopDong_NghiemThuId",
                table: "NghiemThuPhuLucHopDong",
                column: "NghiemThuId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_CanBoDonVi_CanBo_CanBoId",
            //     table: "CanBoDonVi",
            //     column: "CanBoId",
            //     principalTable: "CanBo",
            //     principalColumn: "Id");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_CanBoDonVi_DM_DONVI_DonViId",
            //     table: "CanBoDonVi",
            //     column: "DonViId",
            //     principalTable: "DM_DONVI",
            //     principalColumn: "DonViID");

            migrationBuilder.AddForeignKey(
                name: "FK_NghiemThuPhuLucHopDong_NghiemThu_NghiemThuId",
                table: "NghiemThuPhuLucHopDong",
                column: "NghiemThuId",
                principalTable: "NghiemThu",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
