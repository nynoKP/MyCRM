using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCRM.Migrations
{
    /// <inheritdoc />
    public partial class TaskStatuses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c40e32c7-ba16-40be-a0ff-3a8f47e37e88",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87ac6e2c-029f-4f5d-98b6-e961acf0c3be", "AQAAAAIAAYagAAAAEL0mQvnsZfYLRUebBLBj9QGq6QbBzKjNSpbypL8GoHfDBMO86S7rCPJw179827MM+w==", "0bce50e5-a397-44aa-bea5-fee6ae7ee318" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c40e32c7-ba16-40be-a0ff-3a8f47e37e88",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a9b4493-38b9-492d-a93c-62aeb375456c", "AQAAAAIAAYagAAAAEB7KdjCt3wnoHyLBXwrVBVKKcT6RwgELBn42QaHul+haXT6kfCM+zdFXVHgxwnVjXg==", "296edaab-fe5f-4095-986f-581cbb979774" });
        }
    }
}
