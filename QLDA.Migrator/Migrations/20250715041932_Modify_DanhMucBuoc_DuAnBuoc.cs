using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Modify_DanhMucBuoc_DuAnBuoc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAnBuoc_DmBuoc_BuocId",
                table: "DuAnBuoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DuAnBuoc_DmGiaiDoan_GiaiDoanId",
                table: "DuAnBuoc");

            migrationBuilder.DropForeignKey(
                name: "FK_DuAnBuoc_DmQuyTrinh_QuyTrinhId",
                table: "DuAnBuoc");

            migrationBuilder.DropTable(
                name: "DuAnBuocManHinh");

            migrationBuilder.DropTable(
                name: "DuAnBuocTrangThaiTienDo");

            migrationBuilder.DropTable(
                name: "HoSoMoiThau");

            migrationBuilder.DropIndex(
                name: "IX_DuAnBuoc_GiaiDoanId",
                table: "DuAnBuoc");

            migrationBuilder.DropIndex(
                name: "IX_DuAnBuoc_QuyTrinhId",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "GiaiDoanId",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "PartialView",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "QuyTrinhId",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "Stt",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "TenBuoc",
                table: "DuAnBuoc");

            migrationBuilder.DropColumn(
                name: "Used",
                table: "DuAnBuoc");

            migrationBuilder.AlterColumn<int>(
                name: "BuocId",
                table: "DuAnBuoc",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnBuoc_DmBuoc_BuocId",
                table: "DuAnBuoc",
                column: "BuocId",
                principalTable: "DmBuoc",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DuAnBuoc_DmBuoc_BuocId",
                table: "DuAnBuoc");

            migrationBuilder.AlterColumn<int>(
                name: "BuocId",
                table: "DuAnBuoc",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "GiaiDoanId",
                table: "DuAnBuoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "DuAnBuoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "DuAnBuoc",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PartialView",
                table: "DuAnBuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "DuAnBuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuyTrinhId",
                table: "DuAnBuoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stt",
                table: "DuAnBuoc",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TenBuoc",
                table: "DuAnBuoc",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Used",
                table: "DuAnBuoc",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "DuAnBuocManHinh",
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
                    BuocId = table.Column<int>(type: "int", nullable: false),
                    ManHinhId = table.Column<int>(type: "int", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAnBuocManHinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAnBuocManHinh_DuAnBuoc_BuocId",
                        column: x => x.BuocId,
                        principalTable: "DuAnBuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DuAnBuocManHinh_E_ManHinh_ManHinhId",
                        column: x => x.ManHinhId,
                        principalTable: "E_ManHinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DuAnBuocTrangThaiTienDo",
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
                    BuocId = table.Column<int>(type: "int", nullable: false),
                    TrangThaiId = table.Column<int>(type: "int", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mota = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Stt = table.Column<int>(type: "int", nullable: true),
                    Ten = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Used = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DuAnBuocTrangThaiTienDo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DuAnBuocTrangThaiTienDo_DmTrangThaiTienDo_TrangThaiId",
                        column: x => x.TrangThaiId,
                        principalTable: "DmTrangThaiTienDo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DuAnBuocTrangThaiTienDo_DuAnBuoc_BuocId",
                        column: x => x.BuocId,
                        principalTable: "DuAnBuoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoSoMoiThau",
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
                    BuocId = table.Column<int>(type: "int", nullable: true),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoMoiThau", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuoc_GiaiDoanId",
                table: "DuAnBuoc",
                column: "GiaiDoanId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuoc_QuyTrinhId",
                table: "DuAnBuoc",
                column: "QuyTrinhId");

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
                name: "IX_DuAnBuocManHinh_ManHinhId",
                table: "DuAnBuocManHinh",
                column: "ManHinhId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocTrangThaiTienDo_BuocId",
                table: "DuAnBuocTrangThaiTienDo",
                column: "BuocId");

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocTrangThaiTienDo_Index",
                table: "DuAnBuocTrangThaiTienDo",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_DuAnBuocTrangThaiTienDo_TrangThaiId",
                table: "DuAnBuocTrangThaiTienDo",
                column: "TrangThaiId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoMoiThau_Index",
                table: "HoSoMoiThau",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnBuoc_DmBuoc_BuocId",
                table: "DuAnBuoc",
                column: "BuocId",
                principalTable: "DmBuoc",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnBuoc_DmGiaiDoan_GiaiDoanId",
                table: "DuAnBuoc",
                column: "GiaiDoanId",
                principalTable: "DmGiaiDoan",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DuAnBuoc_DmQuyTrinh_QuyTrinhId",
                table: "DuAnBuoc",
                column: "QuyTrinhId",
                principalTable: "DmQuyTrinh",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
