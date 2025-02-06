using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace User_Endpoint_API.Migrations
{
    /// <inheritdoc />
    public partial class seedAdmin1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Admins",
                newName: "PasswordHash");

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "PasswordHash", "Role", "UserName" },
                values: new object[] { 1, "Admin@123", "Admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Admins",
                newName: "Password");
        }
    }
}
