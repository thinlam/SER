using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Update_GoiThau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAn_DmBuoc_BuocHienTaiId",
                table: "DuAn");

            migrationBuilder.DropForeignKey(
                name: "FK_DuAn_DmTrangThaiTienDo_TrangThaiTienDoId",
                table: "DuAn");

            migrationBuilder.DropForeignKey(
                name: "FK_GoiThau_DmHinhThucLuaChonNhaThau_DanhMucHinhThucLuaChonNhaThauId",
                table: "GoiThau");

            migrationBuilder.DropForeignKey(
                name: "FK_GoiThau_DmPhuongThucChonGoiThau_PhuongThucChonGoiThauId",
                table: "GoiThau");

            migrationBuilder.DropTable(
                name: "DmPhuongThucChonGoiThau");

            migrationBuilder.DropIndex(
                name: "IX_GoiThau_DanhMucHinhThucLuaChonNhaThauId",
                table: "GoiThau");

            migrationBuilder.DropIndex(
                name: "IX_DuAn_BuocHienTaiId",
                table: "DuAn");

            migrationBuilder.DropIndex(
                name: "IX_DuAn_TrangThaiTienDoId",
                table: "DuAn");

            migrationBuilder.DropColumn(
                name: "DanhMucHinhThucLuaChonNhaThauId",
                table: "GoiThau");

            migrationBuilder.DropColumn(
                name: "TrangThaiTienDoId",
                table: "DuAn");

            migrationBuilder.RenameColumn(
                name: "PhuongThucChonGoiThauId",
                table: "GoiThau",
                newName: "PhuongThucLuaChonNhaThauId");

            migrationBuilder.RenameIndex(
                name: "IX_GoiThau_PhuongThucChonGoiThauId",
                table: "GoiThau",
                newName: "IX_GoiThau_PhuongThucLuaChonNhaThauId");

            migrationBuilder.CreateTable(
                name: "DmPhuongThucLuaChonNhaThau",
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
                    table.PrimaryKey("PK_DmPhuongThucLuaChonNhaThau", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_BuocHienTaiId",
                table: "DuAn",
                column: "BuocHienTaiId",
                unique: true,
                filter: "[BuocHienTaiId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_TrangThaiHienTaiId",
                table: "DuAn",
                column: "TrangThaiHienTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_DmPhuongThucLuaChonNhaThau_Index",
                table: "DmPhuongThucLuaChonNhaThau",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_DuAn_DmTrangThaiTienDo_TrangThaiHienTaiId",
                table: "DuAn",
                column: "TrangThaiHienTaiId",
                principalTable: "DmTrangThaiTienDo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DuAn_DuAnBuoc_BuocHienTaiId",
                table: "DuAn",
                column: "BuocHienTaiId",
                principalTable: "DuAnBuoc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoiThau_DmPhuongThucLuaChonNhaThau_PhuongThucLuaChonNhaThauId",
                table: "GoiThau",
                column: "PhuongThucLuaChonNhaThauId",
                principalTable: "DmPhuongThucLuaChonNhaThau",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAn_DmTrangThaiTienDo_TrangThaiHienTaiId",
                table: "DuAn");

            migrationBuilder.DropForeignKey(
                name: "FK_DuAn_DuAnBuoc_BuocHienTaiId",
                table: "DuAn");

            migrationBuilder.DropForeignKey(
                name: "FK_GoiThau_DmPhuongThucLuaChonNhaThau_PhuongThucLuaChonNhaThauId",
                table: "GoiThau");

            migrationBuilder.DropTable(
                name: "DmPhuongThucLuaChonNhaThau");

            migrationBuilder.DropIndex(
                name: "IX_DuAn_BuocHienTaiId",
                table: "DuAn");

            migrationBuilder.DropIndex(
                name: "IX_DuAn_TrangThaiHienTaiId",
                table: "DuAn");

            migrationBuilder.RenameColumn(
                name: "PhuongThucLuaChonNhaThauId",
                table: "GoiThau",
                newName: "PhuongThucChonGoiThauId");

            migrationBuilder.RenameIndex(
                name: "IX_GoiThau_PhuongThucLuaChonNhaThauId",
                table: "GoiThau",
                newName: "IX_GoiThau_PhuongThucChonGoiThauId");

            migrationBuilder.AddColumn<int>(
                name: "DanhMucHinhThucLuaChonNhaThauId",
                table: "GoiThau",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrangThaiTienDoId",
                table: "DuAn",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DmPhuongThucChonGoiThau",
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
                    Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DmPhuongThucChonGoiThau", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GoiThau_DanhMucHinhThucLuaChonNhaThauId",
                table: "GoiThau",
                column: "DanhMucHinhThucLuaChonNhaThauId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_BuocHienTaiId",
                table: "DuAn",
                column: "BuocHienTaiId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAn_TrangThaiTienDoId",
                table: "DuAn",
                column: "TrangThaiTienDoId");

            migrationBuilder.CreateIndex(
                name: "IX_DmPhuongThucChonGoiThau_Index",
                table: "DmPhuongThucChonGoiThau",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_DuAn_DmBuoc_BuocHienTaiId",
                table: "DuAn",
                column: "BuocHienTaiId",
                principalTable: "DmBuoc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DuAn_DmTrangThaiTienDo_TrangThaiTienDoId",
                table: "DuAn",
                column: "TrangThaiTienDoId",
                principalTable: "DmTrangThaiTienDo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoiThau_DmHinhThucLuaChonNhaThau_DanhMucHinhThucLuaChonNhaThauId",
                table: "GoiThau",
                column: "DanhMucHinhThucLuaChonNhaThauId",
                principalTable: "DmHinhThucLuaChonNhaThau",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GoiThau_DmPhuongThucChonGoiThau_PhuongThucChonGoiThauId",
                table: "GoiThau",
                column: "PhuongThucChonGoiThauId",
                principalTable: "DmPhuongThucChonGoiThau",
                principalColumn: "Id");
        }
    }
}
