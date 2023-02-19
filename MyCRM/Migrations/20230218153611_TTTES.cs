using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCRM.Migrations
{
    /// <inheritdoc />
    public partial class TTTES : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_AuthorId",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "News",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_AuthorId",
                table: "News",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_AuthorId",
                table: "News");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "News",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_AuthorId",
                table: "News",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
