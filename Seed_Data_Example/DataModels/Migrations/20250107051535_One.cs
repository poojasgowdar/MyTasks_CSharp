using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataModels.Migrations
{
    /// <inheritdoc />
    public partial class One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Mobile", 50.0m },
                    { 2, "Charger", 60.0m },
                    { 3, "Battery", 20.0m },
                    { 4, "Ear Phones", 10.0m },
                    { 5, "Watches", 70.0m },
                    { 6, "Bottle", 70.0m },
                    { 7, "Box", 20.0m },
                    { 8, "Notepad", 10.0m },
                    { 9, "Bag", 70.0m },
                    { 10, "Head Phones", 70.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
