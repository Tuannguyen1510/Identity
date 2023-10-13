using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    /// <inheritdoc />
    public partial class AssignAdminUserToAllRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[UserRoles] (UserId, RoleId) SELECT '7bceab02-2193-4589-a191-72189e38cbdf', Id FROM [security].[Roles]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[UserRoles] WHERE UserId = '7bceab02-2193-4589-a191-72189e38cbdf'");
        }
    }
}
