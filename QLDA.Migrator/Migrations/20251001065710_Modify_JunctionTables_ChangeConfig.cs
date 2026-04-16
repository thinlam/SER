using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_JunctionTables_ChangeConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAnNguonVon_DmNguonVon_NguonVonId",
                table: "DuAnNguonVon");

            migrationBuilder.DropTable(
                name: "ChiuTrachNhiemXuLy");

            migrationBuilder.DropTable(
                name: "HoSoMoiThau");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DuAnNguonVon",
                table: "DuAnNguonVon");

            migrationBuilder.DropIndex(
                name: "IX_DuAnNguonVon_DuAnId",
                table: "DuAnNguonVon");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DuAnNguonVon");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "DuAnNguonVon");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "DuAnNguonVon");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "DuAnNguonVon");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "DuAnNguonVon");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "DuAnNguonVon");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "DuAnNguonVon");

            migrationBuilder.AddColumn<long>(
                name: "DonViPhuTrachChinhId",
                table: "DuAn",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LanhDaoPhuTrachId",
                table: "DuAn",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DuAnNguonVon",
                table: "DuAnNguonVon",
                columns: new[] { "DuAnId", "NguonVonId" });

            migrationBuilder.CreateTable(
                name: "DuAnChiuTrachNhiemXuLy",
                columns: table => new
                {
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChiuTrachNhiemXuLyId = table.Column<long>(type: "bigint", nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAnChiuTrachNhiemXuLy", x => new { x.DuAnId, x.ChiuTrachNhiemXuLyId });
                    table.ForeignKey(
                        name: "FK_DuAnChiuTrachNhiemXuLy_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnNguonVon_DmNguonVon_NguonVonId",
                table: "DuAnNguonVon",
                column: "NguonVonId",
                principalTable: "DmNguonVon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAnNguonVon_DmNguonVon_NguonVonId",
                table: "DuAnNguonVon");

            migrationBuilder.DropTable(
                name: "DuAnChiuTrachNhiemXuLy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DuAnNguonVon",
                table: "DuAnNguonVon");

            migrationBuilder.DropColumn(
                name: "DonViPhuTrachChinhId",
                table: "DuAn");

            migrationBuilder.DropColumn(
                name: "LanhDaoPhuTrachId",
                table: "DuAn");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DuAnNguonVon",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "DuAnNguonVon",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "DuAnNguonVon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "DuAnNguonVon",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "DuAnNguonVon",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "DuAnNguonVon",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "DuAnNguonVon",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DuAnNguonVon",
                table: "DuAnNguonVon",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChiuTrachNhiemXuLy",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChiuTrachNhiemXuLyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiuTrachNhiemXuLy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChiuTrachNhiemXuLy_DuAn_DuAnId",
                        column: x => x.DuAnId,
                        principalTable: "DuAn",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoMoiThau",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    BuocId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoMoiThau", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuAnNguonVon_DuAnId",
                table: "DuAnNguonVon",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiuTrachNhiemXuLy_DuAnId",
                table: "ChiuTrachNhiemXuLy",
                column: "DuAnId");

            migrationBuilder.CreateIndex(
                name: "IX_ChiuTrachNhiemXuLy_Index",
                table: "ChiuTrachNhiemXuLy",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_HoSoMoiThau_Index",
                table: "HoSoMoiThau",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnNguonVon_DmNguonVon_NguonVonId",
                table: "DuAnNguonVon",
                column: "NguonVonId",
                principalTable: "DmNguonVon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
