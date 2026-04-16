using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Update_KeHoachLuaChonNhaThau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachLuaChonNhaThau_DuAn_DuAnId",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropIndex(
                name: "IX_KeHoachLuaChonNhaThau_DuAnId",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropIndex(
                name: "IX_KeHoachLuaChonNhaThau_Index",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "BuocId",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "DuAnId",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "NgayKy",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "NgayQuyetDinh",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "NguoiKy",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "SoQuyetDinh",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "TrichYeu",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "KeHoachLuaChonNhaThau",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWSEQUENTIALID()");

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId1",
                table: "KeHoachLuaChonNhaThau",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachLuaChonNhaThau_DuAnId1",
                table: "KeHoachLuaChonNhaThau",
                column: "DuAnId1");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachLuaChonNhaThau_DuAn_DuAnId1",
                table: "KeHoachLuaChonNhaThau",
                column: "DuAnId1",
                principalTable: "DuAn",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachLuaChonNhaThau_VanBanQuyetDinh_Id",
                table: "KeHoachLuaChonNhaThau",
                column: "Id",
                principalTable: "VanBanQuyetDinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachLuaChonNhaThau_DuAn_DuAnId1",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropForeignKey(
                name: "FK_KeHoachLuaChonNhaThau_VanBanQuyetDinh_Id",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropIndex(
                name: "IX_KeHoachLuaChonNhaThau_DuAnId1",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.DropColumn(
                name: "DuAnId1",
                table: "KeHoachLuaChonNhaThau");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "KeHoachLuaChonNhaThau",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "BuocId",
                table: "KeHoachLuaChonNhaThau",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "KeHoachLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "KeHoachLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AddColumn<Guid>(
                name: "DuAnId",
                table: "KeHoachLuaChonNhaThau",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "KeHoachLuaChonNhaThau",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "KeHoachLuaChonNhaThau",
                type: "bit",
                nullable: false,
                defaultValue: false)
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayKy",
                table: "KeHoachLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayQuyetDinh",
                table: "KeHoachLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NguoiKy",
                table: "KeHoachLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SoQuyetDinh",
                table: "KeHoachLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrichYeu",
                table: "KeHoachLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "KeHoachLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "KeHoachLuaChonNhaThau",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "KeHoachLuaChonNhaThau",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachLuaChonNhaThau_DuAnId",
                table: "KeHoachLuaChonNhaThau",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_KeHoachLuaChonNhaThau_Index",
                table: "KeHoachLuaChonNhaThau",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_KeHoachLuaChonNhaThau_DuAn_DuAnId",
                table: "KeHoachLuaChonNhaThau",
                column: "DuAnId",
                principalTable: "DuAn",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
