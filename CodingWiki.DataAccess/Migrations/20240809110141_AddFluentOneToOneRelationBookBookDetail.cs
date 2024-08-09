using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentOneToOneRelationBookBookDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdBook",
                table: "FluentBookDetailes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookDetailes_IdBook",
                table: "FluentBookDetailes",
                column: "IdBook",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookDetailes_FluentBooks_IdBook",
                table: "FluentBookDetailes",
                column: "IdBook",
                principalTable: "FluentBooks",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookDetailes_FluentBooks_IdBook",
                table: "FluentBookDetailes");

            migrationBuilder.DropIndex(
                name: "IX_FluentBookDetailes_IdBook",
                table: "FluentBookDetailes");

            migrationBuilder.DropColumn(
                name: "IdBook",
                table: "FluentBookDetailes");
        }
    }
}
