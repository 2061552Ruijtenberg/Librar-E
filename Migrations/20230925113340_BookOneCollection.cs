using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCollectionWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class BookOneCollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookBookCollection");

            migrationBuilder.AddColumn<int>(
                name: "BookCollectionId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookCollectionId",
                table: "Books",
                column: "BookCollectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCollections_BookCollectionId",
                table: "Books",
                column: "BookCollectionId",
                principalTable: "BookCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCollections_BookCollectionId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookCollectionId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookCollectionId",
                table: "Books");

            migrationBuilder.CreateTable(
                name: "BookBookCollection",
                columns: table => new
                {
                    BooksId = table.Column<int>(type: "int", nullable: false),
                    CollectionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookBookCollection", x => new { x.BooksId, x.CollectionsId });
                    table.ForeignKey(
                        name: "FK_BookBookCollection_BookCollections_CollectionsId",
                        column: x => x.CollectionsId,
                        principalTable: "BookCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookBookCollection_Books_BooksId",
                        column: x => x.BooksId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookBookCollection_CollectionsId",
                table: "BookBookCollection",
                column: "CollectionsId");
        }
    }
}
