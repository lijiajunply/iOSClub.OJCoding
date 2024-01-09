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
                name: "UserModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseModels",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Intro = table.Column<string>(type: "TEXT", nullable: false),
                    Material = table.Column<string>(type: "TEXT", nullable: false),
                    UserModelId = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModels", x => x.Name);
                    table.ForeignKey(
                        name: "FK_CourseModels_UserModels_UserModelId",
                        column: x => x.UserModelId,
                        principalTable: "UserModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TestModels",
                columns: table => new
                {
                    Name = table.Column<string>(type: "varchar(256)", nullable: false),
                    Intro = table.Column<string>(type: "TEXT", nullable: false),
                    Arg = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    CourseModelName = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModels", x => x.Name);
                    table.ForeignKey(
                        name: "FK_TestModels_CourseModels_CourseModelName",
                        column: x => x.CourseModelName,
                        principalTable: "CourseModels",
                        principalColumn: "Name");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseModels_UserModelId",
                table: "CourseModels",
                column: "UserModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TestModels_CourseModelName",
                table: "TestModels",
                column: "CourseModelName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestModels");

            migrationBuilder.DropTable(
                name: "CourseModels");

            migrationBuilder.DropTable(
                name: "UserModels");
        }
    }
}
