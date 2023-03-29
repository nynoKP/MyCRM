using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCRM.Migrations
{
    /// <inheritdoc />
    public partial class UserAvatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AvatarPath",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c40e32c7-ba16-40be-a0ff-3a8f47e37e88",
                columns: new[] { "AvatarPath", "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "~/dist/img/avatar5.png", "249c2feb-c0fd-4b9f-8ed1-855e40f3c274", "AQAAAAIAAYagAAAAEDFRnW2GNoQxZAIZ+zCm9WDAuoHpdOPCrk2t0Zp3aNOcWt1nXdA8RYRgz55IZBcChw==", "d16074f1-bf9b-472b-91e7-6c77ccb5d70a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarPath",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c40e32c7-ba16-40be-a0ff-3a8f47e37e88",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ee791f0-24d6-491a-a792-4bc5fde6171e", "AQAAAAIAAYagAAAAENxzrKAlh3MBERzVErZC1hh0zvKv17LL4ts9U83MAUSq/zRbgoHw4DSFN/PZjguljA==", "98a7d995-83f7-40eb-b5d8-6584a2b79d56" });
        }
    }
}
