using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace APIwithEFCore.Migrations
{
    /// <inheritdoc />
    public partial class sec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "StudentCourse",
                columns: new[] { "CourseId", "StudentId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 0 },
                    { 3, 2, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "StudentCourse",
                keyColumns: new[] { "CourseId", "StudentId" },
                keyValues: new object[] { 3, 2 });
        }
    }
}
