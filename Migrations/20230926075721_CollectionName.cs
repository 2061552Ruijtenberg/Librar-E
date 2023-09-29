using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryCollectionWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class CollectionName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCollections_Users_UserId",
                table: "BookCollections");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookCollections",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BookCollections",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollections_Users_UserId",
                table: "BookCollections",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookCollections_Users_UserId",
                table: "BookCollections");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BookCollections");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "BookCollections",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BookCollections_Users_UserId",
                table: "BookCollections",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
