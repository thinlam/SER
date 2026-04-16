using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QLHD.Migrator.Migrations.dbo
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    EntityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EntityId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OldValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NewValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentValues = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedColumns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucGiamDoc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    UserPortalId = table.Column<long>(type: "bigint", nullable: false),
                    DonViId = table.Column<long>(type: "bigint", nullable: false),
                    PhongBanId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucGiamDoc", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiChiPhi",
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
                    table.PrimaryKey("PK_DanhMucLoaiChiPhi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiHopDong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Prefix = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
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
                    table.PrimaryKey("PK_DanhMucLoaiHopDong", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiThanhToan",
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
                    table.PrimaryKey("PK_DanhMucLoaiThanhToan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucLoaiTrangThai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucLoaiTrangThai", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNguoiPhuTrach",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    UserPortalId = table.Column<long>(type: "bigint", nullable: false),
                    DonViId = table.Column<long>(type: "bigint", nullable: false),
                    PhongBanId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucNguoiPhuTrach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucNguoiTheoDoi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    UserPortalId = table.Column<long>(type: "bigint", nullable: false),
                    DonViId = table.Column<long>(type: "bigint", nullable: false),
                    PhongBanId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DanhMucNguoiTheoDoi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoanhNghiep",
                columns: table => new
                {
                    TaxCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TenTiengAnh = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TaxAuthorityId = table.Column<int>(type: "int", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AddressVN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AddressEN = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BankAccount = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AccountHolder = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    BankName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsLogo = table.Column<bool>(type: "bit", nullable: false),
                    LogoFileName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    AuthorizeVolume = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AuthorizeLic = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AuthorizeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Version = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoanhNghiep", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSession",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Platform = table.Column<int>(type: "int", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RefreshTokenExpiresAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    IsRemembered = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastActivityAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    IpAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    UserInfoJson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAuthInfoJson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSession", x => x.SessionId);
                });

            migrationBuilder.CreateTable(
                name: "DanhMucTrangThai",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    LoaiTrangThaiId = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    MaLoaiTrangThai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true, defaultValue: ""),
                    TenLoaiTrangThai = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true, defaultValue: ""),
                    ThuTu = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
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
                    table.PrimaryKey("PK_DanhMucTrangThai", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DanhMucTrangThai_DanhMucLoaiTrangThai_LoaiTrangThaiId",
                        column: x => x.LoaiTrangThaiId,
                        principalTable: "DanhMucLoaiTrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsPersonal = table.Column<bool>(type: "bit", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    DistrictName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CountryName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    Used = table.Column<bool>(type: "bit", nullable: false),
                    DonViId = table.Column<long>(type: "bigint", nullable: true),
                    DoanhNghiepId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhachHang_DoanhNghiep_DoanhNghiepId",
                        column: x => x.DoanhNghiepId,
                        principalTable: "DoanhNghiep",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DuAn",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    Ten = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayLap = table.Column<DateOnly>(type: "date", nullable: false),
                    GiaTriDuKien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ThoiGianDuKien = table.Column<DateOnly>(type: "date", nullable: true),
                    PhongBanPhuTrachChinhId = table.Column<long>(type: "bigint", nullable: false),
                    NguoiPhuTrachChinhId = table.Column<int>(type: "int", nullable: false),
                    NguoiTheoDoiId = table.Column<int>(type: "int", nullable: false),
                    GiamDocId = table.Column<int>(type: "int", nullable: false),
                    GiaVon = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false),
                    HasHopDong = table.Column<bool>(type: "bit", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAn_DanhMucGiamDoc_GiamDocId",
                        column: x => x.GiamDocId,
                        principalTable: "DanhMucGiamDoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_DanhMucNguoiPhuTrach_NguoiPhuTrachChinhId",
                        column: x => x.NguoiPhuTrachChinhId,
                        principalTable: "DanhMucNguoiPhuTrach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_DanhMucNguoiTheoDoi_NguoiTheoDoiId",
                        column: x => x.NguoiTheoDoiId,
                        principalTable: "DanhMucNguoiTheoDoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_DanhMucTrangThai_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "DanhMucTrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_KhachHang_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CongViec",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ThoiGian = table.Column<DateOnly>(type: "date", nullable: false),
                    UserPortalId = table.Column<long>(type: "bigint", nullable: false),
                    NguoiThucHien = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DonViId = table.Column<long>(type: "bigint", nullable: false),
                    TenDonVi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhongBanId = table.Column<long>(type: "bigint", nullable: true),
                    TenPhongBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeHoachCongViec = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    NgayHoanThanh = table.Column<DateOnly>(type: "date", nullable: true),
                    ThucTe = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false),
                    TenTrangThai = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CongViec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CongViec_DanhMucTrangThai_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "DanhMucTrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CongViec_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DuAnPhongBanPhoiHop",
                columns: table => new
                {
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhongBanId = table.Column<long>(type: "bigint", nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAnPhongBanPhoiHop", x => new { x.DuAnId, x.PhongBanId });
                    table.ForeignKey(
                        name: "FK_DuAnPhongBanPhoiHop_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    SoHopDong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NgayKy = table.Column<DateOnly>(type: "date", nullable: false),
                    SoNgay = table.Column<int>(type: "int", nullable: false),
                    NgayNghiemThu = table.Column<DateOnly>(type: "date", nullable: false),
                    KhachHangId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NguoiPhuTrachChinhId = table.Column<int>(type: "int", nullable: true),
                    NguoiTheoDoiId = table.Column<int>(type: "int", nullable: true),
                    GiamDocId = table.Column<int>(type: "int", nullable: true),
                    LoaiHopDongId = table.Column<int>(type: "int", nullable: false),
                    GiaTri = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TienThue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    GiaTriSauThue = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PhongBanPhuTrachChinhId = table.Column<long>(type: "bigint", nullable: true),
                    GiaTriBaoLanh = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    NgayBaoLanhTu = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayBaoLanhDen = table.Column<DateOnly>(type: "date", nullable: true),
                    ThoiHanBaoHanh = table.Column<byte>(type: "tinyint", nullable: false),
                    NgayBaoHanhTu = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayBaoHanhDen = table.Column<DateOnly>(type: "date", nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TienDo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_DanhMucGiamDoc_GiamDocId",
                        column: x => x.GiamDocId,
                        principalTable: "DanhMucGiamDoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_DanhMucLoaiHopDong_LoaiHopDongId",
                        column: x => x.LoaiHopDongId,
                        principalTable: "DanhMucLoaiHopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_DanhMucNguoiPhuTrach_NguoiPhuTrachChinhId",
                        column: x => x.NguoiPhuTrachChinhId,
                        principalTable: "DanhMucNguoiPhuTrach",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_DanhMucNguoiTheoDoi_NguoiTheoDoiId",
                        column: x => x.NguoiTheoDoiId,
                        principalTable: "DanhMucNguoiTheoDoi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_DanhMucTrangThai_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "DanhMucTrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HopDong_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HopDong_KhachHang_KhachHangId",
                        column: x => x.KhachHangId,
                        principalTable: "KhachHang",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DuAn_ThuTien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThanhToanId = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ThoiGianKeHoach = table.Column<DateOnly>(type: "date", nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    GiaTriKeHoach = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThoiGianThucTe = table.Column<DateOnly>(type: "date", nullable: true),
                    GiaTriThucTe = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    SoHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KyHieuHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayHoaDon = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAn_ThuTien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAn_ThuTien_DanhMucLoaiThanhToan_LoaiThanhToanId",
                        column: x => x.LoaiThanhToanId,
                        principalTable: "DanhMucLoaiThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_ThuTien_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DuAn_ThuTien_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "DuAn_XuatHoaDon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThanhToanId = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ThoiGianKeHoach = table.Column<DateOnly>(type: "date", nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    GiaTriKeHoach = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ThoiGianThucTe = table.Column<DateOnly>(type: "date", nullable: true),
                    GiaTriThucTe = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    SoHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KyHieuHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayHoaDon = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAn_XuatHoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAn_XuatHoaDon_DanhMucLoaiThanhToan_LoaiThanhToanId",
                        column: x => x.LoaiThanhToanId,
                        principalTable: "DanhMucLoaiThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DuAn_XuatHoaDon_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DuAn_XuatHoaDon_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_ChiPhi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiChiPhiId = table.Column<int>(type: "int", nullable: false),
                    GhiChuKeHoach = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ThoiGianKeHoach = table.Column<DateOnly>(type: "date", nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    GiaTriKeHoach = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ThoiGianThucTe = table.Column<DateOnly>(type: "date", nullable: true),
                    GiaTriThucTe = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    GhiChuThucTe = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_ChiPhi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_ChiPhi_DanhMucLoaiChiPhi_LoaiChiPhiId",
                        column: x => x.LoaiChiPhiId,
                        principalTable: "DanhMucLoaiChiPhi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_ChiPhi_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_ThuTien",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThanhToanId = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ThoiGianKeHoach = table.Column<DateOnly>(type: "date", nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    GiaTriKeHoach = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ThoiGianThucTe = table.Column<DateOnly>(type: "date", nullable: true),
                    GiaTriThucTe = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    SoHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KyHieuHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayHoaDon = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_ThuTien", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_ThuTien_DanhMucLoaiThanhToan_LoaiThanhToanId",
                        column: x => x.LoaiThanhToanId,
                        principalTable: "DanhMucLoaiThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_ThuTien_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDong_XuatHoaDon",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoaiThanhToanId = table.Column<int>(type: "int", nullable: false),
                    GhiChu = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    ThoiGianKeHoach = table.Column<DateOnly>(type: "date", nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    GiaTriKeHoach = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ThoiGianThucTe = table.Column<DateOnly>(type: "date", nullable: true),
                    GiaTriThucTe = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    SoHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    KyHieuHoaDon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayHoaDon = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDong_XuatHoaDon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HopDong_XuatHoaDon_DanhMucLoaiThanhToan_LoaiThanhToanId",
                        column: x => x.LoaiThanhToanId,
                        principalTable: "DanhMucLoaiThanhToan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HopDong_XuatHoaDon_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HopDongPhongBanPhoiHop",
                columns: table => new
                {
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhongBanId = table.Column<long>(type: "bigint", nullable: false),
                    TenPhongBan = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HopDongPhongBanPhoiHop", x => new { x.HopDongId, x.PhongBanId });
                    table.ForeignKey(
                        name: "FK_HopDongPhongBanPhoiHop_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhuLucHopDong",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SoPhuLuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NgayKy = table.Column<DateOnly>(type: "date", nullable: false),
                    NoiDungPhuLuc = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhuLucHopDong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhuLucHopDong_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TienDo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhanTramKeHoach = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    NgayBatDauKeHoach = table.Column<DateOnly>(type: "date", nullable: true),
                    NgayKetThucKeHoach = table.Column<DateOnly>(type: "date", nullable: true),
                    MoTa = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false),
                    PhanTramThucTe = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    NgayCapNhatGanNhat = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TienDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TienDo_DanhMucTrangThai_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "DanhMucTrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TienDo_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BaoCaoTienDo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    TienDoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayBaoCao = table.Column<DateOnly>(type: "date", nullable: false),
                    NguoiBaoCaoId = table.Column<long>(type: "bigint", nullable: false),
                    TenNguoiBaoCao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhanTramThucTe = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false),
                    NoiDungDaLam = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    KeHoachTiepTheo = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    GhiChu = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CanDuyet = table.Column<bool>(type: "bit", nullable: false),
                    DaDuyet = table.Column<bool>(type: "bit", nullable: false),
                    NguoiDuyetId = table.Column<long>(type: "bigint", nullable: true),
                    TenNguoiDuyet = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    NgayDuyet = table.Column<DateOnly>(type: "date", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoCaoTienDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaoCaoTienDo_TienDo_TienDoId",
                        column: x => x.TienDoId,
                        principalTable: "TienDo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhoKhanVuongMac",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TienDoId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NoiDung = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    MucDo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    NgayPhatHien = table.Column<DateOnly>(type: "date", nullable: false),
                    NgayGiaiQuyet = table.Column<DateOnly>(type: "date", nullable: true),
                    BienPhapKhacPhuc = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhoKhanVuongMac", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KhoKhanVuongMac_DanhMucTrangThai_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "DanhMucTrangThai",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KhoKhanVuongMac_HopDong_HopDongId",
                        column: x => x.HopDongId,
                        principalTable: "HopDong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhoKhanVuongMac_TienDo_TienDoId",
                        column: x => x.TienDoId,
                        principalTable: "TienDo",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DanhMucGiamDoc",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DonViId", "IsDeleted", "Ma", "MoTa", "PhongBanId", "Ten", "UpdatedAt", "UpdatedBy", "Used", "UserPortalId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", 1L, false, "GD001", "Bản ghi mặc định để thỏa mãn ràng buộc FK từ DuAn", null, "Giám đốc mặc định", null, "", true, 1L },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", 49L, false, "", "Bản ghi mặc định để thỏa mãn ràng buộc FK từ DuAn", 217L, "Võ Thị Trung Trinh", null, "", true, 2L }
                });

            migrationBuilder.InsertData(
                table: "DanhMucLoaiChiPhi",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Ma", "MoTa", "Ten", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP001", "Chi phí nhân công xây dựng, hiệu chỉnh (MM)_30M/MM", "Chi phí nhân công xây dựng, hiệu chỉnh", null, "", true },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP002", "Nhân công MM triển khai", "Chi phí nhân công triển khai", null, "", true },
                    { 3, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP003", null, "Chi phí bảo hành sản phẩm", null, "", true },
                    { 4, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP004", null, "Chi phí tiếp khách: Kickoff, tiếp khách, nghiệm thu", null, "", true },
                    { 5, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP005", null, "Chi phí đi lại, tàu xe, máy bay", null, "", true },
                    { 6, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP006", null, "Công tác phí, in ấn tài liệu", null, "", true },
                    { 7, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP007", null, "Chi phí khách sạn", null, "", true },
                    { 8, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP008", null, "Thưởng dự án đúng hạn", null, "", true },
                    { 9, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP009", null, "Khoán chi phí dự án", null, "", true },
                    { 10, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP010", null, "Outsource, mua hàng hóa, dịch vụ bên ngoài", null, "", true },
                    { 11, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP011", null, "Chi phí kinh doanh, quản lý", null, "", true },
                    { 12, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CP012", null, "Chi phí vốn vay/trả chậm", null, "", true }
                });

            migrationBuilder.InsertData(
                table: "DanhMucLoaiChiPhi",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "IsDeleted", "Ma", "MoTa", "Ten", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[] { 13, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", true, false, "CP015", null, "Chi phí TK khác", null, "", true });

            migrationBuilder.InsertData(
                table: "DanhMucLoaiHopDong",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Ma", "MoTa", "Prefix", "Symbol", "Ten", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "C0001", null, 1, "TTCĐS-", "Hợp đồng Software", null, "", true },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "C0002", null, 1, "TTCĐS-", "Hợp đồng Hardware", null, "", true },
                    { 3, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "C0003", null, 1, "TTCĐS-", "Hợp đồng bảo trì", null, "", true },
                    { 4, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "C0004", null, 1, "TTCĐS-", "Hợp đồng cho thuê, trả góp", null, "", true },
                    { 5, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "C0005", null, 1, "TTCĐS-", "Hợp đồng Hóa đơn điện tử (theo số)", null, "", false },
                    { 6, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "C0006", null, 1, "TTCĐS-", "Hợp đồng dịch vụ khác", null, "", true }
                });

            migrationBuilder.InsertData(
                table: "DanhMucLoaiHopDong",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "IsDeleted", "Ma", "MoTa", "Prefix", "Symbol", "Ten", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[] { 7, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", true, false, "C0007", null, 1, "TTCĐS-", "Hợp đồng tư vấn", null, "", true });

            migrationBuilder.InsertData(
                table: "DanhMucLoaiThanhToan",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "IsDeleted", "Ma", "MoTa", "Ten", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", true, false, "TT01", null, "Thanh toán đợt 1", null, "", true });

            migrationBuilder.InsertData(
                table: "DanhMucLoaiThanhToan",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Ma", "MoTa", "Ten", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "TT02", null, "Thanh toán đợt 2", null, "", true },
                    { 3, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "TU", null, "Tạm ứng", null, "", true },
                    { 4, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "TT03", null, "Thanh toán đợt 3", null, "", true },
                    { 5, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "DK", null, "Thanh toán định kỳ (thuê, bảo trì, HĐĐT)", null, "", true },
                    { 6, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "TT04", null, "Thanh toán đợt n", null, "", true },
                    { 7, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "TC", null, "Thanh toán đợt cuối", null, "", true },
                    { 8, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", true, "TU", null, "Tạm ứng", null, "", false }
                });

            migrationBuilder.InsertData(
                table: "DanhMucLoaiTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "Ma", "MoTa", "Ten", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "HDONG", null, "Hợp đồng", null, "", true },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "KHOACH", null, "Kế hoạch", null, "", true },
                    { 3, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "CHOP", null, "Cuộc họp", null, "", true },
                    { 4, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "TIENDO", null, "Tiến độ", null, "", true },
                    { 5, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, "KKHUAN_VUONG_MAC", null, "Khó khăn vướng mắc", null, "", true }
                });

            migrationBuilder.InsertData(
                table: "DanhMucNguoiPhuTrach",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DonViId", "IsDeleted", "Ma", "MoTa", "PhongBanId", "Ten", "UpdatedAt", "UpdatedBy", "Used", "UserPortalId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", 1L, false, "NPT001", "Bản ghi mặc định để thỏa mãn ràng buộc FK từ DuAn", null, "Người phụ trách mặc định", null, "", true, 1L },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", 49L, false, "", "Bản ghi mặc định để thỏa mãn ràng buộc FK từ DuAn", 220L, "Nguyễn Văn Hậu", null, "", true, 21L }
                });

            migrationBuilder.InsertData(
                table: "DanhMucNguoiTheoDoi",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DonViId", "IsDeleted", "Ma", "MoTa", "PhongBanId", "Ten", "UpdatedAt", "UpdatedBy", "Used", "UserPortalId" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", 1L, false, "NTD001", "Bản ghi mặc định để thỏa mãn ràng buộc FK từ DuAn", null, "Người theo dõi mặc định", null, "", true, 1L },
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", 49L, false, "", "Bản ghi mặc định để thỏa mãn ràng buộc FK từ DuAn", 220L, "Lương Công Phi", null, "", true, 22L }
                });

            migrationBuilder.InsertData(
                table: "DoanhNghiep",
                columns: new[] { "Id", "AccountHolder", "AddressEN", "AddressVN", "AuthorizeDate", "AuthorizeLic", "AuthorizeVolume", "BankAccount", "BankName", "CityId", "ContactPerson", "CountryId", "CreatedAt", "CreatedBy", "DistrictId", "Email", "Fax", "Index", "IsActive", "IsDeleted", "IsLogo", "LogoFileName", "MoTa", "Owner", "Phone", "TaxAuthorityId", "TaxCode", "Ten", "TenTiengAnh", "UpdatedAt", "UpdatedBy", "Version" },
                values: new object[] { new Guid("36456269-c0af-498c-b640-165f1273649b"), null, "Lầu 4, Số 26 Lý Tự Trọng, Phường Bến Nghé, Quận 1, TP.HCM", "Lầu 4, Số 26 Lý Tự Trọng, Phường Bến Nghé, Quận 1, TP.HCM", new DateTime(2020, 8, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "zZIuWonO/S8gpAmtkDwSGDbJnx3zNYMCemlRfy/+l6g=", "6D4FEBF488C433AFBFF", null, null, null, "Võ Thị Trung Trinh", null, new DateTimeOffset(new DateTime(2018, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "b56b81a2-dc45-4c93-8a52-858a8d973e5b", null, "vothitrungtrinh@tphcm.gov.vn", null, 1L, true, false, true, "logo.png", null, "Võ Thị Trung Trinh", "(028) 3822 3989", 79, "0318546665", "TRUNG TÂM CHUYỂN ĐỔI SỐ THÀNH PHỐ HỒ CHÍ MINH", "TRUNG TÂM CHUYỂN ĐỔI SỐ THÀNH PHỐ HỒ CHÍ MINH", new DateTimeOffset(new DateTime(2020, 10, 30, 16, 8, 22, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "0f9e650a-68be-45d3-a996-3f98370e1ca3", "0.1" });

            migrationBuilder.InsertData(
                table: "KhachHang",
                columns: new[] { "Id", "Address", "CityId", "CityName", "ContactPerson", "CountryId", "CountryName", "CreatedAt", "CreatedBy", "DateOfBirth", "DistrictId", "DistrictName", "DoanhNghiepId", "DonViId", "Email", "Index", "IsDefault", "IsDeleted", "IsPersonal", "Ma", "Phone", "TaxCode", "Ten", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { new Guid("12970000-0000-0000-0000-000000000001"), "123 abc phường zy", 79, "Thành phố Hồ Chí Minh", "Phạm Lê Hoàng", 1311, "Việt Nam", new DateTimeOffset(new DateTime(2026, 1, 7, 2, 11, 40, 857, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", null, 760, "Quận 1", null, null, null, 5L, false, false, false, "123", "0707926805", "07010042", "Phạm Lê Hoàng", new DateTimeOffset(new DateTime(2026, 1, 7, 2, 11, 40, 857, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", true },
                    { new Guid("12980000-0000-0000-0000-000000000001"), "tphcm", 79, "Thành phố Hồ Chí Minh", null, 1311, "Việt Nam", new DateTimeOffset(new DateTime(2026, 3, 9, 8, 49, 39, 573, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", null, 760, "Quận 1", null, null, null, 6L, false, false, false, "CUST-09032026034939", null, "123", "Nam", new DateTimeOffset(new DateTime(2026, 3, 9, 8, 49, 39, 573, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", true },
                    { new Guid("13000000-0000-0000-0000-000000000001"), "Phường Sài Gòn thành phố Hồ Chí Minh", 79, "Thành phố Hồ Chí Minh", "Nguyễn Văn A", 1311, "Việt Nam", new DateTimeOffset(new DateTime(2026, 3, 16, 6, 26, 26, 750, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", null, 760, "Quận 1", null, null, null, 8L, false, false, false, "001", null, "0792000123", "Khách hàng tiềm năng", new DateTimeOffset(new DateTime(2026, 3, 16, 6, 26, 26, 750, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", true }
                });

            migrationBuilder.InsertData(
                table: "DanhMucTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "IsDeleted", "LoaiTrangThaiId", "Ma", "MaLoaiTrangThai", "MoTa", "Ten", "TenLoaiTrangThai", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[] { 1, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", true, false, 1, "OPEN", "HDONG", null, "Đang thực hiện", "Hợp đồng", null, "", true });

            migrationBuilder.InsertData(
                table: "DanhMucTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LoaiTrangThaiId", "Ma", "MaLoaiTrangThai", "MoTa", "Ten", "TenLoaiTrangThai", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { 2, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 1, "PENDING", "HDONG", null, "Tạm dừng", "Hợp đồng", null, "", true },
                    { 3, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 1, "CANCEL", "HDONG", null, "Hủy", "Hợp đồng", null, "", true },
                    { 4, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 1, "COMPLETE", "HDONG", null, "Nghiệm thu", "Hợp đồng", null, "", true }
                });

            migrationBuilder.InsertData(
                table: "DanhMucTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "IsDeleted", "LoaiTrangThaiId", "Ma", "MaLoaiTrangThai", "MoTa", "Ten", "TenLoaiTrangThai", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[] { 5, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", true, false, 2, "RUNNING", "KHOACH", null, "Đang thực hiện", "Kế hoạch", null, "", true });

            migrationBuilder.InsertData(
                table: "DanhMucTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LoaiTrangThaiId", "Ma", "MaLoaiTrangThai", "MoTa", "Ten", "TenLoaiTrangThai", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { 6, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 2, "WS.01", "KHOACH", null, "Theo dõi (Chưa rõ ràng)", "Kế hoạch", null, "", true },
                    { 7, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 2, "SIGNED", "KHOACH", null, "Hoàn tất", "Kế hoạch", null, "", true },
                    { 8, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 2, "WS03", "KHOACH", null, "Có chủ trương/có KH thực hiện", "Kế hoạch", null, "", false },
                    { 9, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 2, "WS05", "KHOACH", null, "Có QĐ phê duyệt.", "Kế hoạch", null, "", false },
                    { 10, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 2, "WS06", "KHOACH", null, "Đấu thầu, đàm phán", "Kế hoạch", null, "", false },
                    { 11, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 2, "WS07", "KHOACH", null, "Tạm dừng/Không thực hiện", "Kế hoạch", null, "", true },
                    { 12, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 1, "CLOSED", "HDONG", "Hoàn tất Nghiệm thu, thu tiền, xuất hóa đơn.", "Hoàn tất", "Hợp đồng", null, "", true },
                    { 13, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 1, "MAINTENANCE", "HDONG", null, "Bảo trì", "Hợp đồng", null, "", true },
                    { 14, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 2, "TK", "KHOACH", "HĐ bảo trì, thuê vi.his, vi.Office, hóa đơn điện tử", "Tái ký", "Kế hoạch", null, "", true }
                });

            migrationBuilder.InsertData(
                table: "DanhMucTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "IsDeleted", "LoaiTrangThaiId", "Ma", "MaLoaiTrangThai", "MoTa", "Ten", "TenLoaiTrangThai", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[] { 15, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", true, false, 3, "OPEN", "CHOP", null, "Chưa diễn ra", "Cuộc họp", null, "", true });

            migrationBuilder.InsertData(
                table: "DanhMucTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LoaiTrangThaiId", "Ma", "MaLoaiTrangThai", "MoTa", "Ten", "TenLoaiTrangThai", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { 16, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 3, "WAITING", "CHOP", null, "Chưa duyệt", "Cuộc họp", null, "", true },
                    { 17, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 3, "CLOSED", "CHOP", null, "Đã kết thúc", "Cuộc họp", null, "", true },
                    { 18, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 3, "GOINGON", "CHOP", null, "Đang diễn ra", "Cuộc họp", null, "", true },
                    { 19, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 3, "CANCEL", "CHOP", null, "Hủy", "Cuộc họp", null, "", true },
                    { 20, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 3, "PENDING", "CHOP", null, "Tạm hoãn", "Cuộc họp", null, "", true },
                    { 21, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 2, "DONE", "KHOACH", null, "Nghiệm thu", "Kế hoạch", null, "", true }
                });

            migrationBuilder.InsertData(
                table: "DanhMucTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "IsDeleted", "LoaiTrangThaiId", "Ma", "MaLoaiTrangThai", "MoTa", "Ten", "TenLoaiTrangThai", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[] { 24, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", true, false, 4, "CHUA_BAT_DAU", "TIENDO", null, "Chưa bắt đầu", "Tiến độ", null, "", true });

            migrationBuilder.InsertData(
                table: "DanhMucTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LoaiTrangThaiId", "Ma", "MaLoaiTrangThai", "MoTa", "Ten", "TenLoaiTrangThai", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { 25, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 4, "DANG_THUC_HIEN", "TIENDO", null, "Đang thực hiện", "Tiến độ", null, "", true },
                    { 26, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 4, "HOAN_THANH", "TIENDO", null, "Hoàn thành", "Tiến độ", null, "", true },
                    { 27, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 4, "TAM_DUNG", "TIENDO", null, "Tạm dừng", "Tiến độ", null, "", true },
                    { 28, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 4, "HUY", "TIENDO", null, "Hủy", "Tiến độ", null, "", true }
                });

            migrationBuilder.InsertData(
                table: "DanhMucTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDefault", "IsDeleted", "LoaiTrangThaiId", "Ma", "MaLoaiTrangThai", "MoTa", "Ten", "TenLoaiTrangThai", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[] { 29, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", true, false, 5, "MOI", "KHOKHAN_VUONGMAC", null, "Mới", "Khó khăn vướng mắc", null, "", true });

            migrationBuilder.InsertData(
                table: "DanhMucTrangThai",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "IsDeleted", "LoaiTrangThaiId", "Ma", "MaLoaiTrangThai", "MoTa", "Ten", "TenLoaiTrangThai", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { 30, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 5, "DANG_XU_LY", "KHOKHAN_VUONGMAC", null, "Đang xử lý", "Khó khăn vướng mắc", null, "", true },
                    { 31, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 5, "DA_GIAI_QUYET", "KHOKHAN_VUONGMAC", null, "Đã giải quyết", "Khó khăn vướng mắc", null, "", true },
                    { 32, new DateTimeOffset(new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "", false, 5, "KHONG_THE_GIAI_QUYET", "KHOKHAN_VUONGMAC", null, "Không thể giải quyết", "Khó khăn vướng mắc", null, "", true }
                });

            migrationBuilder.InsertData(
                table: "KhachHang",
                columns: new[] { "Id", "Address", "CityId", "CityName", "ContactPerson", "CountryId", "CountryName", "CreatedAt", "CreatedBy", "DateOfBirth", "DistrictId", "DistrictName", "DoanhNghiepId", "DonViId", "Email", "Index", "IsDefault", "IsDeleted", "IsPersonal", "Ma", "Phone", "TaxCode", "Ten", "UpdatedAt", "UpdatedBy", "Used" },
                values: new object[,]
                {
                    { new Guid("12930000-0000-0000-0000-000000000001"), "29 Lê Quý Đôn, Phường Võ Thị Sáu, Quận 3, Thành phố Hồ Chí Minh, Việt Nam", 79, "Thành phố Hồ Chí Minh", null, 1311, "Việt Nam", new DateTimeOffset(new DateTime(2025, 4, 14, 10, 23, 48, 597, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "18b34731-6b0d-46f3-a919-5e4707db4f1b", null, 770, "Quận 3", new Guid("36456269-c0af-498c-b640-165f1273649b"), null, null, 1L, false, false, false, "CUST-14042025052348", null, "0305250928", "Ban Quản lý đường sắt đô thị thành phố", new DateTimeOffset(new DateTime(2025, 4, 14, 10, 23, 48, 597, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "18b34731-6b0d-46f3-a919-5e4707db4f1b", true },
                    { new Guid("12940000-0000-0000-0000-000000000001"), "59 Đ. Nguyễn Thị Minh Khai, Phường Bến Thành, Quận 1, Hồ Chí Minh", 79, "Thành phố Hồ Chí Minh", null, 1311, "Việt Nam", new DateTimeOffset(new DateTime(2025, 4, 15, 7, 56, 4, 560, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "18b34731-6b0d-46f3-a919-5e4707db4f1b", null, 760, "Quận 1", new Guid("36456269-c0af-498c-b640-165f1273649b"), null, null, 2L, false, false, false, "CUST-15042025025604", null, "0312163017", "Sở Y tế TP. HCM", new DateTimeOffset(new DateTime(2025, 4, 15, 7, 56, 4, 560, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "18b34731-6b0d-46f3-a919-5e4707db4f1b", true },
                    { new Guid("12950000-0000-0000-0000-000000000001"), "123 abc phường zy", 48, "Thành phố Đà Nẵng", "nguyễn a", 1311, "Việt Nam", new DateTimeOffset(new DateTime(2026, 1, 6, 6, 58, 2, 420, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", null, 493, "Quận Sơn Trà", new Guid("36456269-c0af-498c-b640-165f1273649b"), null, null, 3L, false, false, false, "CUST-06012026015802", "0707926805", "07010042", "cty xyz", new DateTimeOffset(new DateTime(2026, 1, 6, 6, 58, 2, 420, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", true },
                    { new Guid("12960000-0000-0000-0000-000000000001"), "123 Test", 79, "Thành phố Hồ Chí Minh", null, 1311, "Việt Nam", new DateTimeOffset(new DateTime(2026, 1, 6, 7, 22, 27, 57, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", null, 760, "Quận 1", new Guid("36456269-c0af-498c-b640-165f1273649b"), null, null, 4L, false, false, false, "0123123", null, "012321321231", "Cty Test 1", new DateTimeOffset(new DateTime(2026, 1, 6, 7, 22, 27, 57, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", true },
                    { new Guid("12990000-0000-0000-0000-000000000001"), "tphcm", 79, "Thành phố Hồ Chí Minh", null, 1311, "Việt Nam", new DateTimeOffset(new DateTime(2026, 3, 9, 8, 52, 53, 703, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", null, 760, "Quận 1", new Guid("36456269-c0af-498c-b640-165f1273649b"), null, null, 7L, false, false, false, "CUST-09032026035253", null, "123", "Nam", new DateTimeOffset(new DateTime(2026, 3, 9, 8, 52, 53, 703, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", true },
                    { new Guid("13010000-0000-0000-0000-000000000001"), "Phường Sài Gòn", 79, "Thành phố Hồ Chí Minh", "Nguyễn Văn A", 1311, "Việt Nam", new DateTimeOffset(new DateTime(2026, 3, 16, 6, 31, 22, 860, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", null, 760, "Quận 1", new Guid("36456269-c0af-498c-b640-165f1273649b"), null, null, 9L, false, false, false, "NEW01", null, "079199912345", "Khách hàng mới 01", new DateTimeOffset(new DateTime(2026, 3, 16, 6, 31, 22, 860, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "cab94c06-8f22-480a-b4b3-4b427acc63f3", true }
                });

            migrationBuilder.InsertData(
                table: "DuAn",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "GhiChu", "GiaTriDuKien", "GiaVon", "GiamDocId", "HasHopDong", "Index", "IsDeleted", "KhachHangId", "NgayLap", "NguoiPhuTrachChinhId", "NguoiTheoDoiId", "PhongBanPhuTrachChinhId", "Ten", "ThanhTien", "ThoiGianDuKien", "TrangThaiId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("08de8ae1-f818-b6fb-687a-7b0ee802f6e2"), new DateTimeOffset(new DateTime(2026, 3, 26, 2, 47, 6, 788, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", null, 2000000000m, 20m, 1, true, 1774493226L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 26), 1, 1, 220L, "dự án 02", 400000000m, new DateOnly(2026, 3, 26), 21, new DateTimeOffset(new DateTime(2026, 3, 26, 2, 47, 6, 788, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24" },
                    { new Guid("08de8ae6-f3fa-8818-687a-7b1a0405858d"), new DateTimeOffset(new DateTime(2026, 3, 26, 3, 22, 47, 366, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", null, 2000000000m, 20m, 2, false, 1774495367L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 1), 2, 2, 220L, "dự án 01", 400000000m, new DateOnly(2026, 3, 26), 5, null, "" },
                    { new Guid("08de8ae7-2db9-ca71-687a-7b1a04058592"), new DateTimeOffset(new DateTime(2026, 3, 26, 3, 22, 47, 366, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", null, 2000000000m, 20m, 1, false, 1774495464L, true, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 26), 1, 1, 220L, "dự án 02", 400000000m, new DateOnly(2026, 3, 26), 21, new DateTimeOffset(new DateTime(2026, 3, 26, 3, 38, 42, 749, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24" },
                    { new Guid("08de8ae8-8c4d-cda7-687a-7b1a04058597"), new DateTimeOffset(new DateTime(2026, 3, 26, 3, 34, 12, 420, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", null, 100000000m, 10m, 2, true, 1774496052L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 1), 2, 2, 220L, "dự án 03", 10000000m, new DateOnly(2026, 3, 27), 5, new DateTimeOffset(new DateTime(2026, 3, 26, 4, 5, 53, 205, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24" },
                    { new Guid("08de8aee-3fc7-15f0-687a-7b2f4800aae6"), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 29, 39, 414, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", null, 2000000000m, 20m, 1, false, 1774513599L, true, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 26), 1, 1, 220L, "dự án 02", 400000000m, new DateOnly(2026, 3, 26), 5, new DateTimeOffset(new DateTime(2026, 3, 30, 8, 11, 33, 509, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23" },
                    { new Guid("08de8aee-575f-03bd-687a-7b2f4800aaeb"), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 29, 39, 414, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", null, 2000000000m, 20m, 1, false, 1774513599L, true, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 26), 1, 1, 220L, "dự án 02", 400000000m, new DateOnly(2026, 3, 26), 5, new DateTimeOffset(new DateTime(2026, 3, 30, 8, 11, 33, 509, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23" },
                    { new Guid("08de8b0f-54cd-f83b-687a-7b0f440558f4"), new DateTimeOffset(new DateTime(2026, 3, 26, 8, 11, 49, 678, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", null, 2000000000m, 20m, 1, true, 1774512709L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 26), 1, 1, 220L, "dự án 02", 400000000m, new DateOnly(2026, 3, 26), 5, new DateTimeOffset(new DateTime(2026, 3, 27, 2, 0, 11, 303, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24" },
                    { new Guid("08de8b11-66a0-889c-687a-7b2360037372"), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 29, 39, 414, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", null, 2000000000m, 20m, 1, false, 1774513599L, true, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 26), 1, 1, 220L, "dự án 02", 400000000m, new DateOnly(2026, 3, 26), 5, new DateTimeOffset(new DateTime(2026, 3, 30, 8, 11, 33, 509, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23" },
                    { new Guid("08de8ba7-b653-d234-687a-7b311402bfed"), new DateTimeOffset(new DateTime(2026, 3, 27, 2, 22, 37, 393, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", null, 2000000000m, 20m, 1, true, 1774578157L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 26), 1, 1, 220L, "dự án 02", 400000000m, new DateOnly(2026, 3, 26), 5, new DateTimeOffset(new DateTime(2026, 3, 27, 2, 40, 11, 555, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23" },
                    { new Guid("08de8ba8-2569-3281-687a-7b311402bff0"), new DateTimeOffset(new DateTime(2026, 3, 27, 2, 25, 43, 287, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", null, 2000000000m, 10m, 2, true, 1774578343L, false, new Guid("12940000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 1), 2, 2, 220L, "dự án mới năm 2026", 200000000m, new DateOnly(2026, 3, 31), 5, new DateTimeOffset(new DateTime(2026, 3, 27, 2, 28, 36, 160, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23" },
                    { new Guid("08de8ba8-407a-7691-687a-7b311402bffd"), new DateTimeOffset(new DateTime(2026, 3, 27, 2, 26, 28, 573, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", null, 15000000000m, 75m, 2, true, 1774578388L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2025, 3, 4), 2, 2, 220L, "Dự án làm trước 20236 - Giải Phóng Mặt Bằng vành đai 3 giai đoạn 1", 11250000000m, new DateOnly(2026, 1, 1), 6, new DateTimeOffset(new DateTime(2026, 3, 27, 2, 34, 49, 763, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24" },
                    { new Guid("08de8ba8-ecdb-8025-687a-7b311402c012"), new DateTimeOffset(new DateTime(2026, 3, 27, 2, 26, 28, 573, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", null, 15000000000m, 75m, 2, true, 1774578388L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2025, 3, 4), 2, 2, 220L, "Dự án làm trước 20236 - Giải Phóng Mặt Bằng vành đai 3 giai đoạn 1", 11250000000m, new DateOnly(2026, 1, 1), 6, new DateTimeOffset(new DateTime(2026, 3, 27, 2, 34, 49, 763, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24" },
                    { new Guid("08de8ba9-007a-9b89-687a-7b311402c017"), new DateTimeOffset(new DateTime(2026, 3, 27, 2, 31, 50, 698, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "4", null, 20000000000m, 20m, 2, true, 1774578710L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 4, 10), 2, 2, 220L, "dự án 04", 4000000000m, new DateOnly(2026, 4, 30), 5, new DateTimeOffset(new DateTime(2026, 3, 27, 2, 38, 26, 461, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24" },
                    { new Guid("08de8ba9-024c-0844-687a-7b311402c01c"), new DateTimeOffset(new DateTime(2026, 3, 27, 2, 31, 53, 749, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "4", null, 20000000000m, 20m, 2, true, 1774578713L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 4, 10), 2, 2, 220L, "dự án 04", 4000000000m, new DateOnly(2026, 4, 30), 5, new DateTimeOffset(new DateTime(2026, 3, 27, 2, 33, 31, 207, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23" },
                    { new Guid("08de8e03-f82d-f499-687a-7b31f0054948"), new DateTimeOffset(new DateTime(2026, 3, 30, 2, 28, 3, 573, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", null, 1234500000m, 20m, 2, true, 1774837683L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 31), 2, 2, 220L, "Dự án triển khai vận hành hệ thống chuyển đổi số", 246900000m, new DateOnly(2026, 3, 31), 5, new DateTimeOffset(new DateTime(2026, 3, 30, 2, 34, 49, 653, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23" },
                    { new Guid("08de8e33-4b37-76dd-687a-7b2ad003cb6f"), new DateTimeOffset(new DateTime(2026, 3, 30, 8, 6, 49, 308, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", null, 500000000m, 25m, 2, false, 1774858009L, false, new Guid("12930000-0000-0000-0000-000000000001"), new DateOnly(2026, 3, 30), 2, 2, 220L, "Dự án pilot chuyển đổi số giai đoạn 2", 125000000m, new DateOnly(2026, 4, 30), 5, new DateTimeOffset(new DateTime(2026, 3, 30, 8, 7, 19, 432, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23" }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DuAnId", "GhiChu", "GiaTri", "GiaTriBaoLanh", "GiaTriSauThue", "GiamDocId", "Index", "IsDeleted", "KhachHangId", "LoaiHopDongId", "NgayBaoHanhDen", "NgayBaoHanhTu", "NgayBaoLanhDen", "NgayBaoLanhTu", "NgayKy", "NgayNghiemThu", "NguoiPhuTrachChinhId", "NguoiTheoDoiId", "PhongBanPhuTrachChinhId", "SoHopDong", "SoNgay", "Ten", "ThoiHanBaoHanh", "TienDo", "TienThue", "TrangThaiId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("08de8ba4-93af-0560-687a-7b374803a052"), new DateTimeOffset(new DateTime(2026, 3, 27, 2, 0, 10, 569, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", null, "2.020.000.000", 2000000000m, 2020000000m, 2020000000m, 1, 1774576810L, false, new Guid("12930000-0000-0000-0000-000000000001"), 6, new DateOnly(2027, 5, 14), new DateOnly(2026, 5, 14), new DateOnly(2026, 3, 27), new DateOnly(2026, 3, 19), new DateOnly(2026, 3, 26), new DateOnly(2026, 5, 14), 1, 1, 220L, "HĐ -002", 50, "dự án hợp đồng 02", (byte)12, "2.020.000.000", 20000000m, 1, new DateTimeOffset(new DateTime(2026, 3, 27, 2, 2, 5, 740, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24" },
                    { new Guid("08de8e04-ea40-bc98-687a-7b31f0054957"), new DateTimeOffset(new DateTime(2026, 3, 30, 2, 34, 49, 457, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", null, "1.254.500.000 - GHI CHÚ", 1234500000m, 1254500000m, 1254500000m, 2, 1774838089L, false, new Guid("12930000-0000-0000-0000-000000000001"), 4, new DateOnly(2027, 5, 19), new DateOnly(2026, 5, 19), new DateOnly(2026, 3, 31), new DateOnly(2026, 3, 25), new DateOnly(2026, 3, 31), new DateOnly(2026, 5, 19), 2, 2, 220L, "HĐ/2026-30", 50, "Dự án triển khai vận hành hệ thống chuyển đổi số", (byte)12, "1.254.500.000 - TIẾN ĐỘ", 20000000m, 1, null, "" },
                    { new Guid("08de8e34-4cc7-d0c2-687a-7b2ad003cba3"), new DateTimeOffset(new DateTime(2026, 3, 30, 8, 14, 1, 86, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", null, "310.000.000", 300000000m, 310000000m, 310000000m, 2, 1774858441L, false, new Guid("12930000-0000-0000-0000-000000000001"), 3, new DateOnly(2027, 5, 9), new DateOnly(2026, 5, 9), null, null, new DateOnly(2026, 3, 31), new DateOnly(2026, 5, 9), 2, 2, 220L, "HĐ/2026-05", 40, "Hợp đồng năm 2026", (byte)12, "310.000.000", 10000000m, 1, null, "" }
                });

            migrationBuilder.InsertData(
                table: "CongViec",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DonViId", "DuAnId", "Index", "IsDeleted", "KeHoachCongViec", "NgayHoanThanh", "NguoiThucHien", "PhongBanId", "TenDonVi", "TenPhongBan", "TenTrangThai", "ThoiGian", "ThucTe", "TrangThaiId", "UpdatedAt", "UpdatedBy", "UserPortalId" },
                values: new object[,]
                {
                    { new Guid("08de8b1a-3426-d860-687a-7b2360037375"), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 29, 39, 414, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", 0L, new Guid("08de8b11-66a0-889c-687a-7b2360037372"), 1774517379L, false, "kế hoạch", new DateOnly(2026, 3, 27), "", 0L, "", "", "Chờ xử lý", new DateOnly(2026, 4, 1), "kế hoạch", 5, null, "", 22L },
                    { new Guid("08de8b1b-12b8-88b4-687a-7b2360037380"), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 35, 52, 765, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", 0L, new Guid("08de8b11-66a0-889c-687a-7b2360037372"), 1774517752L, false, "keHoachCongViec", new DateOnly(2026, 3, 28), "", 0L, "", "", "Đang thực hiện", new DateOnly(2026, 5, 1), "thực tế chỉnh sửa", 21, new DateTimeOffset(new DateTime(2026, 3, 26, 9, 49, 53, 236, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", 21L },
                    { new Guid("08de8b1d-8705-a758-687a-7b23600373a1"), new DateTimeOffset(new DateTime(2026, 3, 26, 9, 53, 26, 880, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", 0L, new Guid("08de8b11-66a0-889c-687a-7b2360037372"), 1774518806L, false, "KH", new DateOnly(2026, 3, 27), "", 0L, "", "", "Hoàn thành", new DateOnly(2027, 6, 1), "TT", 7, null, "", 2L },
                    { new Guid("08de8bad-246c-0ec3-687a-7b311402c058"), new DateTimeOffset(new DateTime(2026, 3, 27, 3, 1, 29, 55, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", 0L, new Guid("08de8ae6-f3fa-8818-687a-7b1a0405858d"), 1774580489L, false, "kế hoạch", new DateOnly(2026, 3, 28), "", 0L, "", "", "Chờ xử lý", new DateOnly(2026, 4, 1), "kế hoạch", 5, null, "", 22L },
                    { new Guid("08de8e05-f0c7-4774-687a-7b31f0054967"), new DateTimeOffset(new DateTime(2026, 3, 30, 2, 42, 9, 947, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", 49L, new Guid("08de8e03-f82d-f499-687a-7b31f0054948"), 1774838529L, false, "kế hoạch", new DateOnly(2026, 3, 31), "", 220L, "Trung tâm Chuyển đổi số - TPHCM", "Phòng Hạ tầng số và An toàn thông tin", "Chờ xử lý", new DateOnly(2026, 3, 1), "thực tế", 5, null, "", 22L },
                    { new Guid("08de8e33-5d56-8db5-687a-7b2ad003cb7a"), new DateTimeOffset(new DateTime(2026, 3, 30, 8, 7, 19, 432, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", 49L, new Guid("08de8e33-4b37-76dd-687a-7b2ad003cb6f"), 1774858039L, false, "Triển khai kế hoạch dự án", new DateOnly(2026, 4, 5), "", 220L, "Trung tâm Chuyển đổi số - TPHCM", "Phòng Hạ tầng số và An toàn thông tin", "Chờ xử lý", new DateOnly(2026, 3, 1), "Triển khai kế hoạch dự án - chỉnh sửa", 5, new DateTimeOffset(new DateTime(2026, 3, 30, 8, 11, 22, 265, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", 22L }
                });

            migrationBuilder.InsertData(
                table: "DuAnPhongBanPhoiHop",
                columns: new[] { "DuAnId", "PhongBanId", "TenPhongBan" },
                values: new object[,]
                {
                    { new Guid("08de8ae1-f818-b6fb-687a-7b0ee802f6e2"), 307L, "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
                    { new Guid("08de8ae6-f3fa-8818-687a-7b1a0405858d"), 261L, "Ban Dân tộc" },
                    { new Guid("08de8ae6-f3fa-8818-687a-7b1a0405858d"), 271L, "Ban Quản lý dự án đầu tư xây dựng hạ tầng đô thị" },
                    { new Guid("08de8ae6-f3fa-8818-687a-7b1a0405858d"), 288L, "Ban An toàn giao thông" },
                    { new Guid("08de8ae6-f3fa-8818-687a-7b1a0405858d"), 304L, "Ban Quản lý dự án đầu tư xây dựng các công trình dân dụng" },
                    { new Guid("08de8ae7-2db9-ca71-687a-7b1a04058592"), 307L, "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
                    { new Guid("08de8ae8-8c4d-cda7-687a-7b1a04058597"), 261L, "Ban Dân tộc" },
                    { new Guid("08de8aee-3fc7-15f0-687a-7b2f4800aae6"), 307L, "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
                    { new Guid("08de8aee-575f-03bd-687a-7b2f4800aaeb"), 307L, "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
                    { new Guid("08de8b0f-54cd-f83b-687a-7b0f440558f4"), 307L, "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
                    { new Guid("08de8b11-66a0-889c-687a-7b2360037372"), 307L, "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
                    { new Guid("08de8ba7-b653-d234-687a-7b311402bfed"), 307L, "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
                    { new Guid("08de8ba8-2569-3281-687a-7b311402bff0"), 217L, "Ban Giám đốc" },
                    { new Guid("08de8ba8-2569-3281-687a-7b311402bff0"), 219L, "Phòng Kế hoạch - Tài chính" },
                    { new Guid("08de8ba8-2569-3281-687a-7b311402bff0"), 360L, "Trung Tâm Chuyển Đổi Số Khu Vực 2" },
                    { new Guid("08de8ba8-ecdb-8025-687a-7b311402c012"), 272L, "Ban Đổi mới quản lý doanh nghiệp" },
                    { new Guid("08de8ba9-007a-9b89-687a-7b311402c017"), 272L, "Ban Đổi mới quản lý doanh nghiệp" },
                    { new Guid("08de8ba9-024c-0844-687a-7b311402c01c"), 272L, "Ban Đổi mới quản lý doanh nghiệp" },
                    { new Guid("08de8e03-f82d-f499-687a-7b31f0054948"), 217L, "Ban Giám đốc" },
                    { new Guid("08de8e03-f82d-f499-687a-7b31f0054948"), 219L, "Phòng Kế hoạch - Tài chính" },
                    { new Guid("08de8e03-f82d-f499-687a-7b31f0054948"), 221L, "Phòng Nền tảng và Dữ liệu số" },
                    { new Guid("08de8e03-f82d-f499-687a-7b31f0054948"), 359L, "Trung Tâm Chuyển Đổi Số Khu Vực 1" },
                    { new Guid("08de8e33-4b37-76dd-687a-7b2ad003cb6f"), 217L, "Ban Giám đốc" },
                    { new Guid("08de8e33-4b37-76dd-687a-7b2ad003cb6f"), 218L, "Văn phòng" },
                    { new Guid("08de8e33-4b37-76dd-687a-7b2ad003cb6f"), 220L, "Phòng Hạ tầng số và An toàn thông tin" },
                    { new Guid("08de8e33-4b37-76dd-687a-7b2ad003cb6f"), 358L, "Trung Tâm Tư vấn, Đào tạo và Truyền thông số" }
                });

            migrationBuilder.InsertData(
                table: "HopDong",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DuAnId", "GhiChu", "GiaTri", "GiaTriBaoLanh", "GiaTriSauThue", "GiamDocId", "Index", "IsDeleted", "KhachHangId", "LoaiHopDongId", "NgayBaoHanhDen", "NgayBaoHanhTu", "NgayBaoLanhDen", "NgayBaoLanhTu", "NgayKy", "NgayNghiemThu", "NguoiPhuTrachChinhId", "NguoiTheoDoiId", "PhongBanPhuTrachChinhId", "SoHopDong", "SoNgay", "Ten", "ThoiHanBaoHanh", "TienDo", "TienThue", "TrangThaiId", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("08de8ae2-8eb5-87c9-4baf-8361500292e3"), new DateTimeOffset(new DateTime(2026, 3, 26, 2, 51, 19, 506, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", new Guid("08de8ae1-f818-b6fb-687a-7b0ee802f6e2"), "520.000.000", 500000000m, 520000000m, 520000000m, 1, 1774493479L, false, new Guid("12930000-0000-0000-0000-000000000001"), 3, new DateOnly(2027, 4, 14), new DateOnly(2026, 4, 14), new DateOnly(2026, 3, 31), new DateOnly(2026, 3, 25), new DateOnly(2026, 3, 27), new DateOnly(2026, 4, 15), 1, 1, 220L, "HĐ-001", 20, "dự án 03", (byte)12, "520.000.000", 20000000m, 1, null, "" },
                    { new Guid("08de8aec-f8dc-6a15-687a-7b1e60040eab"), new DateTimeOffset(new DateTime(2026, 3, 26, 4, 5, 52, 779, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", new Guid("08de8ae8-8c4d-cda7-687a-7b1a04058597"), "GHI CHÚ", 100000000m, 110000000m, 110000000m, 2, 1774497952L, false, new Guid("12930000-0000-0000-0000-000000000001"), 3, new DateOnly(2027, 3, 30), new DateOnly(2026, 3, 30), new DateOnly(2026, 3, 31), new DateOnly(2026, 3, 6), new DateOnly(2026, 3, 1), new DateOnly(2026, 3, 30), 2, 2, 220L, "HĐ/003", 30, "dự án 03", (byte)12, "TIẾN ĐỘ", 10000000m, 1, new DateTimeOffset(new DateTime(2026, 3, 26, 4, 5, 52, 779, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24" },
                    { new Guid("08de8ba9-3c5f-e033-687a-7b311402c029"), new DateTimeOffset(new DateTime(2026, 3, 27, 2, 33, 31, 184, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", new Guid("08de8ba9-024c-0844-687a-7b311402c01c"), "20.100.000.000", 20000000000m, 20100000000m, 20100000000m, 2, 1774578811L, false, new Guid("12930000-0000-0000-0000-000000000001"), 3, new DateOnly(2027, 4, 29), new DateOnly(2026, 4, 29), new DateOnly(2026, 3, 31), new DateOnly(2026, 3, 13), new DateOnly(2026, 4, 10), new DateOnly(2026, 4, 29), 2, 2, 220L, "HĐ-04/01", 20, "dự án 04", (byte)12, "20.100.000.000", 100000000m, 1, new DateTimeOffset(new DateTime(2026, 3, 27, 2, 33, 52, 381, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24" },
                    { new Guid("08de8ba9-ec59-9cb7-687a-7b311402c046"), new DateTimeOffset(new DateTime(2026, 3, 27, 2, 38, 26, 440, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", new Guid("08de8ba9-007a-9b89-687a-7b311402c017"), null, 20000000000m, 0m, 20100000000m, 2, 1774579106L, false, new Guid("12930000-0000-0000-0000-000000000001"), 6, new DateOnly(2026, 5, 29), new DateOnly(2026, 5, 29), null, null, new DateOnly(2026, 4, 10), new DateOnly(2026, 5, 29), 2, 2, 220L, "HĐ/004", 50, "dự án 04", (byte)0, null, 100000000m, 1, null, "" },
                    { new Guid("08de8baa-2aff-9d92-687a-7b311402c04c"), new DateTimeOffset(new DateTime(2026, 3, 27, 2, 40, 11, 531, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", new Guid("08de8ba7-b653-d234-687a-7b311402bfed"), null, 2000000000m, 0m, 2000000000m, 1, 1774579211L, false, new Guid("12930000-0000-0000-0000-000000000001"), 4, new DateOnly(2026, 5, 14), new DateOnly(2026, 5, 14), null, null, new DateOnly(2026, 3, 26), new DateOnly(2026, 5, 14), 1, 1, 220L, "HĐ/2026", 50, "dự án 02", (byte)0, null, 0m, 1, null, "" },
                    { new Guid("08de8e34-0e94-cbe5-687a-7b2ad003cb9e"), new DateTimeOffset(new DateTime(2026, 3, 30, 8, 12, 16, 779, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", new Guid("08de8e03-f82d-f499-687a-7b31f0054948"), "4.001.000.000", 3801000000m, 4001000000m, 4001000000m, 2, 1774858336L, false, new Guid("12930000-0000-0000-0000-000000000001"), 3, new DateOnly(2027, 8, 1), new DateOnly(2026, 8, 1), null, null, new DateOnly(2026, 4, 4), new DateOnly(2026, 8, 1), 2, 2, 220L, "HĐ/TNX2026", 120, "Dự án chiến dịch tình nguyện xanh năm 2026", (byte)12, "4.001.000.000", 200000000m, 1, new DateTimeOffset(new DateTime(2026, 3, 30, 8, 12, 31, 558, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23" }
                });

            migrationBuilder.InsertData(
                table: "HopDongPhongBanPhoiHop",
                columns: new[] { "HopDongId", "PhongBanId", "TenPhongBan" },
                values: new object[,]
                {
                    { new Guid("08de8e04-ea40-bc98-687a-7b31f0054957"), 217L, "Ban Giám đốc" },
                    { new Guid("08de8e04-ea40-bc98-687a-7b31f0054957"), 219L, "Phòng Kế hoạch - Tài chính" },
                    { new Guid("08de8e04-ea40-bc98-687a-7b31f0054957"), 221L, "Phòng Nền tảng và Dữ liệu số" },
                    { new Guid("08de8e04-ea40-bc98-687a-7b31f0054957"), 359L, "Trung Tâm Chuyển Đổi Số Khu Vực 1" },
                    { new Guid("08de8e34-4cc7-d0c2-687a-7b2ad003cba3"), 360L, "Trung Tâm Chuyển Đổi Số Khu Vực 2" }
                });

            migrationBuilder.InsertData(
                table: "PhuLucHopDong",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "HopDongId", "Index", "IsDeleted", "NgayKy", "NoiDungPhuLuc", "SoPhuLuc", "UpdatedAt", "UpdatedBy" },
                values: new object[] { new Guid("08de8e2d-6722-cc2e-687a-7b351006e48d"), new DateTimeOffset(new DateTime(2026, 3, 30, 7, 24, 38, 820, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", new Guid("08de8e04-ea40-bc98-687a-7b31f0054957"), 1774855478L, false, new DateOnly(2026, 3, 31), "PHỤ LỤC HỢP ĐỒNG", "PL-01", null, "" });

            migrationBuilder.InsertData(
                table: "HopDongPhongBanPhoiHop",
                columns: new[] { "HopDongId", "PhongBanId", "TenPhongBan" },
                values: new object[,]
                {
                    { new Guid("08de8ae2-8eb5-87c9-4baf-8361500292e3"), 288L, "Ban An toàn giao thông" },
                    { new Guid("08de8ba9-ec59-9cb7-687a-7b311402c046"), 272L, "Ban Đổi mới quản lý doanh nghiệp" },
                    { new Guid("08de8baa-2aff-9d92-687a-7b311402c04c"), 307L, "Đài Tiếng nói Nhân dân Thành phố Hồ Chí Minh" },
                    { new Guid("08de8e34-0e94-cbe5-687a-7b2ad003cb9e"), 217L, "Ban Giám đốc" },
                    { new Guid("08de8e34-0e94-cbe5-687a-7b2ad003cb9e"), 218L, "Văn phòng" },
                    { new Guid("08de8e34-0e94-cbe5-687a-7b2ad003cb9e"), 220L, "Phòng Hạ tầng số và An toàn thông tin" },
                    { new Guid("08de8e34-0e94-cbe5-687a-7b2ad003cb9e"), 358L, "Trung Tâm Tư vấn, Đào tạo và Truyền thông số" }
                });

            migrationBuilder.InsertData(
                table: "PhuLucHopDong",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "HopDongId", "Index", "IsDeleted", "NgayKy", "NoiDungPhuLuc", "SoPhuLuc", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("08de8e2c-e7d1-16e8-687a-7b351006e476"), new DateTimeOffset(new DateTime(2026, 3, 30, 7, 21, 5, 308, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "24", new Guid("08de8baa-2aff-9d92-687a-7b311402c04c"), 1774855265L, false, new DateOnly(2026, 3, 31), "phụ lục hợp đồng 01", "PL-01", null, "" },
                    { new Guid("08de8e34-65f2-3572-687a-7b2ad003cba4"), new DateTimeOffset(new DateTime(2026, 3, 30, 8, 14, 43, 305, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23", new Guid("08de8e34-0e94-cbe5-687a-7b2ad003cb9e"), 1774858483L, false, new DateOnly(2026, 3, 31), "thông tin phụ lục hợp đồng - chỉnh sửa", "PL/03-2026", new DateTimeOffset(new DateTime(2026, 3, 30, 8, 15, 38, 777, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "23" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLog_EntityId",
                table: "AuditLog",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLog_EntityName",
                table: "AuditLog",
                column: "EntityName");

            migrationBuilder.CreateIndex(
                name: "IX_AuditLog_EntityName_EntityId",
                table: "AuditLog",
                columns: new[] { "EntityName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AuditLog_Index",
                table: "AuditLog",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoTienDo_Index",
                table: "BaoCaoTienDo",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoTienDo_NgayBaoCao",
                table: "BaoCaoTienDo",
                column: "NgayBaoCao");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoTienDo_NguoiBaoCaoId",
                table: "BaoCaoTienDo",
                column: "NguoiBaoCaoId");

            migrationBuilder.CreateIndex(
                name: "IX_BaoCaoTienDo_TienDoId",
                table: "BaoCaoTienDo",
                column: "TienDoId");

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_DuAnId",
                table: "CongViec",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_Index",
                table: "CongViec",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_CongViec_TrangThaiId",
                table: "CongViec",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucGiamDoc_DonViId",
                table: "DanhMucGiamDoc",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucGiamDoc_Index",
                table: "DanhMucGiamDoc",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucGiamDoc_Ma",
                table: "DanhMucGiamDoc",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucGiamDoc_PhongBanId",
                table: "DanhMucGiamDoc",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucGiamDoc_UserPortalId_DonViId_PhongBanId",
                table: "DanhMucGiamDoc",
                columns: new[] { "UserPortalId", "DonViId", "PhongBanId" },
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiChiPhi_Index",
                table: "DanhMucLoaiChiPhi",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiChiPhi_IsDefault",
                table: "DanhMucLoaiChiPhi",
                column: "IsDefault",
                unique: true,
                filter: "[IsDefault] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiChiPhi_Ma",
                table: "DanhMucLoaiChiPhi",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiHopDong_Index",
                table: "DanhMucLoaiHopDong",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiHopDong_IsDefault",
                table: "DanhMucLoaiHopDong",
                column: "IsDefault",
                unique: true,
                filter: "[IsDefault] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiHopDong_Ma",
                table: "DanhMucLoaiHopDong",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiThanhToan_Index",
                table: "DanhMucLoaiThanhToan",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiThanhToan_IsDefault",
                table: "DanhMucLoaiThanhToan",
                column: "IsDefault",
                unique: true,
                filter: "[IsDefault] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiThanhToan_Ma",
                table: "DanhMucLoaiThanhToan",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiTrangThai_Index",
                table: "DanhMucLoaiTrangThai",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucLoaiTrangThai_Ma",
                table: "DanhMucLoaiTrangThai",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNguoiPhuTrach_DonViId",
                table: "DanhMucNguoiPhuTrach",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNguoiPhuTrach_Index",
                table: "DanhMucNguoiPhuTrach",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNguoiPhuTrach_Ma",
                table: "DanhMucNguoiPhuTrach",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNguoiPhuTrach_PhongBanId",
                table: "DanhMucNguoiPhuTrach",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNguoiPhuTrach_UserPortalId_DonViId_PhongBanId",
                table: "DanhMucNguoiPhuTrach",
                columns: new[] { "UserPortalId", "DonViId", "PhongBanId" },
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNguoiTheoDoi_DonViId",
                table: "DanhMucNguoiTheoDoi",
                column: "DonViId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNguoiTheoDoi_Index",
                table: "DanhMucNguoiTheoDoi",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNguoiTheoDoi_Ma",
                table: "DanhMucNguoiTheoDoi",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNguoiTheoDoi_PhongBanId",
                table: "DanhMucNguoiTheoDoi",
                column: "PhongBanId");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucNguoiTheoDoi_UserPortalId_DonViId_PhongBanId",
                table: "DanhMucNguoiTheoDoi",
                columns: new[] { "UserPortalId", "DonViId", "PhongBanId" },
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTrangThai_Index",
                table: "DanhMucTrangThai",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTrangThai_LoaiTrangThaiId_IsDefault",
                table: "DanhMucTrangThai",
                columns: new[] { "LoaiTrangThaiId", "IsDefault" },
                unique: true,
                filter: "[IsDefault] = 1");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTrangThai_Ma",
                table: "DanhMucTrangThai",
                column: "Ma",
                filter: "[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTrangThai_Ma_LoaiTrangThaiId",
                table: "DanhMucTrangThai",
                columns: new[] { "Ma", "LoaiTrangThaiId" },
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> '' AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_DanhMucTrangThai_MaLoaiTrangThai",
                table: "DanhMucTrangThai",
                column: "MaLoaiTrangThai");

            migrationBuilder.CreateIndex(
                name: "IX_DoanhNghiep_TaxCode",
                table: "DoanhNghiep",
                column: "TaxCode",
                unique: true,
                filter: "[TaxCode] IS NOT NULL AND [TaxCode] <> ''");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_GiamDocId",
                table: "DuAn",
                column: "GiamDocId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_Index",
                table: "DuAn",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_KhachHangId",
                table: "DuAn",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_NguoiPhuTrachChinhId",
                table: "DuAn",
                column: "NguoiPhuTrachChinhId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_NguoiTheoDoiId",
                table: "DuAn",
                column: "NguoiTheoDoiId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_TrangThaiId",
                table: "DuAn",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_ThuTien_DuAnId",
                table: "DuAn_ThuTien",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_ThuTien_HopDongId",
                table: "DuAn_ThuTien",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_ThuTien_Index",
                table: "DuAn_ThuTien",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_ThuTien_LoaiThanhToanId",
                table: "DuAn_ThuTien",
                column: "LoaiThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_XuatHoaDon_DuAnId",
                table: "DuAn_XuatHoaDon",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_XuatHoaDon_HopDongId",
                table: "DuAn_XuatHoaDon",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_XuatHoaDon_Index",
                table: "DuAn_XuatHoaDon",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_XuatHoaDon_LoaiThanhToanId",
                table: "DuAn_XuatHoaDon",
                column: "LoaiThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_DuAnId",
                table: "HopDong",
                column: "DuAnId",
                unique: true,
                filter: "[DuAnId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GiamDocId",
                table: "HopDong",
                column: "GiamDocId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_Index",
                table: "HopDong",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_KhachHangId",
                table: "HopDong",
                column: "KhachHangId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_LoaiHopDongId",
                table: "HopDong",
                column: "LoaiHopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_NguoiPhuTrachChinhId",
                table: "HopDong",
                column: "NguoiPhuTrachChinhId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_NguoiTheoDoiId",
                table: "HopDong",
                column: "NguoiTheoDoiId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_SoHopDong",
                table: "HopDong",
                column: "SoHopDong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_TrangThaiId",
                table: "HopDong",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ChiPhi_HopDongId",
                table: "HopDong_ChiPhi",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ChiPhi_Index",
                table: "HopDong_ChiPhi",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ChiPhi_LoaiChiPhiId",
                table: "HopDong_ChiPhi",
                column: "LoaiChiPhiId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ThuTien_HopDongId",
                table: "HopDong_ThuTien",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ThuTien_Index",
                table: "HopDong_ThuTien",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_ThuTien_LoaiThanhToanId",
                table: "HopDong_ThuTien",
                column: "LoaiThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_XuatHoaDon_HopDongId",
                table: "HopDong_XuatHoaDon",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_XuatHoaDon_Index",
                table: "HopDong_XuatHoaDon",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_XuatHoaDon_LoaiThanhToanId",
                table: "HopDong_XuatHoaDon",
                column: "LoaiThanhToanId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_DoanhNghiepId",
                table: "KhachHang",
                column: "DoanhNghiepId");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_Ma",
                table: "KhachHang",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Used] = 1 AND [IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_KhoKhanVuongMac_HopDongId",
                table: "KhoKhanVuongMac",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoKhanVuongMac_Index",
                table: "KhoKhanVuongMac",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_KhoKhanVuongMac_TienDoId",
                table: "KhoKhanVuongMac",
                column: "TienDoId");

            migrationBuilder.CreateIndex(
                name: "IX_KhoKhanVuongMac_TrangThaiId",
                table: "KhoKhanVuongMac",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_PhuLucHopDong_HopDongId_SoPhuLuc",
                table: "PhuLucHopDong",
                columns: new[] { "HopDongId", "SoPhuLuc" },
                unique: true,
                filter: "[IsDeleted] = 0");

            migrationBuilder.CreateIndex(
                name: "IX_PhuLucHopDong_Index",
                table: "PhuLucHopDong",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_TienDo_HopDongId",
                table: "TienDo",
                column: "HopDongId");

            migrationBuilder.CreateIndex(
                name: "IX_TienDo_Index",
                table: "TienDo",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_TienDo_TrangThaiId",
                table: "TienDo",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_Platform",
                table: "UserSession",
                column: "Platform");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_UserName",
                table: "UserSession",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_UserName_Platform",
                table: "UserSession",
                columns: new[] { "UserName", "Platform" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLog");

            migrationBuilder.DropTable(
                name: "BaoCaoTienDo");

            migrationBuilder.DropTable(
                name: "CongViec");

            migrationBuilder.DropTable(
                name: "DuAn_ThuTien");

            migrationBuilder.DropTable(
                name: "DuAn_XuatHoaDon");

            migrationBuilder.DropTable(
                name: "DuAnPhongBanPhoiHop");

            migrationBuilder.DropTable(
                name: "HopDong_ChiPhi");

            migrationBuilder.DropTable(
                name: "HopDong_ThuTien");

            migrationBuilder.DropTable(
                name: "HopDong_XuatHoaDon");

            migrationBuilder.DropTable(
                name: "HopDongPhongBanPhoiHop");

            migrationBuilder.DropTable(
                name: "KhoKhanVuongMac");

            migrationBuilder.DropTable(
                name: "PhuLucHopDong");

            migrationBuilder.DropTable(
                name: "UserSession");

            migrationBuilder.DropTable(
                name: "DanhMucLoaiChiPhi");

            migrationBuilder.DropTable(
                name: "DanhMucLoaiThanhToan");

            migrationBuilder.DropTable(
                name: "TienDo");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "DanhMucLoaiHopDong");

            migrationBuilder.DropTable(
                name: "DuAn");

            migrationBuilder.DropTable(
                name: "DanhMucGiamDoc");

            migrationBuilder.DropTable(
                name: "DanhMucNguoiPhuTrach");

            migrationBuilder.DropTable(
                name: "DanhMucNguoiTheoDoi");

            migrationBuilder.DropTable(
                name: "DanhMucTrangThai");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "DanhMucLoaiTrangThai");

            migrationBuilder.DropTable(
                name: "DoanhNghiep");
        }
    }
}
