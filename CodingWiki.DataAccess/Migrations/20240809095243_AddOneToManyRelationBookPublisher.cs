using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddOneToManyRelationBookPublisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublshiderId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 1,
                column: "PublshiderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 2,
                column: "PublshiderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 3,
                column: "PublshiderId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 4,
                column: "PublshiderId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "IdBook",
                keyValue: 5,
                column: "PublshiderId",
                value: 3);

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "IdPublisher", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Chicago", "Pub 1 Jimmy" },
                    { 2, "New York", "Pub 2 John" },
                    { 3, "Hawaii", "Pub 3 Ben" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublshiderId",
                table: "Books",
                column: "PublshiderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Publishers_PublshiderId",
                table: "Books",
                column: "PublshiderId",
                principalTable: "Publishers",
                principalColumn: "IdPublisher",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Publishers_PublshiderId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_PublshiderId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "IdPublisher",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "IdPublisher",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "IdPublisher",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "PublshiderId",
                table: "Books");
        }
    }
}
