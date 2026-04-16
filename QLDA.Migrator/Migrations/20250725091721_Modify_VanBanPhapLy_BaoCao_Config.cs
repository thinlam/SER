using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_VanBanPhapLy_BaoCao_Config : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "VanBanQuyetDinh",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "VanBanQuyetDinh",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "VanBanQuyetDinh",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "VanBanQuyetDinh",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "VanBanPhapLy",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "VanBanChuTruong",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ThanhVienBanQLDA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ThanhVienBanQLDA",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "ThanhVienBanQLDA",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ThanhVienBanQLDA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "ThanhToan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ThanhToan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ThanhToan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "ThanhToan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ThanhToan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "TepDinhKem",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "TepDinhKem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "TepDinhKem",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TepDinhKem",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "TepDinhKem",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TepDinhKem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "TepDinhKem",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "TamUng",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "TamUng",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "TamUng",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TamUng",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "TamUng",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TamUng",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "TamUng",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhLapHoiDongThamDinh",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhLapBenMoiThau",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhLapBanQLDA",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhDuyetQuyetToan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhDuyetKHLCNT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhDuyetDuAn",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "PhuLucHopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PhuLucHopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "PhuLucHopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PhuLucHopDong",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "PhuLucHopDong",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PhuLucHopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "PhuLucHopDong",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PheDuyetDuToan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "NghiemThuThanhToan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "NghiemThuThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "NghiemThuThanhToan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "NghiemThuThanhToan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "NghiemThuThanhToan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "NghiemThuThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "NghiemThuThanhToan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "NghiemThu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "NghiemThu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "NghiemThu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "NghiemThu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "NghiemThu",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "NghiemThu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "NghiemThu",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "KetQuaTrungThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "KetQuaTrungThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "KetQuaTrungThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "KetQuaTrungThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "KetQuaTrungThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "KetQuaTrungThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "KetQuaTrungThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "KeHoachLuaChonNhaThau",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "HopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "HopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "HopDong",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "HopDong",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "HopDong",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "GoiThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "GoiThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "GoiThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "GoiThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "GoiThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GoiThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "GoiThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DuAnBuocManHinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DuAnBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DuAnBuocManHinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DuAnBuocManHinh",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DuAnBuocManHinh",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DuAnBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DuAnBuocManHinh",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DuAnBuoc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DuAnBuoc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DuAnBuoc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DuAnBuoc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DuAnBuoc",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DuAnBuoc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DuAnBuoc",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DuAn",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DuAn",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DuAn",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmTrangThaiTienDo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmTrangThaiTienDo",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmTrangThaiTienDo",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmTrangThaiTienDo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmTrangThaiDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmTrangThaiDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmTrangThaiDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmTrangThaiDuAn",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmTrangThaiDuAn",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmTrangThaiDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmTrangThaiDuAn",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmTinhTrangKhoKhan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmTinhTrangKhoKhan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmTinhTrangKhoKhan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmTinhTrangKhoKhan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmTinhTrangKhoKhan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmTinhTrangKhoKhan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmTinhTrangKhoKhan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmQuyTrinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmQuyTrinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmQuyTrinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmQuyTrinh",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmQuyTrinh",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmQuyTrinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmQuyTrinh",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmNhomDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmNhomDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmNhomDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmNhomDuAn",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmNhomDuAn",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmNhomDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmNhomDuAn",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmNhaThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmNhaThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmNhaThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmNguonVon",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmNguonVon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmNguonVon",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmNguonVon",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmNguonVon",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmNguonVon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmNguonVon",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiVanBan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLoaiVanBan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLoaiVanBan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLoaiVanBan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLoaiVanBan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLoaiVanBan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLoaiVanBan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiHopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLoaiHopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLoaiHopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLoaiHopDong",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLoaiHopDong",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLoaiHopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLoaiHopDong",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiGoiThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLoaiGoiThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLoaiGoiThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLoaiGoiThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLoaiGoiThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLoaiGoiThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLoaiGoiThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiDuAnTheoNam",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLoaiDuAnTheoNam",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLoaiDuAnTheoNam",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLoaiDuAnTheoNam",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLoaiDuAnTheoNam",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLoaiDuAnTheoNam",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLoaiDuAnTheoNam",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLoaiDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLoaiDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLoaiDuAn",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLoaiDuAn",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLoaiDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLoaiDuAn",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLinhVuc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLinhVuc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLinhVuc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLinhVuc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLinhVuc",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLinhVuc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLinhVuc",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmHinhThucQuanLy",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmHinhThucQuanLy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmHinhThucQuanLy",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmHinhThucQuanLy",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmHinhThucQuanLy",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmHinhThucQuanLy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmHinhThucQuanLy",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmHinhThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmHinhThucLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmHinhThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmHinhThucLuaChonNhaThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmHinhThucLuaChonNhaThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmHinhThucLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmHinhThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmHinhThucDauTu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmHinhThucDauTu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmHinhThucDauTu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmHinhThucDauTu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmHinhThucDauTu",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmHinhThucDauTu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmHinhThucDauTu",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmGiaiDoan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmGiaiDoan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmGiaiDoan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmGiaiDoan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmGiaiDoan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmGiaiDoan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmGiaiDoan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmChuDauTu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmChuDauTu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmChuDauTu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmChuDauTu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmChuDauTu",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmChuDauTu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmChuDauTu",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmChucVu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmChucVu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmChucVu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmChucVu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmChucVu",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmChucVu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmChucVu",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmBuocTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmBuocTrangThaiTienDo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmBuocTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmBuocTrangThaiTienDo",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmBuocTrangThaiTienDo",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmBuocTrangThaiTienDo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmBuocTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmBuocManHinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmBuocManHinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmBuocManHinh",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmBuocManHinh",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmBuocManHinh",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmBuoc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmBuoc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmBuoc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmBuoc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmBuoc",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmBuoc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmBuoc",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DangTaiKeHoachLcntLenMang",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DangTaiKeHoachLcntLenMang",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DangTaiKeHoachLcntLenMang",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DangTaiKeHoachLcntLenMang",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DangTaiKeHoachLcntLenMang",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DangTaiKeHoachLcntLenMang",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DangTaiKeHoachLcntLenMang",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "ChiuTrachNhiemXuLy",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ChiuTrachNhiemXuLy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ChiuTrachNhiemXuLy",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ChiuTrachNhiemXuLy",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "ChiuTrachNhiemXuLy",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ChiuTrachNhiemXuLy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ChiuTrachNhiemXuLy",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCaoTienDo",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCaoKhoKhanVuongMac",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCaoBaoHanhSanPham",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCaoBanGiaoSanPham",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "BaoCao",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "BaoCao",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCao",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "BaoCao",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VanBanQuyetDinh_Index",
                table: "VanBanQuyetDinh",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_BaoCao_Index",
                table: "BaoCao",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VanBanQuyetDinh_Index",
                table: "VanBanQuyetDinh");

            migrationBuilder.DropIndex(
                name: "IX_BaoCao_Index",
                table: "BaoCao");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "VanBanQuyetDinh");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "BaoCao");

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "VanBanQuyetDinh",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "VanBanQuyetDinh",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "VanBanQuyetDinh",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "VanBanPhapLy",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "VanBanChuTruong",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ThanhVienBanQLDA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ThanhVienBanQLDA",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "ThanhVienBanQLDA",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ThanhVienBanQLDA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "ThanhToan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ThanhToan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ThanhToan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "ThanhToan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ThanhToan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "TepDinhKem",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "TepDinhKem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "TepDinhKem",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TepDinhKem",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "TepDinhKem",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TepDinhKem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "TepDinhKem",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "TamUng",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "TamUng",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "TamUng",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "TamUng",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "TamUng",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "TamUng",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "TamUng",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhLapHoiDongThamDinh",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhLapBenMoiThau",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhLapBanQLDA",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhDuyetQuyetToan",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhDuyetKHLCNT",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "QuyetDinhDuyetDuAnNguonVon",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "QuyetDinhDuyetDuAnHangMuc",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhDuyetDuAn",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "PhuLucHopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "PhuLucHopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "PhuLucHopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "PhuLucHopDong",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "PhuLucHopDong",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "PhuLucHopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "PhuLucHopDong",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "PheDuyetDuToan",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "NghiemThuThanhToan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "NghiemThuThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "NghiemThuThanhToan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "NghiemThuThanhToan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "NghiemThuThanhToan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "NghiemThuThanhToan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "NghiemThuThanhToan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "NghiemThu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "NghiemThu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "NghiemThu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "NghiemThu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "NghiemThu",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "NghiemThu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "NghiemThu",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "KetQuaTrungThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "KetQuaTrungThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "KetQuaTrungThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "KetQuaTrungThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "KetQuaTrungThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "KetQuaTrungThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "KetQuaTrungThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "KeHoachLuaChonNhaThau",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "HopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "HopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "HopDong",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "HopDong",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "HopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "HopDong",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "GoiThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "GoiThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "GoiThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "GoiThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "GoiThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GoiThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "GoiThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DuAnBuocManHinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DuAnBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DuAnBuocManHinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DuAnBuocManHinh",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DuAnBuocManHinh",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DuAnBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DuAnBuocManHinh",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DuAnBuoc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DuAnBuoc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DuAnBuoc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DuAnBuoc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DuAnBuoc",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DuAnBuoc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DuAnBuoc",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DuAn",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DuAn",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DuAn",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmTrangThaiTienDo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmTrangThaiTienDo",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmTrangThaiTienDo",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmTrangThaiTienDo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmTrangThaiDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmTrangThaiDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmTrangThaiDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmTrangThaiDuAn",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmTrangThaiDuAn",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmTrangThaiDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmTrangThaiDuAn",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmTinhTrangKhoKhan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmTinhTrangKhoKhan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmTinhTrangKhoKhan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmTinhTrangKhoKhan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmTinhTrangKhoKhan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmTinhTrangKhoKhan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmTinhTrangKhoKhan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmQuyTrinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmQuyTrinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmQuyTrinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmQuyTrinh",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmQuyTrinh",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmQuyTrinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmQuyTrinh",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmPhuongThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmNhomDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmNhomDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmNhomDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmNhomDuAn",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmNhomDuAn",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmNhomDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmNhomDuAn",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmNhaThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmNhaThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmNhaThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmNguonVon",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmNguonVon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmNguonVon",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmNguonVon",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmNguonVon",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmNguonVon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmNguonVon",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiVanBan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLoaiVanBan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLoaiVanBan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLoaiVanBan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLoaiVanBan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLoaiVanBan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLoaiVanBan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiHopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLoaiHopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLoaiHopDong",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLoaiHopDong",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLoaiHopDong",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLoaiHopDong",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLoaiHopDong",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiGoiThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLoaiGoiThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLoaiGoiThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLoaiGoiThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLoaiGoiThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLoaiGoiThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLoaiGoiThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiDuAnTheoNam",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLoaiDuAnTheoNam",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLoaiDuAnTheoNam",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLoaiDuAnTheoNam",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLoaiDuAnTheoNam",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLoaiDuAnTheoNam",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLoaiDuAnTheoNam",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLoaiDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLoaiDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLoaiDuAn",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLoaiDuAn",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLoaiDuAn",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLoaiDuAn",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLoaiDuAn",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmLinhVuc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmLinhVuc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmLinhVuc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmLinhVuc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmLinhVuc",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmLinhVuc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmLinhVuc",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmHinhThucQuanLy",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmHinhThucQuanLy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmHinhThucQuanLy",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmHinhThucQuanLy",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmHinhThucQuanLy",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmHinhThucQuanLy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmHinhThucQuanLy",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmHinhThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmHinhThucLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmHinhThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmHinhThucLuaChonNhaThau",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmHinhThucLuaChonNhaThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmHinhThucLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmHinhThucLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmHinhThucDauTu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmHinhThucDauTu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmHinhThucDauTu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmHinhThucDauTu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmHinhThucDauTu",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmHinhThucDauTu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmHinhThucDauTu",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmGiaiDoan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmGiaiDoan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmGiaiDoan",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmGiaiDoan",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmGiaiDoan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmGiaiDoan",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmGiaiDoan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmChuDauTu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmChuDauTu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmChuDauTu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmChuDauTu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmChuDauTu",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmChuDauTu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmChuDauTu",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmChucVu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmChucVu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmChucVu",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmChucVu",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmChucVu",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmChucVu",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmChucVu",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmBuocTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmBuocTrangThaiTienDo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmBuocTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmBuocTrangThaiTienDo",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmBuocTrangThaiTienDo",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmBuocTrangThaiTienDo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmBuocTrangThaiTienDo",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmBuocManHinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmBuocManHinh",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmBuocManHinh",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmBuocManHinh",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmBuocManHinh",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DmBuoc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DmBuoc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmBuoc",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DmBuoc",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DmBuoc",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DmBuoc",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmBuoc",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "DangTaiKeHoachLcntLenMang",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "DangTaiKeHoachLcntLenMang",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DangTaiKeHoachLcntLenMang",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "DangTaiKeHoachLcntLenMang",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "DangTaiKeHoachLcntLenMang",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "DangTaiKeHoachLcntLenMang",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DangTaiKeHoachLcntLenMang",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "ChiuTrachNhiemXuLy",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ChiuTrachNhiemXuLy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ChiuTrachNhiemXuLy",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ChiuTrachNhiemXuLy",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "ChiuTrachNhiemXuLy",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ChiuTrachNhiemXuLy",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ChiuTrachNhiemXuLy",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

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
                table: "BaoCaoKhoKhanVuongMac",
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

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "BaoCao",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "BaoCao",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "BaoCao",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");
        }
    }
}
