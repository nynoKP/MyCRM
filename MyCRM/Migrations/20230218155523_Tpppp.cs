using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCRM.Migrations
{
    /// <inheritdoc />
    public partial class Tpppp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_AuthorId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "News",
                newName: "CRMUserId");

            migrationBuilder.RenameIndex(
                name: "IX_News_AuthorId",
                table: "News",
                newName: "IX_News_CRMUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_CRMUserId",
                table: "News",
                column: "CRMUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_News_AspNetUsers_CRMUserId",
                table: "News");

            migrationBuilder.RenameColumn(
                name: "CRMUserId",
                table: "News",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_News_CRMUserId",
                table: "News",
                newName: "IX_News_AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_News_AspNetUsers_AuthorId",
                table: "News",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
