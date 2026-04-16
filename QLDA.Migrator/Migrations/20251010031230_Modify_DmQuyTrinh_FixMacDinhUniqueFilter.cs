using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_DmQuyTrinh_FixMacDinhUniqueFilter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DmQuyTrinh_MacDinh",
                table: "DmQuyTrinh",
                column: "MacDinh",
                unique: true,
                filter: "[MacDinh] = 1 AND [IsDeleted] = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DmQuyTrinh_MacDinh",
                table: "DmQuyTrinh");
        }
    }
}
