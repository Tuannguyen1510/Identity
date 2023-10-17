using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.CreateTable(
                name: "Dbgroups",
                columns: table => new
                {
                    IdGroups = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dbgroups", x => x.IdGroups);
                });

            migrationBuilder.CreateTable(
                name: "Dbcourses",
                columns: table => new
                {
                    IdCourses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdGroups = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dbcourses", x => x.IdCourses);
                    table.ForeignKey(
                        name: "FK_Dbcourses_Dbgroups_IdGroups",
                        column: x => x.IdGroups,
                        principalTable: "Dbgroups",
                        principalColumn: "IdGroups",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dbcourses_IdGroups",
                table: "Dbcourses",
                column: "IdGroups");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dbcourses");

            migrationBuilder.DropTable(
                name: "Dbgroups");

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    IdGroups = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.IdGroups);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    IdCourses = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGroups = table.Column<int>(type: "int", nullable: true),
                    CourseDescription = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.IdCourses);
                    table.ForeignKey(
                        name: "FK_Courses_Groups_IdGroups",
                        column: x => x.IdGroups,
                        principalTable: "Groups",
                        principalColumn: "IdGroups",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_IdGroups",
                table: "Courses",
                column: "IdGroups");
        }
    }
}
