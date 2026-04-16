using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Update_ThanhVien_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ThanhVienBanQLDA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .Annotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ThanhVienBanQLDA",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .Annotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "ThanhVienBanQLDA",
                type: "bigint",
                nullable: false,
                defaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())",
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ThanhVienBanQLDA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .Annotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "SYSDATETIMEOFFSET()",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset")
                .Annotation("Relational:ColumnOrder", 102);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedDateTime",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: true)
                .Annotation("Relational:ColumnOrder", 100);

            migrationBuilder.CreateIndex(
                name: "IX_ThanhVienBanQLDA_Index",
                table: "ThanhVienBanQLDA",
                column: "Index")
                .Annotation("SqlServer:Clustered", false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ThanhVienBanQLDA_Index",
                table: "ThanhVienBanQLDA");

            migrationBuilder.DropColumn(
                name: "UpdatedDateTime",
                table: "ThanhVienBanQLDA");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "ThanhVienBanQLDA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 103);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldNullable: true)
                .OldAnnotation("Relational:ColumnOrder", 104);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ThanhVienBanQLDA",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit")
                .OldAnnotation("Relational:ColumnOrder", 105);

            migrationBuilder.AlterColumn<long>(
                name: "Index",
                table: "ThanhVienBanQLDA",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldDefaultValueSql: "DATEDIFF(SECOND, '19700101', GETUTCDATE())")
                .OldAnnotation("Relational:ColumnOrder", 106);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "ThanhVienBanQLDA",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)")
                .OldAnnotation("Relational:ColumnOrder", 101);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "ThanhVienBanQLDA",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "SYSDATETIMEOFFSET()")
                .OldAnnotation("Relational:ColumnOrder", 102);
        }
    }
}
