using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [security].[Users] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [ProfilePicture]) VALUES (N'7bceab02-2193-4589-a191-72189e38cbdf', N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 0, N'AQAAAAIAAYagAAAAEF4V7Wl5sRi2pJ+BOmk5Sqa7yMtj0qbmZi1EFlX1FLYt8sGe0JX2i1ybjWiG+yl3/g==', N'NZYVRBBL7OGCPWLGSCKGJN4PDT4SEZCF', N'd5865b57-13a4-4c48-8cdb-45107fc46bba', NULL, 0, 0, NULL, 1, 0, N'adminTest', N'admintest',NULL)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [security].[Users] WHERE Id = '7bceab02-2193-4589-a191-72189e38cbdf'");
        }
    }
}
