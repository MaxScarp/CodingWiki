using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookTable",
                columns: new[] { "IdBook", "ISBN", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "123B12", 10.99m, "Spider Without Duty" },
                    { 2, "12123B12", 11.99m, "Fortune Of Time" },
                    { 3, "77652", 20.99m, "Fake Sunday" },
                    { 4, "CC12B12", 25.99m, "Cookie Jar" },
                    { 5, "90392B33", 40.99m, "Cloudy Forest" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookTable",
                keyColumn: "IdBook",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookTable",
                keyColumn: "IdBook",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookTable",
                keyColumn: "IdBook",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookTable",
                keyColumn: "IdBook",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookTable",
                keyColumn: "IdBook",
                keyValue: 5);
        }
    }
}
