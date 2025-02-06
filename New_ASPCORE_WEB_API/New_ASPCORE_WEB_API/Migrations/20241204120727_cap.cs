using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace New_ASPCORE_WEB_API.Migrations
{
    /// <inheritdoc />
    public partial class cap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Mathematics", "Maths" },
                    { 2, "Biology", "Science" },
                    { 3, "Story", "English" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "CourseId", "StudentAddress", "StudentDOB", "StudentEmail", "StudentGender", "StudentName", "StudentPhone" },
                values: new object[,]
                {
                    { 1, 1, "America", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jojn@gmail.com", "Male", "John", "123-456-789" },
                    { 2, 2, "Africa", new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dayal@gmail.com", "Female", "Megha", "122-456-789" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Students");
        }
    }
}
