using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class MoveFieldsFromGoiThauToKetQuaTrungThau : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GoiThau_DmLoaiGoiThau_LoaiGoiThauId",
                table: "GoiThau");

            migrationBuilder.DropIndex(
                name: "IX_GoiThau_LoaiGoiThauId",
                table: "GoiThau");

            migrationBuilder.DropColumn(
                name: "LoaiGoiThauId",
                table: "GoiThau");

            migrationBuilder.DropColumn(
                name: "NgayEHSMT",
                table: "GoiThau");

            migrationBuilder.DropColumn(
                name: "NgayMoThau",
                table: "GoiThau");

            migrationBuilder.AddColumn<int>(
                name: "LoaiGoiThauId",
                table: "KetQuaTrungThau",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayEHSMT",
                table: "KetQuaTrungThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayMoThau",
                table: "KetQuaTrungThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HoSoMoiThau",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWSEQUENTIALID()"),
                    DuAnId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuocId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Index = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoSoMoiThau", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KetQuaTrungThau_LoaiGoiThauId",
                table: "KetQuaTrungThau",
                column: "LoaiGoiThauId");

            migrationBuilder.CreateIndex(
                name: "IX_HoSoMoiThau_Index",
                table: "HoSoMoiThau",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.AddForeignKey(
                name: "FK_KetQuaTrungThau_DmLoaiGoiThau_LoaiGoiThauId",
                table: "KetQuaTrungThau",
                column: "LoaiGoiThauId",
                principalTable: "DmLoaiGoiThau",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KetQuaTrungThau_DmLoaiGoiThau_LoaiGoiThauId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropTable(
                name: "HoSoMoiThau");

            migrationBuilder.DropIndex(
                name: "IX_KetQuaTrungThau_LoaiGoiThauId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropColumn(
                name: "LoaiGoiThauId",
                table: "KetQuaTrungThau");

            migrationBuilder.DropColumn(
                name: "NgayEHSMT",
                table: "KetQuaTrungThau");

            migrationBuilder.DropColumn(
                name: "NgayMoThau",
                table: "KetQuaTrungThau");

            migrationBuilder.AddColumn<int>(
                name: "LoaiGoiThauId",
                table: "GoiThau",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayEHSMT",
                table: "GoiThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "NgayMoThau",
                table: "GoiThau",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GoiThau_LoaiGoiThauId",
                table: "GoiThau",
                column: "LoaiGoiThauId");

            migrationBuilder.AddForeignKey(
                name: "FK_GoiThau_DmLoaiGoiThau_LoaiGoiThauId",
                table: "GoiThau",
                column: "LoaiGoiThauId",
                principalTable: "DmLoaiGoiThau",
                principalColumn: "Id");
        }
    }
}
