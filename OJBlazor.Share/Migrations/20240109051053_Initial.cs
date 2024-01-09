using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OJBlazor.Share.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseModels",
                columns: table => new
                {
                    HashName = table.Column<string>(type: "varchar(256)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Intro = table.Column<string>(type: "TEXT", nullable: false),
                    Material = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModels", x => x.HashName);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Authorization = table.Column<string>(type: "TEXT", nullable: false),
                    LearnCourses = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TestModels",
                columns: table => new
                {
                    HashName = table.Column<string>(type: "varchar(256)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Intro = table.Column<string>(type: "TEXT", nullable: false),
                    Arg = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    CourseModelHashName = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModels", x => x.HashName);
                    table.ForeignKey(
                        name: "FK_TestModels_CourseModels_CourseModelHashName",
                        column: x => x.CourseModelHashName,
                        principalTable: "CourseModels",
                        principalColumn: "HashName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TestModels_CourseModelHashName",
                table: "TestModels",
                column: "CourseModelHashName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestModels");

            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.DropTable(
                name: "CourseModels");
        }
    }
}
