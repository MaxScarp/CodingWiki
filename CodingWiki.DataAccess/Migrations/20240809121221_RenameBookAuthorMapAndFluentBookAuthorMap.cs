using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenameBookAuthorMapAndFluentBookAuthorMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_AuthorId",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Books_IdBook",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthorMap_FluentAuthors_AuthorId",
                table: "FluentBookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthorMap_FluentBooks_IdBook",
                table: "FluentBookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBookAuthorMap",
                table: "FluentBookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "FluentBookAuthorMap",
                newName: "FluentBookAuthorMapTable");

            migrationBuilder.RenameTable(
                name: "BookAuthorMap",
                newName: "BookAuthorMapTable");

            migrationBuilder.RenameIndex(
                name: "IX_FluentBookAuthorMap_AuthorId",
                table: "FluentBookAuthorMapTable",
                newName: "IX_FluentBookAuthorMapTable_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMap_IdBook",
                table: "BookAuthorMapTable",
                newName: "IX_BookAuthorMapTable_IdBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBookAuthorMapTable",
                table: "FluentBookAuthorMapTable",
                columns: new[] { "IdBook", "AuthorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMapTable",
                table: "BookAuthorMapTable",
                columns: new[] { "AuthorId", "IdBook" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMapTable_Authors_AuthorId",
                table: "BookAuthorMapTable",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMapTable_Books_IdBook",
                table: "BookAuthorMapTable",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthorMapTable_FluentAuthors_AuthorId",
                table: "FluentBookAuthorMapTable",
                column: "AuthorId",
                principalTable: "FluentAuthors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthorMapTable_FluentBooks_IdBook",
                table: "FluentBookAuthorMapTable",
                column: "IdBook",
                principalTable: "FluentBooks",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMapTable_Authors_AuthorId",
                table: "BookAuthorMapTable");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMapTable_Books_IdBook",
                table: "BookAuthorMapTable");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthorMapTable_FluentAuthors_AuthorId",
                table: "FluentBookAuthorMapTable");

            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthorMapTable_FluentBooks_IdBook",
                table: "FluentBookAuthorMapTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentBookAuthorMapTable",
                table: "FluentBookAuthorMapTable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMapTable",
                table: "BookAuthorMapTable");

            migrationBuilder.RenameTable(
                name: "FluentBookAuthorMapTable",
                newName: "FluentBookAuthorMap");

            migrationBuilder.RenameTable(
                name: "BookAuthorMapTable",
                newName: "BookAuthorMap");

            migrationBuilder.RenameIndex(
                name: "IX_FluentBookAuthorMapTable_AuthorId",
                table: "FluentBookAuthorMap",
                newName: "IX_FluentBookAuthorMap_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMapTable_IdBook",
                table: "BookAuthorMap",
                newName: "IX_BookAuthorMap_IdBook");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentBookAuthorMap",
                table: "FluentBookAuthorMap",
                columns: new[] { "IdBook", "AuthorId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap",
                columns: new[] { "AuthorId", "IdBook" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_AuthorId",
                table: "BookAuthorMap",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Books_IdBook",
                table: "BookAuthorMap",
                column: "IdBook",
                principalTable: "Books",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthorMap_FluentAuthors_AuthorId",
                table: "FluentBookAuthorMap",
                column: "AuthorId",
                principalTable: "FluentAuthors",
                principalColumn: "IdAuthor",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthorMap_FluentBooks_IdBook",
                table: "FluentBookAuthorMap",
                column: "IdBook",
                principalTable: "FluentBooks",
                principalColumn: "IdBook",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
