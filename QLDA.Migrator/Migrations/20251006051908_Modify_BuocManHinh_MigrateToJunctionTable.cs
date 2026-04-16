using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_BuocManHinh_MigrateToJunctionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DmBuocManHinh_E_ManHinh_ManHinhId",
                table: "DmBuocManHinh");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DmBuocManHinh",
                table: "DmBuocManHinh");

            migrationBuilder.DropIndex(
                name: "IX_DmBuocManHinh_BuocId",
                table: "DmBuocManHinh");

            migrationBuilder.DropIndex(
                name: "IX_DmBuocManHinh_Index",
                table: "DmBuocManHinh");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DmBuocManHinh");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DmBuocManHinh");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DmBuocManHinh");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "DmBuocManHinh");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DmBuocManHinh");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DmBuocManHinh");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DmBuocManHinh");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DmBuocManHinh",
                table: "DmBuocManHinh",
                columns: new[] { "BuocId", "ManHinhId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DmBuocManHinh_E_ManHinh_ManHinhId",
                table: "DmBuocManHinh",
                column: "ManHinhId",
                principalTable: "E_ManHinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DmBuocManHinh_E_ManHinh_ManHinhId",
                table: "DmBuocManHinh");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DmBuocManHinh",
                table: "DmBuocManHinh");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DmBuocManHinh",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DmBuocManHinh",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DmBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "DmBuocManHinh",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DmBuocManHinh",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DmBuocManHinh",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DmBuocManHinh",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DmBuocManHinh",
                table: "DmBuocManHinh",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DmBuocManHinh_BuocId",
                table: "DmBuocManHinh",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_DmBuocManHinh_Index",
                table: "DmBuocManHinh",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_DmBuocManHinh_E_ManHinh_ManHinhId",
                table: "DmBuocManHinh",
                column: "ManHinhId",
                principalTable: "E_ManHinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
