using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class RefactorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DuAnBuocManHinh",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmTrangThaiTienDo",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmTrangThaiDuAn",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmTinhTrangKhoKhan",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmQuyTrinh",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmPhuongThucLuaChonNhaThau",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmNhomDuAn",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmNhaThau",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmNguonVon",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmMucDoKhoKhan",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmLoaiVanBan",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmLoaiHopDong",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmLoaiGoiThau",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmLoaiDuAnTheoNam",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmLoaiDuAn",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmLinhVuc",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmHinhThucQuanLy",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmHinhThucLuaChonNhaThau",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmHinhThucDauTu",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmGiaiDoan",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmChuDauTu",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmChucVu",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmBuocTrangThaiTienDo",
                newName: "MoTa");

            migrationBuilder.RenameColumn(
                name: "Mota",
                table: "DmBuoc",
                newName: "MoTa");

            // migrationBuilder.AlterColumn<long>(
            //     name: "User_MasterID",
            //     table: "USER_MASTER",
            //     type: "bigint",
            //     nullable: false,
            //     oldClrType: typeof(long),
            //     oldType: "bigint")
            //     .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Ma",
                table: "E_ManHinh",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "E_LoaiVanBanQuyetDinh",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ma",
                table: "E_LoaiVanBanQuyetDinh",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "DuAn",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            // migrationBuilder.AddPrimaryKey(
            //     name: "PK__USER_MAS__CA9BC5E270CE69C2",
            //     table: "USER_MASTER",
            //     column: "User_MasterID");

            // migrationBuilder.CreateTable(
            //     name: "CanBo",
            //     columns: table => new
            //     {
            //         Id = table.Column<long>(type: "bigint", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         NgheNghiep = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         MaSoCanBo = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         SoBhxh = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ConNguoiId = table.Column<long>(type: "bigint", nullable: true),
            //         ChuyenMon = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //         ChucDanhId = table.Column<long>(type: "bigint", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_CanBo", x => x.Id);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "DM_DONVI",
            //     columns: table => new
            //     {
            //         DonViID = table.Column<long>(type: "bigint", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         MaDonVi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
            //         TenDonVi = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
            //         TenVietTat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //         DonViCapChaID = table.Column<long>(type: "bigint", nullable: true),
            //         Cap = table.Column<int>(type: "int", nullable: true),
            //         CapDonViID = table.Column<long>(type: "bigint", nullable: true),
            //         LoaiDonViID = table.Column<long>(type: "bigint", nullable: true),
            //         SoNha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //         DuongID = table.Column<long>(type: "bigint", nullable: true),
            //         TinhThanhID = table.Column<long>(type: "bigint", nullable: true),
            //         QuanHuyenID = table.Column<long>(type: "bigint", nullable: true),
            //         PhuongXaID = table.Column<long>(type: "bigint", nullable: true),
            //         DiaChiDayDu = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
            //         DienThoai = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //         Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
            //         Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //         Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
            //         MoTa = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
            //         Used = table.Column<bool>(type: "bit", nullable: true),
            //         Latitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
            //         Longitude = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK__DM_DONVI__1CB88576D84B4D4C", x => x.DonViID)
            //             .Annotation("SqlServer:Clustered", false);
            //     });

            // migrationBuilder.CreateTable(
            //     name: "CanBoDonVi",
            //     columns: table => new
            //     {
            //         Id = table.Column<long>(type: "bigint", nullable: false)
            //             .Annotation("SqlServer:Identity", "1, 1"),
            //         CanBoId = table.Column<long>(type: "bigint", nullable: true),
            //         DonViId = table.Column<long>(type: "bigint", nullable: true),
            //         ChucVuId = table.Column<long>(type: "bigint", nullable: true),
            //         LaChucVuChinh = table.Column<bool>(type: "bit", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_CanBoDonVi", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_CanBoDonVi_CanBo_CanBoId",
            //             column: x => x.CanBoId,
            //             principalTable: "CanBo",
            //             principalColumn: "Id");
            //             table.ForeignKey(
            //                 name: "FK_CanBoDonVi_DM_DONVI_DonViId",
            //                 column: x => x.DonViId,
            //                 principalTable: "DM_DONVI",
            //                 principalColumn: "DonViID");
            //     });

            // migrationBuilder.CreateIndex(
            //     name: "IDX_USER_MASTER_01",
            //     table: "USER_MASTER",
            //     columns: new[] { "DonViID", "User_PortalID", "Used" });

            // migrationBuilder.CreateIndex(
            //     name: "IDX_USER_MASTER_02",
            //     table: "USER_MASTER",
            //     column: "User_PortalID");

            // migrationBuilder.CreateIndex(
            //     name: "IDX_USER_MASTER_03",
            //     table: "USER_MASTER",
            //     columns: new[] { "PhongBanID", "DonViID", "User_PortalID" });

            // migrationBuilder.CreateIndex(
            //     name: "IDX_USER_MASTER_04",
            //     table: "USER_MASTER",
            //     columns: new[] { "DonViID", "User_PortalID" });

            // migrationBuilder.CreateIndex(
            //     name: "IDX_USER_MASTER_05",
            //     table: "USER_MASTER",
            //     column: "User_PortalID");

            // migrationBuilder.CreateIndex(
            //     name: "IDX_USER_MASTER_06",
            //     table: "USER_MASTER",
            //     column: "DonViID");

            // migrationBuilder.CreateIndex(
            //     name: "IDX_USER_MASTER_07",
            //     table: "USER_MASTER",
            //     columns: new[] { "DonViID", "User_PortalID" });

            // migrationBuilder.CreateIndex(
            //     name: "IX_USER_MASTER_122_121",
            //     table: "USER_MASTER",
            //     column: "Used");

            // migrationBuilder.CreateIndex(
            //     name: "IX_USER_MASTER_CanBoID_Used",
            //     table: "USER_MASTER",
            //     columns: new[] { "CanBoID", "Used" });

            migrationBuilder.CreateIndex(
                name: "IX_E_ManHinh_Ma",
                table: "E_ManHinh",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_E_LoaiVanBanQuyetDinh_Ma",
                table: "E_LoaiVanBanQuyetDinh",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocManHinh_Ma",
                table: "DuAnBuocManHinh",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmTrangThaiTienDo_Ma",
                table: "DmTrangThaiTienDo",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmTrangThaiDuAn_Ma",
                table: "DmTrangThaiDuAn",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmTinhTrangKhoKhan_Ma",
                table: "DmTinhTrangKhoKhan",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmQuyTrinh_Ma",
                table: "DmQuyTrinh",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmPhuongThucLuaChonNhaThau_Ma",
                table: "DmPhuongThucLuaChonNhaThau",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmNhomDuAn_Ma",
                table: "DmNhomDuAn",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmNhaThau_Ma",
                table: "DmNhaThau",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmNguonVon_Ma",
                table: "DmNguonVon",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmMucDoKhoKhan_Ma",
                table: "DmMucDoKhoKhan",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmLoaiVanBan_Ma",
                table: "DmLoaiVanBan",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmLoaiHopDong_Ma",
                table: "DmLoaiHopDong",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmLoaiGoiThau_Ma",
                table: "DmLoaiGoiThau",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmLoaiDuAnTheoNam_Ma",
                table: "DmLoaiDuAnTheoNam",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmLoaiDuAn_Ma",
                table: "DmLoaiDuAn",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmLinhVuc_Ma",
                table: "DmLinhVuc",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmHinhThucQuanLy_Ma",
                table: "DmHinhThucQuanLy",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmHinhThucLuaChonNhaThau_Ma",
                table: "DmHinhThucLuaChonNhaThau",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmHinhThucDauTu_Ma",
                table: "DmHinhThucDauTu",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmGiaiDoan_Ma",
                table: "DmGiaiDoan",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmChuDauTu_Ma",
                table: "DmChuDauTu",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmChucVu_Ma",
                table: "DmChucVu",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmBuocTrangThaiTienDo_Ma",
                table: "DmBuocTrangThaiTienDo",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DmBuoc_Ma",
                table: "DmBuoc",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");

            // migrationBuilder.CreateIndex(
            //     name: "IX_CanBoDonVi_CanBoId",
            //     table: "CanBoDonVi",
            //     column: "CanBoId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_CanBoDonVi_DonViId",
            //     table: "CanBoDonVi",
            //     column: "DonViId");

            // migrationBuilder.CreateIndex(
            //     name: "IDX_DM_DONVI_01",
            //     table: "DM_DONVI",
            //     column: "DonViCapChaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "CanBoDonVi");

            // migrationBuilder.DropTable(
            //     name: "CanBo");

            // migrationBuilder.DropTable(
            //     name: "DM_DONVI");

            // migrationBuilder.DropPrimaryKey(
            //     name: "PK__USER_MAS__CA9BC5E270CE69C2",
            //     table: "USER_MASTER");

            // migrationBuilder.DropIndex(
            //     name: "IDX_USER_MASTER_01",
            //     table: "USER_MASTER");

            // migrationBuilder.DropIndex(
            //     name: "IDX_USER_MASTER_02",
            //     table: "USER_MASTER");

            // migrationBuilder.DropIndex(
            //     name: "IDX_USER_MASTER_03",
            //     table: "USER_MASTER");

            // migrationBuilder.DropIndex(
            //     name: "IDX_USER_MASTER_04",
            //     table: "USER_MASTER");

            // migrationBuilder.DropIndex(
            //     name: "IDX_USER_MASTER_05",
            //     table: "USER_MASTER");

            // migrationBuilder.DropIndex(
            //     name: "IDX_USER_MASTER_06",
            //     table: "USER_MASTER");

            // migrationBuilder.DropIndex(
            //     name: "IDX_USER_MASTER_07",
            //     table: "USER_MASTER");

            // migrationBuilder.DropIndex(
            //     name: "IX_USER_MASTER_122_121",
            //     table: "USER_MASTER");

            // migrationBuilder.DropIndex(
            //     name: "IX_USER_MASTER_CanBoID_Used",
            //     table: "USER_MASTER");

            migrationBuilder.DropIndex(
                name: "IX_E_ManHinh_Ma",
                table: "E_ManHinh");

            migrationBuilder.DropIndex(
                name: "IX_E_LoaiVanBanQuyetDinh_Ma",
                table: "E_LoaiVanBanQuyetDinh");

            migrationBuilder.DropIndex(
                name: "IX_DuAnBuocManHinh_Ma",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropIndex(
                name: "IX_DmTrangThaiTienDo_Ma",
                table: "DmTrangThaiTienDo");

            migrationBuilder.DropIndex(
                name: "IX_DmTrangThaiDuAn_Ma",
                table: "DmTrangThaiDuAn");

            migrationBuilder.DropIndex(
                name: "IX_DmTinhTrangKhoKhan_Ma",
                table: "DmTinhTrangKhoKhan");

            migrationBuilder.DropIndex(
                name: "IX_DmQuyTrinh_Ma",
                table: "DmQuyTrinh");

            migrationBuilder.DropIndex(
                name: "IX_DmPhuongThucLuaChonNhaThau_Ma",
                table: "DmPhuongThucLuaChonNhaThau");

            migrationBuilder.DropIndex(
                name: "IX_DmNhomDuAn_Ma",
                table: "DmNhomDuAn");

            migrationBuilder.DropIndex(
                name: "IX_DmNhaThau_Ma",
                table: "DmNhaThau");

            migrationBuilder.DropIndex(
                name: "IX_DmNguonVon_Ma",
                table: "DmNguonVon");

            migrationBuilder.DropIndex(
                name: "IX_DmMucDoKhoKhan_Ma",
                table: "DmMucDoKhoKhan");

            migrationBuilder.DropIndex(
                name: "IX_DmLoaiVanBan_Ma",
                table: "DmLoaiVanBan");

            migrationBuilder.DropIndex(
                name: "IX_DmLoaiHopDong_Ma",
                table: "DmLoaiHopDong");

            migrationBuilder.DropIndex(
                name: "IX_DmLoaiGoiThau_Ma",
                table: "DmLoaiGoiThau");

            migrationBuilder.DropIndex(
                name: "IX_DmLoaiDuAnTheoNam_Ma",
                table: "DmLoaiDuAnTheoNam");

            migrationBuilder.DropIndex(
                name: "IX_DmLoaiDuAn_Ma",
                table: "DmLoaiDuAn");

            migrationBuilder.DropIndex(
                name: "IX_DmLinhVuc_Ma",
                table: "DmLinhVuc");

            migrationBuilder.DropIndex(
                name: "IX_DmHinhThucQuanLy_Ma",
                table: "DmHinhThucQuanLy");

            migrationBuilder.DropIndex(
                name: "IX_DmHinhThucLuaChonNhaThau_Ma",
                table: "DmHinhThucLuaChonNhaThau");

            migrationBuilder.DropIndex(
                name: "IX_DmHinhThucDauTu_Ma",
                table: "DmHinhThucDauTu");

            migrationBuilder.DropIndex(
                name: "IX_DmGiaiDoan_Ma",
                table: "DmGiaiDoan");

            migrationBuilder.DropIndex(
                name: "IX_DmChuDauTu_Ma",
                table: "DmChuDauTu");

            migrationBuilder.DropIndex(
                name: "IX_DmChucVu_Ma",
                table: "DmChucVu");

            migrationBuilder.DropIndex(
                name: "IX_DmBuocTrangThaiTienDo_Ma",
                table: "DmBuocTrangThaiTienDo");

            migrationBuilder.DropIndex(
                name: "IX_DmBuoc_Ma",
                table: "DmBuoc");

            migrationBuilder.DropColumn(
                name: "Ma",
                table: "E_ManHinh");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DuAnBuocManHinh",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmTrangThaiTienDo",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmTrangThaiDuAn",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmTinhTrangKhoKhan",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmQuyTrinh",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmPhuongThucLuaChonNhaThau",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmNhomDuAn",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmNhaThau",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmNguonVon",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmMucDoKhoKhan",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmLoaiVanBan",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmLoaiHopDong",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmLoaiGoiThau",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmLoaiDuAnTheoNam",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmLoaiDuAn",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmLinhVuc",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmHinhThucQuanLy",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmHinhThucLuaChonNhaThau",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmHinhThucDauTu",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmGiaiDoan",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmChuDauTu",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmChucVu",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmBuocTrangThaiTienDo",
                newName: "Mota");

            migrationBuilder.RenameColumn(
                name: "MoTa",
                table: "DmBuoc",
                newName: "Mota");

            // migrationBuilder.AlterColumn<long>(
            //     name: "User_MasterID",
            //     table: "USER_MASTER",
            //     type: "bigint",
            //     nullable: false,
            //     oldClrType: typeof(long),
            //     oldType: "bigint")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Ten",
                table: "E_LoaiVanBanQuyetDinh",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ma",
                table: "E_LoaiVanBanQuyetDinh",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "DuAn",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }
    }
}
