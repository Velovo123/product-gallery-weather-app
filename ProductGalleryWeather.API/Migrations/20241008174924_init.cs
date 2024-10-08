using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductGalleryWeather.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GalleryImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SrcUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryImages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "John Doe", "/products/images/astro-fiction.png", 19.99m, "Astro Fiction" },
                    { 2, "Mary Poppins", "/products/images/black-dog.png", 20m, "Black Dog" },
                    { 3, "J.D. Salinger", "/products/images/doomed-city.png", 16.99m, "Doomed City" },
                    { 4, "F. Scott Fitzgerald", "/products/images/garden-girl.png", 14.99m, "Garden Girl" },
                    { 5, "Jane Austen", "/products/images/my-little-robot.png", 13.99m, "My little Robot" },
                    { 6, "Harper Lee", "/products/images/space-odissey.png", 11.99m, "SpaceOdissey" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GalleryImages");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
