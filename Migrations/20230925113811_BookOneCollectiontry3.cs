using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCollectionWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class BookOneCollectiontry3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCollections_BookCollectionId",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BookCollectionId",
                table: "Books",
                newName: "BookCollectionID");

            migrationBuilder.RenameIndex(
                name: "IX_Books_BookCollectionId",
                table: "Books",
                newName: "IX_Books_BookCollectionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCollections_BookCollectionID",
                table: "Books",
                column: "BookCollectionID",
                principalTable: "BookCollections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCollections_BookCollectionID",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "BookCollectionID",
                table: "Books",
                newName: "BookCollectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_BookCollectionID",
                table: "Books",
                newName: "IX_Books_BookCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCollections_BookCollectionId",
                table: "Books",
                column: "BookCollectionId",
                principalTable: "BookCollections",
                principalColumn: "Id");
        }
    }
}
