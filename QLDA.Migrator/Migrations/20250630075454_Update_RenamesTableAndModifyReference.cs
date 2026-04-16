using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Update_RenamesTableAndModifyReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_GoiThau_GoiThauId",
                table: "HopDong");
            //
            // migrationBuilder.DropForeignKey(
            //     name: "FK_ThanhVienBanQLDA_QuyetDinhLapBanQLDA_QuyetDinhId",
            //     table: "ThanhVienBanQLDA");
            //
            // migrationBuilder.DropTable(
            //     name: "QuyetDinhLapBanQLDA");
            //
            // migrationBuilder.DropTable(
            //     name: "QuyetDinhLapBenMoiThau");
            //
            // migrationBuilder.DropTable(
            //     name: "QuyetDinhLapHoiDongThamDinh");
            //
            migrationBuilder.DropIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong");
            //
            // migrationBuilder.AddColumn<string>(
            //     name: "Discriminator",
            //     table: "VanBanQuyetDinh",
            //     type: "nvarchar(21)",
            //     maxLength: 21,
            //     nullable: false,
            //     defaultValue: "");
            //
            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong",
                column: "GoiThauId",
                unique: true,
                filter: "[GoiThauId] IS NOT NULL");
            
            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_GoiThau_GoiThauId",
                table: "HopDong",
                column: "GoiThauId",
                principalTable: "GoiThau",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            //
            // migrationBuilder.AddForeignKey(
            //     name: "FK_ThanhVienBanQLDA_VanBanQuyetDinh_QuyetDinhId",
            //     table: "ThanhVienBanQLDA",
            //     column: "QuyetDinhId",
            //     principalTable: "VanBanQuyetDinh",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HopDong_GoiThau_GoiThauId",
                table: "HopDong");

            migrationBuilder.DropForeignKey(
                name: "FK_ThanhVienBanQLDA_VanBanQuyetDinh_QuyetDinhId",
                table: "ThanhVienBanQLDA");

            migrationBuilder.DropIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "VanBanQuyetDinh");

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

            migrationBuilder.CreateIndex(
                name: "IX_HopDong_GoiThauId",
                table: "HopDong",
                column: "GoiThauId");

            migrationBuilder.AddForeignKey(
                name: "FK_HopDong_GoiThau_GoiThauId",
                table: "HopDong",
                column: "GoiThauId",
                principalTable: "GoiThau",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ThanhVienBanQLDA_QuyetDinhLapBanQLDA_QuyetDinhId",
                table: "ThanhVienBanQLDA",
                column: "QuyetDinhId",
                principalTable: "QuyetDinhLapBanQLDA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
