using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentOneToManyRelationBookPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublshiderId",
                table: "FluentBooks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBooks_PublshiderId",
                table: "FluentBooks",
                column: "PublshiderId");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBooks_FluentPublishers_PublshiderId",
                table: "FluentBooks",
                column: "PublshiderId",
                principalTable: "FluentPublishers",
                principalColumn: "IdPublisher",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBooks_FluentPublishers_PublshiderId",
                table: "FluentBooks");

            migrationBuilder.DropIndex(
                name: "IX_FluentBooks_PublshiderId",
                table: "FluentBooks");

            migrationBuilder.DropColumn(
                name: "PublshiderId",
                table: "FluentBooks");
        }
    }
}
