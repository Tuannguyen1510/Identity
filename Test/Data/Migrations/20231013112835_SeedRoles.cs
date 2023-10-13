using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<byte[]>(
            //    name: "ProfilePicture",
            //    schema: "security",
            //    table: "Users",
            //    type: "varbinary(max)",
            //    nullable: true,
            //    oldClrType: typeof(byte[]),
            //    oldType: "varbinary(max)");

        migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] {"Id", "Name", "NormalizedName", "ConcurrencyStamp"},
                values: new object[] {Guid.NewGuid().ToString(), "User", "User".ToUpper(), Guid.NewGuid().ToString()},
                 schema: "security"
                );


        migrationBuilder.InsertData(
        table: "Roles",
        columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
        values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() },

         schema: "security"
        );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<byte[]>(
            //    name: "ProfilePicture",
            //    schema: "security",
            //    table: "Users",
            //    type: "varbinary(max)",
            //    nullable: false,
            //    defaultValue: new byte[0],
            //    oldClrType: typeof(byte[]),
            //    oldType: "varbinary(max)",
            //    oldNullable: true);

            migrationBuilder.Sql("DELETE FROM [security].[Roles]");
        
        }



    }
}
