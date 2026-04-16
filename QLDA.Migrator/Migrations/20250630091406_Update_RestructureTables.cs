using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Update_RestructureTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinhDuyetDuAn_DuAn_DuAnId",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinhDuyetKHLCNT_DuAn_DuAnId",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinhDuyetQuyetToan_DuAn_DuAnId",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropForeignKey(
                name: "FK_VanBanChuTruong_DuAn_DuAnId",
                table: "VanBanChuTruong");

            migrationBuilder.DropForeignKey(
                name: "FK_VanBanPhapLy_DuAn_DuAnId",
                table: "VanBanPhapLy");

            migrationBuilder.DropIndex(
                name: "IX_VanBanPhapLy_DuAnId",
                table: "VanBanPhapLy");

            migrationBuilder.DropIndex(
                name: "IX_VanBanPhapLy_Index",
                table: "VanBanPhapLy");

            migrationBuilder.DropIndex(
                name: "IX_VanBanChuTruong_DuAnId",
                table: "VanBanChuTruong");

            migrationBuilder.DropIndex(
                name: "IX_VanBanChuTruong_Index",
                table: "VanBanChuTruong");

            migrationBuilder.DropIndex(
                name: "IX_QuyetDinhDuyetQuyetToan_DuAnId",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropIndex(
                name: "IX_QuyetDinhDuyetQuyetToan_Index",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropIndex(
                name: "IX_QuyetDinhDuyetKHLCNT_DuAnId",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropIndex(
                name: "IX_QuyetDinhDuyetKHLCNT_Index",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropIndex(
                name: "IX_QuyetDinhDuyetDuAn_DuAnId",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropIndex(
                name: "IX_QuyetDinhDuyetDuAn_Index",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "BuocId",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "DuAnId",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "NgayKy",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "NgayVanBan",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "NguoiKy",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "SoVanBan",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "TrichYeu",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "VanBanPhapLy");

            migrationBuilder.DropColumn(
                name: "BuocId",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "DuAnId",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "NgayKy",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "NgayVanBan",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "NguoiKy",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "SoVanBan",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "TrichYeu",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "VanBanChuTruong");

            migrationBuilder.DropColumn(
                name: "BuocId",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "DuAnId",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "NgayKy",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "NgayQuyetDinh",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "NguoiKy",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "SoQuyetDinh",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "TrichYeu",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropColumn(
                name: "BuocId",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "DuAnId",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "NgayKy",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "NgayQuyetDinh",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "NguoiKy",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "SoQuyetDinh",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "TrichYeu",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropColumn(
                name: "BuocId",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "DuAnId",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "NgayQuyetDinh",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "SoQuyetDinh",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "TrichYeu",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetDuAn");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhDuyetDuAn",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinhDuyetDuAn_VanBanQuyetDinh_Id",
                table: "QuyetDinhDuyetDuAn",
                column: "Id",
                principalTable: "VanBanQuyetDinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinhDuyetKHLCNT_VanBanQuyetDinh_Id",
                table: "QuyetDinhDuyetKHLCNT",
                column: "Id",
                principalTable: "VanBanQuyetDinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinhDuyetQuyetToan_VanBanQuyetDinh_Id",
                table: "QuyetDinhDuyetQuyetToan",
                column: "Id",
                principalTable: "VanBanQuyetDinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VanBanChuTruong_VanBanQuyetDinh_Id",
                table: "VanBanChuTruong",
                column: "Id",
                principalTable: "VanBanQuyetDinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VanBanPhapLy_VanBanQuyetDinh_Id",
                table: "VanBanPhapLy",
                column: "Id",
                principalTable: "VanBanQuyetDinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinhDuyetDuAn_VanBanQuyetDinh_Id",
                table: "QuyetDinhDuyetDuAn");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinhDuyetKHLCNT_VanBanQuyetDinh_Id",
                table: "QuyetDinhDuyetKHLCNT");

            migrationBuilder.DropForeignKey(
                name: "FK_QuyetDinhDuyetQuyetToan_VanBanQuyetDinh_Id",
                table: "QuyetDinhDuyetQuyetToan");

            migrationBuilder.DropForeignKey(
                name: "FK_VanBanChuTruong_VanBanQuyetDinh_Id",
                table: "VanBanChuTruong");

            migrationBuilder.DropForeignKey(
                name: "FK_VanBanPhapLy_VanBanQuyetDinh_Id",
                table: "VanBanPhapLy");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "VanBanPhapLy",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BuocId",
                table: "VanBanPhapLy",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "VanBanPhapLy",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VanBanPhapLy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId",
                table: "VanBanPhapLy",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "VanBanPhapLy",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VanBanPhapLy",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayKy",
                table: "VanBanPhapLy",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayVanBan",
                table: "VanBanPhapLy",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiKy",
                table: "VanBanPhapLy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoVanBan",
                table: "VanBanPhapLy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrichYeu",
                table: "VanBanPhapLy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "VanBanPhapLy",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "VanBanPhapLy",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "VanBanPhapLy",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "VanBanChuTruong",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BuocId",
                table: "VanBanChuTruong",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "VanBanChuTruong",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "VanBanChuTruong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId",
                table: "VanBanChuTruong",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "VanBanChuTruong",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "VanBanChuTruong",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayKy",
                table: "VanBanChuTruong",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayVanBan",
                table: "VanBanChuTruong",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiKy",
                table: "VanBanChuTruong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoVanBan",
                table: "VanBanChuTruong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrichYeu",
                table: "VanBanChuTruong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "VanBanChuTruong",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "VanBanChuTruong",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "VanBanChuTruong",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhDuyetQuyetToan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BuocId",
                table: "QuyetDinhDuyetQuyetToan",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "QuyetDinhDuyetQuyetToan",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "QuyetDinhDuyetQuyetToan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId",
                table: "QuyetDinhDuyetQuyetToan",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "QuyetDinhDuyetQuyetToan",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "QuyetDinhDuyetQuyetToan",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayKy",
                table: "QuyetDinhDuyetQuyetToan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayQuyetDinh",
                table: "QuyetDinhDuyetQuyetToan",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiKy",
                table: "QuyetDinhDuyetQuyetToan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoQuyetDinh",
                table: "QuyetDinhDuyetQuyetToan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrichYeu",
                table: "QuyetDinhDuyetQuyetToan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "QuyetDinhDuyetQuyetToan",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "QuyetDinhDuyetQuyetToan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetQuyetToan",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhDuyetKHLCNT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BuocId",
                table: "QuyetDinhDuyetKHLCNT",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "QuyetDinhDuyetKHLCNT",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "QuyetDinhDuyetKHLCNT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId",
                table: "QuyetDinhDuyetKHLCNT",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "QuyetDinhDuyetKHLCNT",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "QuyetDinhDuyetKHLCNT",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayKy",
                table: "QuyetDinhDuyetKHLCNT",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayQuyetDinh",
                table: "QuyetDinhDuyetKHLCNT",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiKy",
                table: "QuyetDinhDuyetKHLCNT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoQuyetDinh",
                table: "QuyetDinhDuyetKHLCNT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrichYeu",
                table: "QuyetDinhDuyetKHLCNT",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "QuyetDinhDuyetKHLCNT",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "QuyetDinhDuyetKHLCNT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetKHLCNT",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "QuyetDinhDuyetDuAn",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BuocId",
                table: "QuyetDinhDuyetDuAn",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "QuyetDinhDuyetDuAn",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "QuyetDinhDuyetDuAn",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId",
                table: "QuyetDinhDuyetDuAn",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "QuyetDinhDuyetDuAn",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "QuyetDinhDuyetDuAn",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayQuyetDinh",
                table: "QuyetDinhDuyetDuAn",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoQuyetDinh",
                table: "QuyetDinhDuyetDuAn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrichYeu",
                table: "QuyetDinhDuyetDuAn",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "QuyetDinhDuyetDuAn",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "QuyetDinhDuyetDuAn",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "QuyetDinhDuyetDuAn",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.CreateIndex(
                name: "IX_VanBanPhapLy_DuAnId",
                table: "VanBanPhapLy",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_VanBanPhapLy_Index",
                table: "VanBanPhapLy",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_VanBanChuTruong_DuAnId",
                table: "VanBanChuTruong",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_VanBanChuTruong_Index",
                table: "VanBanChuTruong",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhDuyetQuyetToan_DuAnId",
                table: "QuyetDinhDuyetQuyetToan",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhDuyetQuyetToan_Index",
                table: "QuyetDinhDuyetQuyetToan",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhDuyetKHLCNT_DuAnId",
                table: "QuyetDinhDuyetKHLCNT",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhDuyetKHLCNT_Index",
                table: "QuyetDinhDuyetKHLCNT",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhDuyetDuAn_DuAnId",
                table: "QuyetDinhDuyetDuAn",
                column: "DuAnId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuyetDinhDuyetDuAn_Index",
                table: "QuyetDinhDuyetDuAn",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinhDuyetDuAn_DuAn_DuAnId",
                table: "QuyetDinhDuyetDuAn",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinhDuyetKHLCNT_DuAn_DuAnId",
                table: "QuyetDinhDuyetKHLCNT",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuyetDinhDuyetQuyetToan_DuAn_DuAnId",
                table: "QuyetDinhDuyetQuyetToan",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VanBanChuTruong_DuAn_DuAnId",
                table: "VanBanChuTruong",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VanBanPhapLy_DuAn_DuAnId",
                table: "VanBanPhapLy",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
