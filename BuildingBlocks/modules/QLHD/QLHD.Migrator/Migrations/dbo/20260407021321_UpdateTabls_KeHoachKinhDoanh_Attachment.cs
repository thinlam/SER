using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLHD.Migrator.Migrations.dbo {
    /// <inheritdoc />
    public partial class UpdateTabls_KeHoachKinhDoanh_Attachment : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "HopDong_XuatHoaDon");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "HopDong_ThuTien");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "DuAn_XuatHoaDon");

            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "DuAn_ThuTien");

            migrationBuilder.AddColumn<string>(
                name: "GhiChuKeHoach",
                table: "HopDong_XuatHoaDon",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuThucTe",
                table: "HopDong_XuatHoaDon",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuKeHoach",
                table: "HopDong_ThuTien",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuThucTe",
                table: "HopDong_ThuTien",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "LanChi",
                table: "HopDong_ChiPhi",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "Nam",
                table: "HopDong_ChiPhi",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "HopDong",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuKeHoach",
                table: "DuAn_XuatHoaDon",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuThucTe",
                table: "DuAn_XuatHoaDon",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuKeHoach",
                table: "DuAn_ThuTien",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChuThucTe",
                table: "DuAn_ThuTien",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "DuAn",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "BaoCaoTienDo",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table => {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeHoachKinhDoanhNam",
                columns: table => new {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    BatDau = table.Column<DateOnly>(type: "date", nullable: false),
                    KetThuc = table.Column<DateOnly>(type: "date", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table => {
                    table.PrimaryKey("PK_KeHoachKinhDoanhNam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeHoachThang",
                columns: table => new {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TuNgay = table.Column<DateOnly>(type: "date", nullable: false),
                    DenNgay = table.Column<DateOnly>(type: "date", nullable: false),
                    TuThangDisplay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DenThangDisplay = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table => {
                    table.PrimaryKey("PK_KeHoachThang", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeHoachKinhDoanhNam_BoPhan",
                columns: table => new {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    KeHoachKinhDoanhNamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DonViId = table.Column<long>(type: "bigint", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DoanhKySo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LaiGopKy = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DoanhSoXuatHoaDon = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LaiGopXuatHoaDon = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ThuTien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LaiGopThuTien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ChiPhiTrucTiep = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ChiPhiPhanBo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LoiNhuan = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table => {
                    table.PrimaryKey("PK_KeHoachKinhDoanhNam_BoPhan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeHoachKinhDoanhNam_BoPhan_KeHoachKinhDoanhNam_KeHoachKinhDoanhNamId",
                        column: x => x.KeHoachKinhDoanhNamId,
                        principalTable: "KeHoachKinhDoanhNam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeHoachKinhDoanhNam_CaNhan",
                columns: table => new {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    KeHoachKinhDoanhNamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserPortalId = table.Column<long>(type: "bigint", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DoanhKySo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LaiGopKy = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    DoanhSoXuatHoaDon = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LaiGopXuatHoaDon = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ThuTien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LaiGopThuTien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ChiPhiTrucTiep = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ChiPhiPhanBo = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LoiNhuan = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table => {
                    table.PrimaryKey("PK_KeHoachKinhDoanhNam_CaNhan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeHoachKinhDoanhNam_CaNhan_KeHoachKinhDoanhNam_KeHoachKinhDoanhNamId",
                        column: x => x.KeHoachKinhDoanhNamId,
                        principalTable: "KeHoachKinhDoanhNam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_Index",
                table: "Attachments",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachKinhDoanhNam_Index",
                table: "KeHoachKinhDoanhNam",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachKinhDoanhNam_BoPhan_Index",
                table: "KeHoachKinhDoanhNam_BoPhan",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachKinhDoanhNam_BoPhan_KeHoachKinhDoanhNamId",
                table: "KeHoachKinhDoanhNam_BoPhan",
                column: "KeHoachKinhDoanhNamId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachKinhDoanhNam_CaNhan_Index",
                table: "KeHoachKinhDoanhNam_CaNhan",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachKinhDoanhNam_CaNhan_KeHoachKinhDoanhNamId",
                table: "KeHoachKinhDoanhNam_CaNhan",
                column: "KeHoachKinhDoanhNamId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachThang_DenNgay",
                table: "KeHoachThang",
                column: "DenNgay");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachThang_Index",
                table: "KeHoachThang",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachThang_TuNgay",
                table: "KeHoachThang",
                column: "TuNgay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Attachments");

            migrationBuilder.DropTable(
                name: "KeHoachKinhDoanhNam_BoPhan");

            migrationBuilder.DropTable(
                name: "KeHoachKinhDoanhNam_CaNhan");

            migrationBuilder.DropTable(
                name: "KeHoachThang");

            migrationBuilder.DropTable(
                name: "KeHoachKinhDoanhNam");

            migrationBuilder.DropColumn(
                name: "GhiChuKeHoach",
                table: "HopDong_XuatHoaDon");

            migrationBuilder.DropColumn(
                name: "GhiChuThucTe",
                table: "HopDong_XuatHoaDon");

            migrationBuilder.DropColumn(
                name: "GhiChuKeHoach",
                table: "HopDong_ThuTien");

            migrationBuilder.DropColumn(
                name: "GhiChuThucTe",
                table: "HopDong_ThuTien");

            migrationBuilder.DropColumn(
                name: "LanChi",
                table: "HopDong_ChiPhi");

            migrationBuilder.DropColumn(
                name: "Nam",
                table: "HopDong_ChiPhi");

            migrationBuilder.DropColumn(
                name: "GhiChuKeHoach",
                table: "DuAn_XuatHoaDon");

            migrationBuilder.DropColumn(
                name: "GhiChuThucTe",
                table: "DuAn_XuatHoaDon");

            migrationBuilder.DropColumn(
                name: "GhiChuKeHoach",
                table: "DuAn_ThuTien");

            migrationBuilder.DropColumn(
                name: "GhiChuThucTe",
                table: "DuAn_ThuTien");

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "HopDong_XuatHoaDon",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "HopDong_ThuTien",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "DuAn_XuatHoaDon",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "DuAn_ThuTien",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "DuAn",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "BaoCaoTienDo",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);
        }
    }
}
