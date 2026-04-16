using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Add_QuyetDinhLapTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuyetDinhLapBanQLDA",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyetDinhLapBanQLDA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyetDinhLapBanQLDA_VanBanQuyetDinh_Id",
                        column: x => x.Id,
                        principalTable: "VanBanQuyetDinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyetDinhLapBenMoiThau",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyetDinhLapBenMoiThau", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyetDinhLapBenMoiThau_VanBanQuyetDinh_Id",
                        column: x => x.Id,
                        principalTable: "VanBanQuyetDinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuyetDinhLapHoiDongThamDinh",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuyetDinhLapHoiDongThamDinh", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuyetDinhLapHoiDongThamDinh_VanBanQuyetDinh_Id",
                        column: x => x.Id,
                        principalTable: "VanBanQuyetDinh",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThanhVienBanQLDA",
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
                    QuyetDinhId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChucVu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VaiTro = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThanhVienBanQLDA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThanhVienBanQLDA_QuyetDinhLapBanQLDA_QuyetDinhId",
                        column: x => x.QuyetDinhId,
                        principalTable: "QuyetDinhLapBanQLDA",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienBanQLDA_Index",
                table: "ThanhVienBanQLDA",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienBanQLDA_QuyetDinhId",
                table: "ThanhVienBanQLDA",
                column: "QuyetDinhId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuyetDinhLapBenMoiThau");

            migrationBuilder.DropTable(
                name: "QuyetDinhLapHoiDongThamDinh");

            migrationBuilder.DropTable(
                name: "ThanhVienBanQLDA");

            migrationBuilder.DropTable(
                name: "QuyetDinhLapBanQLDA");
        }
    }
}
