using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apiDatasheets.Migrations
{
    /// <inheritdoc />
    public partial class Filename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Path",
                table: "DataSheets",
                newName: "Filename");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Filename",
                table: "DataSheets",
                newName: "Path");
        }
    }
}
