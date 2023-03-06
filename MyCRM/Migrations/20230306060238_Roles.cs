using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyCRM.Migrations
{
    /// <inheritdoc />
    public partial class Roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "StatusId");

            migrationBuilder.CreateTable(
                name: "TaskStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    isDefault = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskStatus", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c40e32c7-ba16-40be-a0ff-3a8f47e37e88",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7a9b4493-38b9-492d-a93c-62aeb375456c", "AQAAAAIAAYagAAAAEB7KdjCt3wnoHyLBXwrVBVKKcT6RwgELBn42QaHul+haXT6kfCM+zdFXVHgxwnVjXg==", "296edaab-fe5f-4095-986f-581cbb979774" });

            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "Name", "isDefault" },
                values: new object[,]
                {
                    { 1, "Неопределена", false },
                    { 2, "Активна", false },
                    { 3, "В ожидании", false },
                    { 4, "Завершена", false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_TaskStatus_StatusId",
                table: "Tasks",
                column: "StatusId",
                principalTable: "TaskStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_TaskStatus_StatusId",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskStatus");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_StatusId",
                table: "Tasks");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Tasks",
                newName: "Status");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c40e32c7-ba16-40be-a0ff-3a8f47e37e88",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4545c69e-137f-498a-a83c-8c0b3da167f6", "AQAAAAIAAYagAAAAEDlwkVsSLoQ8LpwjIEtnXFg+UPmQooB5wOQHGLcBPh3KUTKyqXZQJ2pP7XA4kiDang==", "da7d990c-8559-486a-9c45-9c840c6d58e3" });
        }
    }
}
