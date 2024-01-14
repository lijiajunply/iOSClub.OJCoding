using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OJBlazor.Share.Migrations
{
    /// <inheritdoc />
    public partial class AddTestCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Arg",
                table: "TestModels",
                newName: "TestCode");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "TestModels",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "TestModels");

            migrationBuilder.RenameColumn(
                name: "TestCode",
                table: "TestModels",
                newName: "Arg");
        }
    }
}
