using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OJCoding.Share.Migrations
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
                    Guid = table.Column<string>(type: "varchar(256)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Intro = table.Column<string>(type: "TEXT", nullable: false),
                    Material = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseModels", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "varchar(256)", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "TestModels",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "varchar(256)", nullable: false),
                    Intro = table.Column<string>(type: "TEXT", nullable: false),
                    Arg = table.Column<string>(type: "TEXT", nullable: false),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    CourseModelGuid = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestModels", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_TestModels_CourseModels_CourseModelGuid",
                        column: x => x.CourseModelGuid,
                        principalTable: "CourseModels",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "LearnCourseModel",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "varchar(256)", nullable: false),
                    CourseGuid = table.Column<string>(type: "varchar(256)", nullable: false),
                    UserModelGuid = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnCourseModel", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LearnCourseModel_CourseModels_CourseGuid",
                        column: x => x.CourseGuid,
                        principalTable: "CourseModels",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LearnCourseModel_UserModels_UserModelGuid",
                        column: x => x.UserModelGuid,
                        principalTable: "UserModels",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "LearnTestModel",
                columns: table => new
                {
                    Guid = table.Column<string>(type: "varchar(256)", nullable: false),
                    TestGuid = table.Column<string>(type: "varchar(256)", nullable: false),
                    Data = table.Column<string>(type: "TEXT", nullable: false),
                    LearnCourseModelGuid = table.Column<string>(type: "varchar(256)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearnTestModel", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_LearnTestModel_LearnCourseModel_LearnCourseModelGuid",
                        column: x => x.LearnCourseModelGuid,
                        principalTable: "LearnCourseModel",
                        principalColumn: "Guid");
                    table.ForeignKey(
                        name: "FK_LearnTestModel_TestModels_TestGuid",
                        column: x => x.TestGuid,
                        principalTable: "TestModels",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LearnCourseModel_CourseGuid",
                table: "LearnCourseModel",
                column: "CourseGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LearnCourseModel_UserModelGuid",
                table: "LearnCourseModel",
                column: "UserModelGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LearnTestModel_LearnCourseModelGuid",
                table: "LearnTestModel",
                column: "LearnCourseModelGuid");

            migrationBuilder.CreateIndex(
                name: "IX_LearnTestModel_TestGuid",
                table: "LearnTestModel",
                column: "TestGuid");

            migrationBuilder.CreateIndex(
                name: "IX_TestModels_CourseModelGuid",
                table: "TestModels",
                column: "CourseModelGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LearnTestModel");

            migrationBuilder.DropTable(
                name: "LearnCourseModel");

            migrationBuilder.DropTable(
                name: "TestModels");

            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.DropTable(
                name: "CourseModels");
        }
    }
}
