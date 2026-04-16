using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_DangTaiKeHoachLcntLenMang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoSoMoiThau_KeHoachLuaChonNhaThau_KeHoachLuaChonNhaThauId",
                table: "HoSoMoiThau");

            migrationBuilder.DropIndex(
                name: "IX_HoSoMoiThau_KeHoachLuaChonNhaThauId",
                table: "HoSoMoiThau");

            migrationBuilder.DropColumn(
                name: "KeHoachLuaChonNhaThauId",
                table: "HoSoMoiThau");

            migrationBuilder.DropColumn(
                name: "NgayEHSMT",
                table: "HoSoMoiThau");

            migrationBuilder.DropColumn(
                name: "TrangThaiId",
                table: "HoSoMoiThau");

            migrationBuilder.CreateTable(
                name: "DangTaiKeHoachLcntLenMang",
                columns: table => new
                {
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuocId = table.Column<int>(type: "int", nullable: true),
                    KeHoachLuaChonNhaThauId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NgayEHSMT = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DangTaiKeHoachLcntLenMang", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DangTaiKeHoachLcntLenMang_KeHoachLuaChonNhaThau_KeHoachLuaChonNhaThauId",
                        column: x => x.KeHoachLuaChonNhaThauId,
                        principalTable: "KeHoachLuaChonNhaThau",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DangTaiKeHoachLcntLenMang_Index",
                table: "DangTaiKeHoachLcntLenMang",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DangTaiKeHoachLcntLenMang_KeHoachLuaChonNhaThauId",
                table: "DangTaiKeHoachLcntLenMang",
                column: "KeHoachLuaChonNhaThauId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DangTaiKeHoachLcntLenMang");

            migrationBuilder.AddColumn<Guid>(
                name: "KeHoachLuaChonNhaThauId",
                table: "HoSoMoiThau",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayEHSMT",
                table: "HoSoMoiThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiId",
                table: "HoSoMoiThau",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HoSoMoiThau_KeHoachLuaChonNhaThauId",
                table: "HoSoMoiThau",
                column: "KeHoachLuaChonNhaThauId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoSoMoiThau_KeHoachLuaChonNhaThau_KeHoachLuaChonNhaThauId",
                table: "HoSoMoiThau",
                column: "KeHoachLuaChonNhaThauId",
                principalTable: "KeHoachLuaChonNhaThau",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
