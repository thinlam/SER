using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_DuAnBuocManHinh_MigrateToJunctionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DuAnBuocManHinh",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropIndex(
                name: "IX_DuAnBuocManHinh_BuocId",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropIndex(
                name: "IX_DuAnBuocManHinh_Index",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropIndex(
                name: "IX_DuAnBuocManHinh_Ma",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "Ma",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "MoTa",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "Ten",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DuAnBuocManHinh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DuAnBuocManHinh",
                table: "DuAnBuocManHinh",
                columns: new[] { "BuocId", "ManHinhId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DuAnBuocManHinh",
                table: "DuAnBuocManHinh");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DuAnBuocManHinh",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DuAnBuocManHinh",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DuAnBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "DuAnBuocManHinh",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DuAnBuocManHinh",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Ma",
                table: "DuAnBuocManHinh",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MoTa",
                table: "DuAnBuocManHinh",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ten",
                table: "DuAnBuocManHinh",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DuAnBuocManHinh",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DuAnBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DuAnBuocManHinh",
                table: "DuAnBuocManHinh",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocManHinh_BuocId",
                table: "DuAnBuocManHinh",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocManHinh_Index",
                table: "DuAnBuocManHinh",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocManHinh_Ma",
                table: "DuAnBuocManHinh",
                column: "Ma",
                unique: true,
                filter: "[Ma] IS NOT NULL AND [Ma] <> ''");
        }
    }
}
