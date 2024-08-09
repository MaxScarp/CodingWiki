using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToOneRelationBookBookDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdBook",
                table: "BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookDetails_IdBook",
                table: "BookDetails",
                column: "IdBook",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetails_Books_IdBook",
                table: "BookDetails",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetails_Books_IdBook",
                table: "BookDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookDetails_IdBook",
                table: "BookDetails");

            migrationBuilder.DropColumn(
                name: "IdBook",
                table: "BookDetails");
        }
    }
}
