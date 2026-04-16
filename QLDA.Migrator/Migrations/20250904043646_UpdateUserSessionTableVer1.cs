using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserSessionTableVer1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSessions",
                table: "UserSessions");

            migrationBuilder.DropIndex(
                name: "IX_UserSessions_ExpireAt",
                table: "UserSessions");

            migrationBuilder.DropIndex(
                name: "IX_UserSessions_Username_RefreshToken",
                table: "UserSessions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "UserSessions");

            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "UserSessions");

            migrationBuilder.DropColumn(
                name: "ExpireAt",
                table: "UserSessions");

            migrationBuilder.DropColumn(
                name: "Index",
                table: "UserSessions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserSessions");

            migrationBuilder.DropColumn(
                name: "LastUsedAt",
                table: "UserSessions");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "UserSessions");

            migrationBuilder.RenameTable(
                name: "UserSessions",
                newName: "UserSession");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "UserSession",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "UserSession",
                newName: "UserId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "UserSession",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "DeviceName",
                table: "UserSession",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "UserSession",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "UserSession",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "UserSession",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemembered",
                table: "UserSession",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRevoked",
                table: "UserSession",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LastActivityAt",
                table: "UserSession",
                type: "datetimeoffset",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<int>(
                name: "Platform",
                table: "UserSession",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "RefreshTokenExpiresAt",
                table: "UserSession",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<string>(
                name: "UserAgent",
                table: "UserSession",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSession",
                table: "UserSession",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_Platform",
                table: "UserSession",
                column: "Platform");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_UserName",
                table: "UserSession",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_UserName_Platform",
                table: "UserSession",
                columns: new[] { "UserName", "Platform" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSession",
                table: "UserSession");

            migrationBuilder.DropIndex(
                name: "IX_UserSession_Platform",
                table: "UserSession");

            migrationBuilder.DropIndex(
                name: "IX_UserSession_UserName",
                table: "UserSession");

            migrationBuilder.DropIndex(
                name: "IX_UserSession_UserName_Platform",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "IsRemembered",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "IsRevoked",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "LastActivityAt",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "Platform",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiresAt",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "UserAgent",
                table: "UserSession");

            migrationBuilder.RenameTable(
                name: "UserSession",
                newName: "UserSessions");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "UserSessions",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserSessions",
                newName: "UpdatedBy");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "UserSessions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceName",
                table: "UserSessions",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "UserSessions",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.AlterColumn<Guid>(
                name: "SessionId",
                table: "UserSessions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "UserSessions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeviceId",
                table: "UserSessions",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireAt",
                table: "UserSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "Index",
                table: "UserSessions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserSessions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUsedAt",
                table: "UserSessions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                table: "UserSessions",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSessions",
                table: "UserSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_ExpireAt",
                table: "UserSessions",
                column: "ExpireAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_Username_RefreshToken",
                table: "UserSessions",
                columns: new[] { "Username", "RefreshToken" });
        }
    }
}
