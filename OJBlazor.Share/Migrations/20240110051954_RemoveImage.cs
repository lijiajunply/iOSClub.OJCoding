using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OJBlazor.Share.Migrations
{
    /// <inheritdoc />
    public partial class RemoveImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.DropColumn(
                name: "Material",
                table: "CourseModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Material",
                table: "CourseModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(256)", nullable: false),
                    Identity = table.Column<string>(type: "TEXT", nullable: false),
                    LearnCourses = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.Id);
                });
        }
    }
}
