using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EntityFrameworkMigration.Migrations
{
    /// <inheritdoc />
    public partial class seed_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Maths is a tough subject", "Maths" },
                    { 2, "Environmental Science", "Science" },
                    { 3, "History", "Social" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[] { 1, "pushpa@gmail.com", "Pushpa", "666-666-666" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "CourseId", "StudentAddress", "StudentDOB", "StudentGender", "StudentName", "StudentPhone", "studentEmail" },
                values: new object[] { 1, 1, "123-456-789", new DateTime(2006, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Male", "Vignesh", "565-908-765", "vignesh@gmail.com" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
