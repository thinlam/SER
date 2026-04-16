using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLHD.Migrator.Migrations.dbo
{
    /// <inheritdoc />
    public partial class AddDanhMucLoaiLai : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<int>(
                name: "NguoiTheoDoiId",
                table: "DuAn",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GiamDocId",
                table: "DuAn",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiLai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucLoaiLai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DuAn_ThuTien_Version",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    KeHoachThangId = table.Column<int>(type: "int", nullable: false),
                    SourceEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThanhToanId = table.Column<int>(type: "int", nullable: false),
                    GhiChuKeHoach = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ThoiGianKeHoach = table.Column<DateOnly>(type: "date", nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    GiaTriKeHoach = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAn_ThuTien_Version", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAn_ThuTien_Version_DanhMucLoaiThanhToan_LoaiThanhToanId",
                        column: x => x.LoaiThanhToanId,
                        principalTable: "DanhMucLoaiThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_ThuTien_Version_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_ThuTien_Version_DuAn_ThuTien_SourceEntityId",
                        column: x => x.SourceEntityId,
                        principalTable: "DuAn_ThuTien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_ThuTien_Version_KeHoachThang_KeHoachThangId",
                        column: x => x.KeHoachThangId,
                        principalTable: "KeHoachThang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DuAn_XuatHoaDon_Version",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    KeHoachThangId = table.Column<int>(type: "int", nullable: false),
                    SourceEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThanhToanId = table.Column<int>(type: "int", nullable: false),
                    GhiChuKeHoach = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ThoiGianKeHoach = table.Column<DateOnly>(type: "date", nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    GiaTriKeHoach = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAn_XuatHoaDon_Version", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAn_XuatHoaDon_Version_DanhMucLoaiThanhToan_LoaiThanhToanId",
                        column: x => x.LoaiThanhToanId,
                        principalTable: "DanhMucLoaiThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_XuatHoaDon_Version_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_XuatHoaDon_Version_DuAn_XuatHoaDon_SourceEntityId",
                        column: x => x.SourceEntityId,
                        principalTable: "DuAn_XuatHoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_XuatHoaDon_Version_KeHoachThang_KeHoachThangId",
                        column: x => x.KeHoachThangId,
                        principalTable: "KeHoachThang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_ChiPhi_Version",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    KeHoachThangId = table.Column<int>(type: "int", nullable: false),
                    SourceEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiChiPhiId = table.Column<int>(type: "int", nullable: false),
                    Nam = table.Column<short>(type: "smallint", nullable: false),
                    LanChi = table.Column<byte>(type: "tinyint", nullable: false),
                    GhiChuKeHoach = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ThoiGianKeHoach = table.Column<DateOnly>(type: "date", nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    GiaTriKeHoach = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_ChiPhi_Version", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_ChiPhi_Version_DanhMucLoaiChiPhi_LoaiChiPhiId",
                        column: x => x.LoaiChiPhiId,
                        principalTable: "DanhMucLoaiChiPhi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_ChiPhi_Version_HopDong_ChiPhi_SourceEntityId",
                        column: x => x.SourceEntityId,
                        principalTable: "HopDong_ChiPhi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_ChiPhi_Version_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_ChiPhi_Version_KeHoachThang_KeHoachThangId",
                        column: x => x.KeHoachThangId,
                        principalTable: "KeHoachThang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_ThuTien_Version",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    KeHoachThangId = table.Column<int>(type: "int", nullable: false),
                    SourceEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThanhToanId = table.Column<int>(type: "int", nullable: false),
                    GhiChuKeHoach = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ThoiGianKeHoach = table.Column<DateOnly>(type: "date", nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    GiaTriKeHoach = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_ThuTien_Version", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_ThuTien_Version_DanhMucLoaiThanhToan_LoaiThanhToanId",
                        column: x => x.LoaiThanhToanId,
                        principalTable: "DanhMucLoaiThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_ThuTien_Version_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_ThuTien_Version_HopDong_ThuTien_SourceEntityId",
                        column: x => x.SourceEntityId,
                        principalTable: "HopDong_ThuTien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_ThuTien_Version_KeHoachThang_KeHoachThangId",
                        column: x => x.KeHoachThangId,
                        principalTable: "KeHoachThang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_XuatHoaDon_Version",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    KeHoachThangId = table.Column<int>(type: "int", nullable: false),
                    SourceEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThanhToanId = table.Column<int>(type: "int", nullable: false),
                    GhiChuKeHoach = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    ThoiGianKeHoach = table.Column<DateOnly>(type: "date", nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    GiaTriKeHoach = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_XuatHoaDon_Version", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_XuatHoaDon_Version_DanhMucLoaiThanhToan_LoaiThanhToanId",
                        column: x => x.LoaiThanhToanId,
                        principalTable: "DanhMucLoaiThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_XuatHoaDon_Version_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_XuatHoaDon_Version_HopDong_XuatHoaDon_SourceEntityId",
                        column: x => x.SourceEntityId,
                        principalTable: "HopDong_XuatHoaDon",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_XuatHoaDon_Version_KeHoachThang_KeHoachThangId",
                        column: x => x.KeHoachThangId,
                        principalTable: "KeHoachThang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiLai_Index",
                table: "DanhMucLoaiLai",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiLai_IsDefault",
                table: "DanhMucLoaiLai",
                column: "IsDefault",
                unique: true,
                filter: "[IsDefault] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiLai_Ma",
                table: "DanhMucLoaiLai",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_ThuTien_Version_DuAnId",
                table: "DuAn_ThuTien_Version",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_ThuTien_Version_Index",
                table: "DuAn_ThuTien_Version",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_ThuTien_Version_KeHoachThangId",
                table: "DuAn_ThuTien_Version",
                column: "KeHoachThangId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_ThuTien_Version_LoaiThanhToanId",
                table: "DuAn_ThuTien_Version",
                column: "LoaiThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_ThuTien_Version_SourceEntityId",
                table: "DuAn_ThuTien_Version",
                column: "SourceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_XuatHoaDon_Version_DuAnId",
                table: "DuAn_XuatHoaDon_Version",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_XuatHoaDon_Version_Index",
                table: "DuAn_XuatHoaDon_Version",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_XuatHoaDon_Version_KeHoachThangId",
                table: "DuAn_XuatHoaDon_Version",
                column: "KeHoachThangId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_XuatHoaDon_Version_LoaiThanhToanId",
                table: "DuAn_XuatHoaDon_Version",
                column: "LoaiThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_XuatHoaDon_Version_SourceEntityId",
                table: "DuAn_XuatHoaDon_Version",
                column: "SourceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ChiPhi_Version_HopDongId",
                table: "HopDong_ChiPhi_Version",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ChiPhi_Version_Index",
                table: "HopDong_ChiPhi_Version",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ChiPhi_Version_KeHoachThangId",
                table: "HopDong_ChiPhi_Version",
                column: "KeHoachThangId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ChiPhi_Version_LoaiChiPhiId",
                table: "HopDong_ChiPhi_Version",
                column: "LoaiChiPhiId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ChiPhi_Version_SourceEntityId",
                table: "HopDong_ChiPhi_Version",
                column: "SourceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ThuTien_Version_HopDongId",
                table: "HopDong_ThuTien_Version",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ThuTien_Version_Index",
                table: "HopDong_ThuTien_Version",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ThuTien_Version_KeHoachThangId",
                table: "HopDong_ThuTien_Version",
                column: "KeHoachThangId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ThuTien_Version_LoaiThanhToanId",
                table: "HopDong_ThuTien_Version",
                column: "LoaiThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ThuTien_Version_SourceEntityId",
                table: "HopDong_ThuTien_Version",
                column: "SourceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_XuatHoaDon_Version_HopDongId",
                table: "HopDong_XuatHoaDon_Version",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_XuatHoaDon_Version_Index",
                table: "HopDong_XuatHoaDon_Version",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_XuatHoaDon_Version_KeHoachThangId",
                table: "HopDong_XuatHoaDon_Version",
                column: "KeHoachThangId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_XuatHoaDon_Version_LoaiThanhToanId",
                table: "HopDong_XuatHoaDon_Version",
                column: "LoaiThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_XuatHoaDon_Version_SourceEntityId",
                table: "HopDong_XuatHoaDon_Version",
                column: "SourceEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DanhMucLoaiLai");

            migrationBuilder.DropTable(
                name: "DuAn_ThuTien_Version");

            migrationBuilder.DropTable(
                name: "DuAn_XuatHoaDon_Version");

            migrationBuilder.DropTable(
                name: "HopDong_ChiPhi_Version");

            migrationBuilder.DropTable(
                name: "HopDong_ThuTien_Version");

            migrationBuilder.DropTable(
                name: "HopDong_XuatHoaDon_Version");

            migrationBuilder.AlterColumn<int>(
                name: "NguoiPhuTrachChinhId",
                table: "HopDong",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

        }
    }
}
