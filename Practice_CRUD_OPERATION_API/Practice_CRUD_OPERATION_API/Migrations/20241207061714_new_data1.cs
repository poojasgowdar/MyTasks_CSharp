using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Practice_CRUD_OPERATION_API.Migrations
{
    /// <inheritdoc />
    public partial class new_data1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "Title" },
                values: new object[,]
                {
                    { 1, "Maths" },
                    { 2, "Science" },
                    { 3, "English" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "CourseId", "StudentAge", "StudentName" },
                values: new object[,]
                {
                    { 1, 1, 25, "John" },
                    { 2, 2, 26, "Thomas" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
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
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);
        }
    }
}
