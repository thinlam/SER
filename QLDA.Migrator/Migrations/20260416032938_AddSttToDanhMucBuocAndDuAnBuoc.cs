using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class AddSttToDanhMucBuocAndDuAnBuoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Stt",
                table: "DuAnBuocManHinh",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "DuAnBuoc",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Stt",
                table: "DmBuocManHinh",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stt",
                table: "DuAnBuocManHinh");

            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "Stt",
                table: "DmBuocManHinh");
        }
    }
}
