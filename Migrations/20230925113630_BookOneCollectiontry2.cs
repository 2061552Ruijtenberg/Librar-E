using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCollectionWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class BookOneCollectiontry2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCollections_BookCollectionId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookCollectionId",
                table: "Books",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCollections_BookCollectionId",
                table: "Books",
                column: "BookCollectionId",
                principalTable: "BookCollections",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookCollections_BookCollectionId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookCollectionId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookCollections_BookCollectionId",
                table: "Books",
                column: "BookCollectionId",
                principalTable: "BookCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
