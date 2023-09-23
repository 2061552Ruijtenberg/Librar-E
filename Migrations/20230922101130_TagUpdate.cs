using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCollectionWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class TagUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Books_BookTagId",
                table: "BookTag");

            migrationBuilder.RenameColumn(
                name: "BookTagId",
                table: "BookTag",
                newName: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Books_BookId",
                table: "BookTag",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTag_Books_BookId",
                table: "BookTag");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "BookTag",
                newName: "BookTagId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTag_Books_BookTagId",
                table: "BookTag",
                column: "BookTagId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
