using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestingPlatform.Migrations
{
    /// <inheritdoc />
    public partial class InitStudents2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 22, 8, 10, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 22, 8, 11, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 29, 21, 14, 27, 495, DateTimeKind.Unspecified).AddTicks(7444), new TimeSpan(0, 7, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTimeOffset(new DateTime(2025, 9, 29, 21, 14, 27, 495, DateTimeKind.Unspecified).AddTicks(7485), new TimeSpan(0, 7, 0, 0, 0)));
        }
    }
}
