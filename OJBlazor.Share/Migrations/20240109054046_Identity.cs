using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OJBlazor.Share.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Authorization",
                table: "UserModels",
                newName: "Identity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identity",
                table: "UserModels",
                newName: "Authorization");
        }
    }
}
