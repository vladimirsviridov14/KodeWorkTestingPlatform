using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestingPlatform.Migrations
{
    /// <inheritdoc />
    public partial class InitStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    FirtsName = table.Column<string>(type: "TEXT", nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    VKProfileLink = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "CreatedAt", "Email", "FirtsName", "LastName", "Login", "MiddleName", "Phone", "VKProfileLink" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2025, 9, 29, 21, 14, 27, 495, DateTimeKind.Unspecified).AddTicks(7444), new TimeSpan(0, 7, 0, 0, 0)), "vanya123@gmail.com", "Иван", "Иванов", "vanya123", "Иванович", "+71234567890", "http://vk.com/vanya123" },
                    { 2, new DateTimeOffset(new DateTime(2025, 9, 29, 21, 14, 27, 495, DateTimeKind.Unspecified).AddTicks(7485), new TimeSpan(0, 7, 0, 0, 0)), "marya123@gmail.com", "Мария", "Иванова", "marya123", "Ивановна", "+70987654321", "http://vk.com/marya123" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
