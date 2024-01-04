using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OJCoding.Share.Migrations
{
    /// <inheritdoc />
    public partial class AddNameFromTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TestModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TestModels");
        }
    }
}
