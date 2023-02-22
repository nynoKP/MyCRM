using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCRM.Migrations
{
    /// <inheritdoc />
    public partial class AddPinContragent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "Contragent",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pin",
                table: "Contragent");
        }
    }
}
