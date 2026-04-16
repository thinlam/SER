using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLDA.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class AddStoredProcedure_GetRolesAndPermissionsByTabId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE PROCEDURE [dbo].[GetRolesAndPermissionsByTabId]
                    @TabId INT
                AS
                BEGIN
                    SELECT 
                        r.RoleID,
                        r.RoleName, 
                        r.UserID,
                        p.PermissionKey
                    FROM 
                        VI_PORTAL.dbo.TabPermission tp
                        INNER JOIN VI_PORTAL.dbo.Permission p ON tp.PermissionID = p.PermissionID
                        LEFT JOIN (
                            SELECT r.RoleID, r.RoleName, u.UserID 
                            FROM VI_PORTAL.dbo.Roles r 
                            JOIN VI_PORTAL.dbo.UserRoles u ON u.RoleID = r.RoleID 
                        ) r ON tp.RoleID = r.RoleID
                    WHERE 
                        tp.TabID = @TabId
                        AND r.RoleID <> 0
                        AND tp.AllowAccess = 1
                    ORDER BY 
                        p.PermissionKey, r.RoleName;
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [dbo].[GetRolesAndPermissionsByTabId]");
        }
    }
}
