using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateGenreTableNameAndDisplayOrderColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GenreTable",
                table: "GenreTable");

            migrationBuilder.RenameTable(
                name: "GenreTable",
                newName: "Genres");

            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Genres",
                newName: "Order");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "IdGenre");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "GenreTable");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "GenreTable",
                newName: "DisplayOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GenreTable",
                table: "GenreTable",
                column: "IdGenre");
        }
    }
}
