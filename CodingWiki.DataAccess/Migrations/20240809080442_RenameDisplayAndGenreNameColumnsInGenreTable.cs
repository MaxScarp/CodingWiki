using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameDisplayAndGenreNameColumnsInGenreTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "GenreTable",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Display",
                table: "GenreTable",
                newName: "DisplayOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "GenreTable",
                newName: "GenreName");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "GenreTable",
                newName: "Display");
        }
    }
}
