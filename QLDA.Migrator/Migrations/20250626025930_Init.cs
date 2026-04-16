using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            
        }
        //
        // protected override void Up(MigrationBuilder migrationBuilder)
        // {
        //     migrationBuilder.CreateTable(
        //         name: "DmChucVu",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmChucVu", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmChuDauTu",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmChuDauTu", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmHinhThucDauTu",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmHinhThucDauTu", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmHinhThucLuaChonNhaThau",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmHinhThucLuaChonNhaThau", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmHinhThucQuanLy",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmHinhThucQuanLy", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmLinhVuc",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmLinhVuc", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmLoaiDuAn",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmLoaiDuAn", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmLoaiDuAnTheoNam",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmLoaiDuAnTheoNam", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmLoaiGoiThau",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmLoaiGoiThau", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmLoaiHopDong",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmLoaiHopDong", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmLoaiQuyetDinh",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmLoaiQuyetDinh", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmLoaiVanBan",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmLoaiVanBan", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmNguonVon",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmNguonVon", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmNhaThau",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DiaChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             MaSoThue = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             SoDienThoai = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NguoiDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmNhaThau", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmNhomDuAn",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmNhomDuAn", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmPhuongThucChonGoiThau",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmPhuongThucChonGoiThau", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmQuyTrinh",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             MacDinh = table.Column<bool>(type: "bit", nullable: false),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmQuyTrinh", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmTinhTrangKhoKhan",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmTinhTrangKhoKhan", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmTrangThaiDuAn",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmTrangThaiDuAn", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmTrangThaiTienDo",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmTrangThaiTienDo", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "E_ManHinh",
        //         columns: table => new
        //         {
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             Label = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_E_ManHinh", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "TepDinhKem",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             GroupId = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             GroupType = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Size = table.Column<long>(type: "bigint", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_TepDinhKem", x => x.Id);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "USER_MASTER",
        //         columns: table => new
        //         {
        //             User_MasterID = table.Column<long>(type: "bigint", nullable: false),
        //             UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //             HoTen = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
        //             PhongBanID = table.Column<long>(type: "bigint", nullable: true),
        //             DonViID = table.Column<long>(type: "bigint", nullable: true),
        //             User_PortalID = table.Column<long>(type: "bigint", nullable: true),
        //             CanBoID = table.Column<long>(type: "bigint", nullable: true),
        //             LaDonViChinh = table.Column<bool>(type: "bit", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmBuoc",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             ParentId = table.Column<int>(type: "int", nullable: true),
        //             Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Level = table.Column<int>(type: "int", nullable: false),
        //             QuyTrinhId = table.Column<int>(type: "int", nullable: false),
        //             PartialView = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmBuoc", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_DmBuoc_DmQuyTrinh_QuyTrinhId",
        //                 column: x => x.QuyTrinhId,
        //                 principalTable: "DmQuyTrinh",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmBuocManHinh",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             BuocId = table.Column<int>(type: "int", nullable: false),
        //             ManHinhId = table.Column<int>(type: "int", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmBuocManHinh", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_DmBuocManHinh_DmBuoc_BuocId",
        //                 column: x => x.BuocId,
        //                 principalTable: "DmBuoc",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_DmBuocManHinh_E_ManHinh_ManHinhId",
        //                 column: x => x.ManHinhId,
        //                 principalTable: "E_ManHinh",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DmBuocTrangThaiTienDo",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             BuocId = table.Column<int>(type: "int", nullable: false),
        //             TrangThaiId = table.Column<int>(type: "int", nullable: false),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DmBuocTrangThaiTienDo", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_DmBuocTrangThaiTienDo_DmBuoc_BuocId",
        //                 column: x => x.BuocId,
        //                 principalTable: "DmBuoc",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_DmBuocTrangThaiTienDo_DmTrangThaiTienDo_TrangThaiId",
        //                 column: x => x.TrangThaiId,
        //                 principalTable: "DmTrangThaiTienDo",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DuAn",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             ParentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        //             Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Level = table.Column<int>(type: "int", nullable: false),
        //             TenDuAn = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             DiaDiem = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             ChuDauTuId = table.Column<int>(type: "int", nullable: true),
        //             ThoiGianKhoiCong = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             ThoiGianHoanThanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             MaDuAn = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             MaNganSach = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             DuAnTrongDiem = table.Column<bool>(type: "bit", nullable: false),
        //             LinhVucId = table.Column<int>(type: "int", nullable: true),
        //             NhomDuAnId = table.Column<int>(type: "int", nullable: true),
        //             NangLucThietKe = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             QuyMoDuAn = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             HinhThucQuanLyDuAnId = table.Column<int>(type: "int", nullable: true),
        //             HinhThucDauTuId = table.Column<int>(type: "int", nullable: true),
        //             LoaiDuAnId = table.Column<int>(type: "int", nullable: true),
        //             TongMucDauTu = table.Column<long>(type: "bigint", nullable: true),
        //             QuyTrinhId = table.Column<int>(type: "int", nullable: true),
        //             BuocHienTaiId = table.Column<int>(type: "int", nullable: true),
        //             TrangThaiHienTaiId = table.Column<int>(type: "int", nullable: true),
        //             TrangThaiDuAnId = table.Column<int>(type: "int", nullable: true),
        //             LoaiDuAnTheoNamId = table.Column<int>(type: "int", nullable: true),
        //             GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             TrangThaiTienDoId = table.Column<int>(type: "int", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DuAn", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmBuoc_BuocHienTaiId",
        //                 column: x => x.BuocHienTaiId,
        //                 principalTable: "DmBuoc",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmChuDauTu_ChuDauTuId",
        //                 column: x => x.ChuDauTuId,
        //                 principalTable: "DmChuDauTu",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmHinhThucDauTu_HinhThucDauTuId",
        //                 column: x => x.HinhThucDauTuId,
        //                 principalTable: "DmHinhThucDauTu",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmHinhThucQuanLy_HinhThucQuanLyDuAnId",
        //                 column: x => x.HinhThucQuanLyDuAnId,
        //                 principalTable: "DmHinhThucQuanLy",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmLinhVuc_LinhVucId",
        //                 column: x => x.LinhVucId,
        //                 principalTable: "DmLinhVuc",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmLoaiDuAnTheoNam_LoaiDuAnTheoNamId",
        //                 column: x => x.LoaiDuAnTheoNamId,
        //                 principalTable: "DmLoaiDuAnTheoNam",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmLoaiDuAn_LoaiDuAnId",
        //                 column: x => x.LoaiDuAnId,
        //                 principalTable: "DmLoaiDuAn",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmNhomDuAn_NhomDuAnId",
        //                 column: x => x.NhomDuAnId,
        //                 principalTable: "DmNhomDuAn",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmQuyTrinh_QuyTrinhId",
        //                 column: x => x.QuyTrinhId,
        //                 principalTable: "DmQuyTrinh",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmTrangThaiDuAn_TrangThaiDuAnId",
        //                 column: x => x.TrangThaiDuAnId,
        //                 principalTable: "DmTrangThaiDuAn",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAn_DmTrangThaiTienDo_TrangThaiTienDoId",
        //                 column: x => x.TrangThaiTienDoId,
        //                 principalTable: "DmTrangThaiTienDo",
        //                 principalColumn: "Id");
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "BaoCaoTienDo",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             Ngay = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_BaoCaoTienDo", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_BaoCaoTienDo_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DuAnBuoc",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             TenBuoc = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             ParentId = table.Column<int>(type: "int", nullable: true),
        //             Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Level = table.Column<int>(type: "int", nullable: false),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             QuyTrinhId = table.Column<int>(type: "int", nullable: false),
        //             PartialView = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             TrangThaiId = table.Column<int>(type: "int", nullable: true),
        //             NgayDuKienBatDau = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NgayDuKienKetThuc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NgayThucTeBatDau = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NgayThucTeKetThuc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             GhiChu = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             TrachNhiemThucHien = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             IsKetThuc = table.Column<bool>(type: "bit", nullable: false),
        //             Stt = table.Column<int>(type: "int", nullable: false),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DuAnBuoc", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_DuAnBuoc_DmBuoc_BuocId",
        //                 column: x => x.BuocId,
        //                 principalTable: "DmBuoc",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_DuAnBuoc_DmQuyTrinh_QuyTrinhId",
        //                 column: x => x.QuyTrinhId,
        //                 principalTable: "DmQuyTrinh",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_DuAnBuoc_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DuAnNguonVon",
        //         columns: table => new
        //         {
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             NguonVonId = table.Column<int>(type: "int", nullable: false),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DuAnNguonVon", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_DuAnNguonVon_DmNguonVon_NguonVonId",
        //                 column: x => x.NguonVonId,
        //                 principalTable: "DmNguonVon",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_DuAnNguonVon_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "KeHoachLuaChonNhaThau",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             SoQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayQuyetDinh = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             TrichYeu = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayKy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NguoiKy = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_KeHoachLuaChonNhaThau", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_KeHoachLuaChonNhaThau_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "KhoKhanVuongMac",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             Ngay = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             TinhTrangId = table.Column<int>(type: "int", nullable: true),
        //             HuongXuLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             KetQuaXuLy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayXuLy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_KhoKhanVuongMac", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_KhoKhanVuongMac_DmTinhTrangKhoKhan_TinhTrangId",
        //                 column: x => x.TinhTrangId,
        //                 principalTable: "DmTinhTrangKhoKhan",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_KhoKhanVuongMac_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "PheDuyetDuToan",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             SoVanBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayVanBan = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             TrichYeu = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayKy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NguoiKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             ChucVuId = table.Column<int>(type: "int", nullable: true),
        //             GiaTriDuThau = table.Column<long>(type: "bigint", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_PheDuyetDuToan", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_PheDuyetDuToan_DmChucVu_ChucVuId",
        //                 column: x => x.ChucVuId,
        //                 principalTable: "DmChucVu",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_PheDuyetDuToan_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "QuaTrinhXuLy",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             Loai = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             ChiuTrachNhiemXuLyId = table.Column<long>(type: "bigint", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_QuaTrinhXuLy", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_QuaTrinhXuLy_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "QuyetDinhDuyetDuAn",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             SoQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayQuyetDinh = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             TrichYeu = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             CoQuanQuyetDinhDauTu = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_QuyetDinhDuyetDuAn", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_QuyetDinhDuyetDuAn_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "QuyetDinhDuyetQuyetToan",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             SoQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayQuyetDinh = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CoQuanQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             TrichYeu = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayKy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NguoiKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             GiaTri = table.Column<long>(type: "bigint", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_QuyetDinhDuyetQuyetToan", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_QuyetDinhDuyetQuyetToan_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "ThanhToan",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             KhongCoHopDong = table.Column<bool>(type: "bit", nullable: false),
        //             SoHoaDon = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayHoaDon = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             GiaTri = table.Column<long>(type: "bigint", nullable: true),
        //             NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_ThanhToan", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_ThanhToan_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "VanBanChuTruong",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             SoVanBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayVanBan = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             TrichYeu = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             LoaiVanBanId = table.Column<int>(type: "int", nullable: true),
        //             NgayKy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NguoiKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             ChucVuId = table.Column<int>(type: "int", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_VanBanChuTruong", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_VanBanChuTruong_DmChucVu_ChucVuId",
        //                 column: x => x.ChucVuId,
        //                 principalTable: "DmChucVu",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_VanBanChuTruong_DmLoaiVanBan_LoaiVanBanId",
        //                 column: x => x.LoaiVanBanId,
        //                 principalTable: "DmLoaiVanBan",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_VanBanChuTruong_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "VanBanPhapLy",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             NgayVanBan = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             SoVanBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             TrichYeu = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             LoaiVanBanId = table.Column<int>(type: "int", nullable: true),
        //             NgayKy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NguoiKy = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             ChucVuId = table.Column<int>(type: "int", nullable: true),
        //             ChuDauTuId = table.Column<int>(type: "int", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_VanBanPhapLy", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_VanBanPhapLy_DmChuDauTu_ChuDauTuId",
        //                 column: x => x.ChuDauTuId,
        //                 principalTable: "DmChuDauTu",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_VanBanPhapLy_DmChucVu_ChucVuId",
        //                 column: x => x.ChucVuId,
        //                 principalTable: "DmChucVu",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_VanBanPhapLy_DmLoaiVanBan_LoaiVanBanId",
        //                 column: x => x.LoaiVanBanId,
        //                 principalTable: "DmLoaiVanBan",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_VanBanPhapLy_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DuAnBuocManHinh",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             BuocId = table.Column<int>(type: "int", nullable: false),
        //             ManHinhId = table.Column<int>(type: "int", nullable: false),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DuAnBuocManHinh", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_DuAnBuocManHinh_DuAnBuoc_BuocId",
        //                 column: x => x.BuocId,
        //                 principalTable: "DuAnBuoc",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_DuAnBuocManHinh_E_ManHinh_ManHinhId",
        //                 column: x => x.ManHinhId,
        //                 principalTable: "E_ManHinh",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "DuAnBuocTrangThaiTienDo",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             BuocId = table.Column<int>(type: "int", nullable: false),
        //             TrangThaiId = table.Column<int>(type: "int", nullable: false),
        //             Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
        //             Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
        //             Stt = table.Column<int>(type: "int", nullable: true),
        //             Used = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_DuAnBuocTrangThaiTienDo", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_DuAnBuocTrangThaiTienDo_DmTrangThaiTienDo_TrangThaiId",
        //                 column: x => x.TrangThaiId,
        //                 principalTable: "DmTrangThaiTienDo",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_DuAnBuocTrangThaiTienDo_DuAnBuoc_BuocId",
        //                 column: x => x.BuocId,
        //                 principalTable: "DuAnBuoc",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "GoiThau",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             KeHoachLuaChonNhaThauId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             GiaTri = table.Column<long>(type: "bigint", nullable: true),
        //             LoaiGoiThauId = table.Column<int>(type: "int", nullable: true),
        //             HinhThucLuaChonNhaThauId = table.Column<int>(type: "int", nullable: true),
        //             PhuongThucChonGoiThauId = table.Column<int>(type: "int", nullable: true),
        //             ThoiGianLuaNhaThau = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             LoaiHopDongId = table.Column<int>(type: "int", nullable: true),
        //             ThoiGianHopDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NguonVonId = table.Column<int>(type: "int", nullable: true),
        //             NgayEHSMT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NgayMoThau = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             DaDuyet = table.Column<bool>(type: "bit", nullable: false),
        //             DanhMucHinhThucLuaChonNhaThauId = table.Column<int>(type: "int", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_GoiThau", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_GoiThau_DmHinhThucLuaChonNhaThau_DanhMucHinhThucLuaChonNhaThauId",
        //                 column: x => x.DanhMucHinhThucLuaChonNhaThauId,
        //                 principalTable: "DmHinhThucLuaChonNhaThau",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_GoiThau_DmHinhThucLuaChonNhaThau_HinhThucLuaChonNhaThauId",
        //                 column: x => x.HinhThucLuaChonNhaThauId,
        //                 principalTable: "DmHinhThucLuaChonNhaThau",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_GoiThau_DmLoaiGoiThau_LoaiGoiThauId",
        //                 column: x => x.LoaiGoiThauId,
        //                 principalTable: "DmLoaiGoiThau",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_GoiThau_DmLoaiHopDong_LoaiHopDongId",
        //                 column: x => x.LoaiHopDongId,
        //                 principalTable: "DmLoaiHopDong",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_GoiThau_DmNguonVon_NguonVonId",
        //                 column: x => x.NguonVonId,
        //                 principalTable: "DmNguonVon",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_GoiThau_DmPhuongThucChonGoiThau_PhuongThucChonGoiThauId",
        //                 column: x => x.PhuongThucChonGoiThauId,
        //                 principalTable: "DmPhuongThucChonGoiThau",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_GoiThau_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_GoiThau_KeHoachLuaChonNhaThau_KeHoachLuaChonNhaThauId",
        //                 column: x => x.KeHoachLuaChonNhaThauId,
        //                 principalTable: "KeHoachLuaChonNhaThau",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "QuyetDinhDuyetKHLCNT",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             KeHoachLuaChonNhaThauId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        //             SoQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayQuyetDinh = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CoQuanQuyetDinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             TrichYeu = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayKy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NguoiKy = table.Column<string>(type: "nvarchar(max)", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_QuyetDinhDuyetKHLCNT", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_QuyetDinhDuyetKHLCNT_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_QuyetDinhDuyetKHLCNT_KeHoachLuaChonNhaThau_KeHoachLuaChonNhaThauId",
        //                 column: x => x.KeHoachLuaChonNhaThauId,
        //                 principalTable: "KeHoachLuaChonNhaThau",
        //                 principalColumn: "Id");
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "QuyetDinhDuyetDuAnNguonVon",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             QuyetDinhDuyetDuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             NguonVonId = table.Column<int>(type: "int", nullable: false),
        //             GiaTri = table.Column<long>(type: "bigint", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_QuyetDinhDuyetDuAnNguonVon", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_QuyetDinhDuyetDuAnNguonVon_QuyetDinhDuyetDuAn_QuyetDinhDuyetDuAnId",
        //                 column: x => x.QuyetDinhDuyetDuAnId,
        //                 principalTable: "QuyetDinhDuyetDuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "HopDong",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             GoiThauId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             SoHopDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayKy = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             GiaTri = table.Column<long>(type: "bigint", nullable: true),
        //             NgayHieuLuc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NgayDuKienKetThuc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             LoaiHopDongId = table.Column<int>(type: "int", nullable: true),
        //             DonViThucHienId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        //             ThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        //             IsBienBan = table.Column<bool>(type: "bit", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_HopDong", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_HopDong_DmLoaiHopDong_LoaiHopDongId",
        //                 column: x => x.LoaiHopDongId,
        //                 principalTable: "DmLoaiHopDong",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_HopDong_DmNhaThau_DonViThucHienId",
        //                 column: x => x.DonViThucHienId,
        //                 principalTable: "DmNhaThau",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_HopDong_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_HopDong_GoiThau_GoiThauId",
        //                 column: x => x.GoiThauId,
        //                 principalTable: "GoiThau",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_HopDong_ThanhToan_ThanhToanId",
        //                 column: x => x.ThanhToanId,
        //                 principalTable: "ThanhToan",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "KetQuaTrungThau",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             GoiThauId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             GiaTriTrungThau = table.Column<long>(type: "bigint", nullable: false),
        //             DonViTrungThauId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        //             SoNgayTrienKhai = table.Column<long>(type: "bigint", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_KetQuaTrungThau", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_KetQuaTrungThau_DmNhaThau_DonViTrungThauId",
        //                 column: x => x.DonViTrungThauId,
        //                 principalTable: "DmNhaThau",
        //                 principalColumn: "Id");
        //             table.ForeignKey(
        //                 name: "FK_KetQuaTrungThau_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_KetQuaTrungThau_GoiThau_GoiThauId",
        //                 column: x => x.GoiThauId,
        //                 principalTable: "GoiThau",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "QuyetDinhDuyetDuAnHangMuc",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             QuyetDinhDuyetDuAnNguonVonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             TenHangMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             QuyMoHangMuc = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             TongMucDauTu = table.Column<long>(type: "bigint", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_QuyetDinhDuyetDuAnHangMuc", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_QuyetDinhDuyetDuAnHangMuc_QuyetDinhDuyetDuAnNguonVon_QuyetDinhDuyetDuAnNguonVonId",
        //                 column: x => x.QuyetDinhDuyetDuAnNguonVonId,
        //                 principalTable: "QuyetDinhDuyetDuAnNguonVon",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "NghiemThu",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        //             SoBienBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Dot = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Ngay = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             ThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_NghiemThu", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_NghiemThu_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_NghiemThu_HopDong_HopDongId",
        //                 column: x => x.HopDongId,
        //                 principalTable: "HopDong",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //             table.ForeignKey(
        //                 name: "FK_NghiemThu_ThanhToan_ThanhToanId",
        //                 column: x => x.ThanhToanId,
        //                 principalTable: "ThanhToan",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "PhuLucHopDong",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             SoPhuLucHopDong = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             Ngay = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        //             GiaTri = table.Column<long>(type: "bigint", nullable: true),
        //             NgayDuKienKetThuc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             ThanhToanId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_PhuLucHopDong", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_PhuLucHopDong_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_PhuLucHopDong_HopDong_HopDongId",
        //                 column: x => x.HopDongId,
        //                 principalTable: "HopDong",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //             table.ForeignKey(
        //                 name: "FK_PhuLucHopDong_ThanhToan_ThanhToanId",
        //                 column: x => x.ThanhToanId,
        //                 principalTable: "ThanhToan",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "TamUng",
        //         columns: table => new
        //         {
        //             UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
        //             Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
        //             DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             BuocId = table.Column<int>(type: "int", nullable: true),
        //             HopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
        //             SoPhieuChi = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             GiaTri = table.Column<long>(type: "bigint", nullable: true),
        //             NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true),
        //             NgayTamUng = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_TamUng", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_TamUng_DuAn_DuAnId",
        //                 column: x => x.DuAnId,
        //                 principalTable: "DuAn",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_TamUng_HopDong_HopDongId",
        //                 column: x => x.HopDongId,
        //                 principalTable: "HopDong",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });
        //
        //     migrationBuilder.CreateTable(
        //         name: "NghiemThu_PhuLucHopDong",
        //         columns: table => new
        //         {
        //             Id = table.Column<int>(type: "int", nullable: false)
        //                 .Annotation("SqlServer:Identity", "1, 1"),
        //             NghiemThuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             PhuLucHopDongId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
        //             CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
        //             UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
        //             UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
        //             IsDeleted = table.Column<bool>(type: "bit", nullable: false),
        //             Index = table.Column<long>(type: "bigint", nullable: false)
        //         },
        //         constraints: table =>
        //         {
        //             table.PrimaryKey("PK_NghiemThu_PhuLucHopDong", x => x.Id);
        //             table.ForeignKey(
        //                 name: "FK_NghiemThu_PhuLucHopDong_NghiemThu_NghiemThuId",
        //                 column: x => x.NghiemThuId,
        //                 principalTable: "NghiemThu",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Cascade);
        //             table.ForeignKey(
        //                 name: "FK_NghiemThu_PhuLucHopDong_PhuLucHopDong_PhuLucHopDongId",
        //                 column: x => x.PhuLucHopDongId,
        //                 principalTable: "PhuLucHopDong",
        //                 principalColumn: "Id",
        //                 onDelete: ReferentialAction.Restrict);
        //         });
        //
        //     migrationBuilder.InsertData(
        //         table: "DmLoaiDuAnTheoNam",
        //         columns: new[] { "Id", "CreatedBy", "IsDeleted", "Ma", "Mota", "Stt", "Ten", "UpdatedAt", "UpdatedBy", "UpdatedDateTime", "Used" },
        //         values: new object[,]
        //         {
        //             { 1, "", false, "CBDT", null, null, "Chuẩn bị đầu tư", null, "", null, false },
        //             { 2, "", false, "CT", null, null, "Chuyển tiếp", null, "", null, false },
        //             { 3, "", false, "KCM", null, null, "Khởi công mới", null, "", null, false },
        //             { 4, "", false, "KLTD", null, null, "Khối lượng tồn đọng", null, "", null, false }
        //         });
        //
        //     migrationBuilder.InsertData(
        //         table: "DmTrangThaiDuAn",
        //         columns: new[] { "Id", "CreatedBy", "IsDeleted", "Ma", "Mota", "Stt", "Ten", "UpdatedAt", "UpdatedBy", "UpdatedDateTime", "Used" },
        //         values: new object[,]
        //         {
        //             { 1, "", false, "DTH", null, null, "Đang thực hiện", null, "", null, false },
        //             { 2, "", false, "PDDT", null, null, "Đã phê duyệt đầu tư", null, "", null, false },
        //             { 3, "", false, "HT", null, null, "Đã hoàn thành", null, "", null, false },
        //             { 4, "", false, "TD", null, null, "Tạm dừng", null, "", null, false }
        //         });
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_BaoCaoTienDo_DuAnId",
        //         table: "BaoCaoTienDo",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_BaoCaoTienDo_Index",
        //         table: "BaoCaoTienDo",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmBuoc_Index",
        //         table: "DmBuoc",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmBuoc_QuyTrinhId",
        //         table: "DmBuoc",
        //         column: "QuyTrinhId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmBuocManHinh_BuocId",
        //         table: "DmBuocManHinh",
        //         column: "BuocId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmBuocManHinh_Index",
        //         table: "DmBuocManHinh",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmBuocManHinh_ManHinhId",
        //         table: "DmBuocManHinh",
        //         column: "ManHinhId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmBuocTrangThaiTienDo_BuocId",
        //         table: "DmBuocTrangThaiTienDo",
        //         column: "BuocId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmBuocTrangThaiTienDo_Index",
        //         table: "DmBuocTrangThaiTienDo",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmBuocTrangThaiTienDo_TrangThaiId",
        //         table: "DmBuocTrangThaiTienDo",
        //         column: "TrangThaiId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmChucVu_Index",
        //         table: "DmChucVu",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmChuDauTu_Index",
        //         table: "DmChuDauTu",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmHinhThucDauTu_Index",
        //         table: "DmHinhThucDauTu",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmHinhThucLuaChonNhaThau_Index",
        //         table: "DmHinhThucLuaChonNhaThau",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmHinhThucQuanLy_Index",
        //         table: "DmHinhThucQuanLy",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmLinhVuc_Index",
        //         table: "DmLinhVuc",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmLoaiDuAn_Index",
        //         table: "DmLoaiDuAn",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmLoaiDuAnTheoNam_Index",
        //         table: "DmLoaiDuAnTheoNam",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmLoaiGoiThau_Index",
        //         table: "DmLoaiGoiThau",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmLoaiHopDong_Index",
        //         table: "DmLoaiHopDong",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmLoaiQuyetDinh_Index",
        //         table: "DmLoaiQuyetDinh",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmLoaiVanBan_Index",
        //         table: "DmLoaiVanBan",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmNguonVon_Index",
        //         table: "DmNguonVon",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmNhaThau_Index",
        //         table: "DmNhaThau",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmNhomDuAn_Index",
        //         table: "DmNhomDuAn",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmPhuongThucChonGoiThau_Index",
        //         table: "DmPhuongThucChonGoiThau",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmQuyTrinh_Index",
        //         table: "DmQuyTrinh",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmTinhTrangKhoKhan_Index",
        //         table: "DmTinhTrangKhoKhan",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmTrangThaiDuAn_Index",
        //         table: "DmTrangThaiDuAn",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DmTrangThaiTienDo_Index",
        //         table: "DmTrangThaiTienDo",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_BuocHienTaiId",
        //         table: "DuAn",
        //         column: "BuocHienTaiId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_ChuDauTuId",
        //         table: "DuAn",
        //         column: "ChuDauTuId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_HinhThucDauTuId",
        //         table: "DuAn",
        //         column: "HinhThucDauTuId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_HinhThucQuanLyDuAnId",
        //         table: "DuAn",
        //         column: "HinhThucQuanLyDuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_Index",
        //         table: "DuAn",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_LinhVucId",
        //         table: "DuAn",
        //         column: "LinhVucId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_LoaiDuAnId",
        //         table: "DuAn",
        //         column: "LoaiDuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_LoaiDuAnTheoNamId",
        //         table: "DuAn",
        //         column: "LoaiDuAnTheoNamId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_NhomDuAnId",
        //         table: "DuAn",
        //         column: "NhomDuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_QuyTrinhId",
        //         table: "DuAn",
        //         column: "QuyTrinhId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_TrangThaiDuAnId",
        //         table: "DuAn",
        //         column: "TrangThaiDuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAn_TrangThaiTienDoId",
        //         table: "DuAn",
        //         column: "TrangThaiTienDoId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnBuoc_BuocId",
        //         table: "DuAnBuoc",
        //         column: "BuocId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnBuoc_DuAnId",
        //         table: "DuAnBuoc",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnBuoc_Index",
        //         table: "DuAnBuoc",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnBuoc_QuyTrinhId",
        //         table: "DuAnBuoc",
        //         column: "QuyTrinhId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnBuocManHinh_BuocId",
        //         table: "DuAnBuocManHinh",
        //         column: "BuocId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnBuocManHinh_Index",
        //         table: "DuAnBuocManHinh",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnBuocManHinh_ManHinhId",
        //         table: "DuAnBuocManHinh",
        //         column: "ManHinhId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnBuocTrangThaiTienDo_BuocId",
        //         table: "DuAnBuocTrangThaiTienDo",
        //         column: "BuocId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnBuocTrangThaiTienDo_Index",
        //         table: "DuAnBuocTrangThaiTienDo",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnBuocTrangThaiTienDo_TrangThaiId",
        //         table: "DuAnBuocTrangThaiTienDo",
        //         column: "TrangThaiId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnNguonVon_DuAnId",
        //         table: "DuAnNguonVon",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_DuAnNguonVon_NguonVonId",
        //         table: "DuAnNguonVon",
        //         column: "NguonVonId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GoiThau_DanhMucHinhThucLuaChonNhaThauId",
        //         table: "GoiThau",
        //         column: "DanhMucHinhThucLuaChonNhaThauId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GoiThau_DuAnId",
        //         table: "GoiThau",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GoiThau_HinhThucLuaChonNhaThauId",
        //         table: "GoiThau",
        //         column: "HinhThucLuaChonNhaThauId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GoiThau_Index",
        //         table: "GoiThau",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GoiThau_KeHoachLuaChonNhaThauId",
        //         table: "GoiThau",
        //         column: "KeHoachLuaChonNhaThauId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GoiThau_LoaiGoiThauId",
        //         table: "GoiThau",
        //         column: "LoaiGoiThauId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GoiThau_LoaiHopDongId",
        //         table: "GoiThau",
        //         column: "LoaiHopDongId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GoiThau_NguonVonId",
        //         table: "GoiThau",
        //         column: "NguonVonId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_GoiThau_PhuongThucChonGoiThauId",
        //         table: "GoiThau",
        //         column: "PhuongThucChonGoiThauId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_HopDong_DonViThucHienId",
        //         table: "HopDong",
        //         column: "DonViThucHienId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_HopDong_DuAnId",
        //         table: "HopDong",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_HopDong_GoiThauId",
        //         table: "HopDong",
        //         column: "GoiThauId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_HopDong_Index",
        //         table: "HopDong",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_HopDong_LoaiHopDongId",
        //         table: "HopDong",
        //         column: "LoaiHopDongId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_HopDong_ThanhToanId",
        //         table: "HopDong",
        //         column: "ThanhToanId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_KeHoachLuaChonNhaThau_DuAnId",
        //         table: "KeHoachLuaChonNhaThau",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_KeHoachLuaChonNhaThau_Index",
        //         table: "KeHoachLuaChonNhaThau",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_KetQuaTrungThau_DonViTrungThauId",
        //         table: "KetQuaTrungThau",
        //         column: "DonViTrungThauId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_KetQuaTrungThau_DuAnId",
        //         table: "KetQuaTrungThau",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_KetQuaTrungThau_GoiThauId",
        //         table: "KetQuaTrungThau",
        //         column: "GoiThauId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_KetQuaTrungThau_Index",
        //         table: "KetQuaTrungThau",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_KhoKhanVuongMac_DuAnId",
        //         table: "KhoKhanVuongMac",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_KhoKhanVuongMac_Index",
        //         table: "KhoKhanVuongMac",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_KhoKhanVuongMac_TinhTrangId",
        //         table: "KhoKhanVuongMac",
        //         column: "TinhTrangId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_NghiemThu_DuAnId",
        //         table: "NghiemThu",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_NghiemThu_HopDongId",
        //         table: "NghiemThu",
        //         column: "HopDongId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_NghiemThu_Index",
        //         table: "NghiemThu",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_NghiemThu_ThanhToanId",
        //         table: "NghiemThu",
        //         column: "ThanhToanId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_NghiemThu_PhuLucHopDong_NghiemThuId",
        //         table: "NghiemThu_PhuLucHopDong",
        //         column: "NghiemThuId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_NghiemThu_PhuLucHopDong_PhuLucHopDongId",
        //         table: "NghiemThu_PhuLucHopDong",
        //         column: "PhuLucHopDongId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PheDuyetDuToan_ChucVuId",
        //         table: "PheDuyetDuToan",
        //         column: "ChucVuId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PheDuyetDuToan_DuAnId",
        //         table: "PheDuyetDuToan",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PheDuyetDuToan_Index",
        //         table: "PheDuyetDuToan",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PhuLucHopDong_DuAnId",
        //         table: "PhuLucHopDong",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PhuLucHopDong_HopDongId",
        //         table: "PhuLucHopDong",
        //         column: "HopDongId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PhuLucHopDong_Index",
        //         table: "PhuLucHopDong",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_PhuLucHopDong_ThanhToanId",
        //         table: "PhuLucHopDong",
        //         column: "ThanhToanId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuaTrinhXuLy_DuAnId",
        //         table: "QuaTrinhXuLy",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuaTrinhXuLy_Index",
        //         table: "QuaTrinhXuLy",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetDuAn_DuAnId",
        //         table: "QuyetDinhDuyetDuAn",
        //         column: "DuAnId",
        //         unique: true);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetDuAn_Index",
        //         table: "QuyetDinhDuyetDuAn",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetDuAnHangMuc_Index",
        //         table: "QuyetDinhDuyetDuAnHangMuc",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetDuAnHangMuc_QuyetDinhDuyetDuAnNguonVonId",
        //         table: "QuyetDinhDuyetDuAnHangMuc",
        //         column: "QuyetDinhDuyetDuAnNguonVonId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetDuAnNguonVon_Index",
        //         table: "QuyetDinhDuyetDuAnNguonVon",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetDuAnNguonVon_QuyetDinhDuyetDuAnId",
        //         table: "QuyetDinhDuyetDuAnNguonVon",
        //         column: "QuyetDinhDuyetDuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetKHLCNT_DuAnId",
        //         table: "QuyetDinhDuyetKHLCNT",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetKHLCNT_Index",
        //         table: "QuyetDinhDuyetKHLCNT",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetKHLCNT_KeHoachLuaChonNhaThauId",
        //         table: "QuyetDinhDuyetKHLCNT",
        //         column: "KeHoachLuaChonNhaThauId",
        //         unique: true,
        //         filter: "[KeHoachLuaChonNhaThauId] IS NOT NULL");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetQuyetToan_DuAnId",
        //         table: "QuyetDinhDuyetQuyetToan",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_QuyetDinhDuyetQuyetToan_Index",
        //         table: "QuyetDinhDuyetQuyetToan",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_TamUng_DuAnId",
        //         table: "TamUng",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_TamUng_HopDongId",
        //         table: "TamUng",
        //         column: "HopDongId",
        //         unique: true,
        //         filter: "[HopDongId] IS NOT NULL");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_TamUng_Index",
        //         table: "TamUng",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_TepDinhKem_Index",
        //         table: "TepDinhKem",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_ThanhToan_DuAnId",
        //         table: "ThanhToan",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_ThanhToan_Index",
        //         table: "ThanhToan",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_VanBanChuTruong_ChucVuId",
        //         table: "VanBanChuTruong",
        //         column: "ChucVuId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_VanBanChuTruong_DuAnId",
        //         table: "VanBanChuTruong",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_VanBanChuTruong_Index",
        //         table: "VanBanChuTruong",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_VanBanChuTruong_LoaiVanBanId",
        //         table: "VanBanChuTruong",
        //         column: "LoaiVanBanId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_VanBanPhapLy_ChucVuId",
        //         table: "VanBanPhapLy",
        //         column: "ChucVuId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_VanBanPhapLy_ChuDauTuId",
        //         table: "VanBanPhapLy",
        //         column: "ChuDauTuId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_VanBanPhapLy_DuAnId",
        //         table: "VanBanPhapLy",
        //         column: "DuAnId");
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_VanBanPhapLy_Index",
        //         table: "VanBanPhapLy",
        //         column: "Index")
        //         .Annotation("SqlServer:Clustered", false);
        //
        //     migrationBuilder.CreateIndex(
        //         name: "IX_VanBanPhapLy_LoaiVanBanId",
        //         table: "VanBanPhapLy",
        //         column: "LoaiVanBanId");
        // }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoCaoTienDo");

            migrationBuilder.DropTable(
                name: "DmBuocManHinh");

            migrationBuilder.DropTable(
                name: "DmBuocTrangThaiTienDo");

            migrationBuilder.DropTable(
                name: "DmLoaiQuyetDinh");

            migrationBuilder.DropTable(
                name: "DuAnBuocManHinh");

            migrationBuilder.DropTable(
                name: "DuAnBuocTrangThaiTienDo");

            migrationBuilder.DropTable(
                name: "DuAnNguonVon");

            migrationBuilder.DropTable(
                name: "KetQuaTrungThau");

            migrationBuilder.DropTable(
                name: "KhoKhanVuongMac");

            migrationBuilder.DropTable(
                name: "NghiemThu_PhuLucHopDong");

            migrationBuilder.DropTable(
                name: "PheDuyetDuToan");

            migrationBuilder.DropTable(
                name: "QuaTrinhXuLy");

            migrationBuilder.DropTable(
                name: "QuyetDinhDuyetDuAnHangMuc");

            migrationBuilder.DropTable(
                name: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropTable(
                name: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropTable(
                name: "TamUng");

            migrationBuilder.DropTable(
                name: "TepDinhKem");

            migrationBuilder.DropTable(
                name: "USER_MASTER");

            migrationBuilder.DropTable(
                name: "VanBanChuTruong");

            migrationBuilder.DropTable(
                name: "VanBanPhapLy");

            migrationBuilder.DropTable(
                name: "E_ManHinh");

            migrationBuilder.DropTable(
                name: "DuAnBuoc");

            migrationBuilder.DropTable(
                name: "DmTinhTrangKhoKhan");

            migrationBuilder.DropTable(
                name: "NghiemThu");

            migrationBuilder.DropTable(
                name: "PhuLucHopDong");

            migrationBuilder.DropTable(
                name: "QuyetDinhDuyetDuAnNguonVon");

            migrationBuilder.DropTable(
                name: "DmChucVu");

            migrationBuilder.DropTable(
                name: "DmLoaiVanBan");

            migrationBuilder.DropTable(
                name: "HopDong");

            migrationBuilder.DropTable(
                name: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropTable(
                name: "DmNhaThau");

            migrationBuilder.DropTable(
                name: "GoiThau");

            migrationBuilder.DropTable(
                name: "ThanhToan");

            migrationBuilder.DropTable(
                name: "DmHinhThucLuaChonNhaThau");

            migrationBuilder.DropTable(
                name: "DmLoaiGoiThau");

            migrationBuilder.DropTable(
                name: "DmLoaiHopDong");

            migrationBuilder.DropTable(
                name: "DmNguonVon");

            migrationBuilder.DropTable(
                name: "DmPhuongThucChonGoiThau");

            migrationBuilder.DropTable(
                name: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropTable(
                name: "DuAn");

            migrationBuilder.DropTable(
                name: "DmBuoc");

            migrationBuilder.DropTable(
                name: "DmChuDauTu");

            migrationBuilder.DropTable(
                name: "DmHinhThucDauTu");

            migrationBuilder.DropTable(
                name: "DmHinhThucQuanLy");

            migrationBuilder.DropTable(
                name: "DmLinhVuc");

            migrationBuilder.DropTable(
                name: "DmLoaiDuAnTheoNam");

            migrationBuilder.DropTable(
                name: "DmLoaiDuAn");

            migrationBuilder.DropTable(
                name: "DmNhomDuAn");

            migrationBuilder.DropTable(
                name: "DmTrangThaiDuAn");

            migrationBuilder.DropTable(
                name: "DmTrangThaiTienDo");

            migrationBuilder.DropTable(
                name: "DmQuyTrinh");
        }
    }
}
