using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_DanhMucGiaiDoan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiaiDoanId",
                table: "DuAnBuoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiaiDoanId",
                table: "DmBuoc",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DmGiaiDoan",
                columns: table => new
                {
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmGiaiDoan", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuoc_GiaiDoanId",
                table: "DuAnBuoc",
                column: "GiaiDoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DmBuoc_GiaiDoanId",
                table: "DmBuoc",
                column: "GiaiDoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DmGiaiDoan_Index",
                table: "DmGiaiDoan",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_DmBuoc_DmGiaiDoan_GiaiDoanId",
                table: "DmBuoc",
                column: "GiaiDoanId",
                principalTable: "DmGiaiDoan",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnBuoc_DmGiaiDoan_GiaiDoanId",
                table: "DuAnBuoc",
                column: "GiaiDoanId",
                principalTable: "DmGiaiDoan",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DmBuoc_DmGiaiDoan_GiaiDoanId",
                table: "DmBuoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DuAnBuoc_DmGiaiDoan_GiaiDoanId",
                table: "DuAnBuoc");

            migrationBuilder.DropTable(
                name: "DmGiaiDoan");

            migrationBuilder.DropIndex(
                name: "IX_DuAnBuoc_GiaiDoanId",
                table: "DuAnBuoc");

            migrationBuilder.DropIndex(
                name: "IX_DmBuoc_GiaiDoanId",
                table: "DmBuoc");

            migrationBuilder.DropColumn(
                name: "GiaiDoanId",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "GiaiDoanId",
                table: "DmBuoc");
        }
    }
}
