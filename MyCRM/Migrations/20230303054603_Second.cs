using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyCRM.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c40e32c7-ba16-40be-a0ff-3a8f47e37e88",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4545c69e-137f-498a-a83c-8c0b3da167f6", "AQAAAAIAAYagAAAAEDlwkVsSLoQ8LpwjIEtnXFg+UPmQooB5wOQHGLcBPh3KUTKyqXZQJ2pP7XA4kiDang==", "da7d990c-8559-486a-9c45-9c840c6d58e3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c40e32c7-ba16-40be-a0ff-3a8f47e37e88",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "603a0816-986b-42d5-aad9-aa1b3457913e", "AQAAAAIAAYagAAAAENIdlMfkHnB2Vgh5lfLBMoJfMZK1cQJg620bxBFKTD1MYrV1WUhks/5Z1pMe5zbi/w==", "5edaecdc-0bab-4989-9c72-b929bdde564c" });
        }
    }
}
