using Microsoft.EntityFrameworkCore.Migrations;

namespace Beyond_LINQ_Using_Expression_Trees_in_.NET.React.Data.Migrations
{
    public partial class AddSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    IsForSale = table.Column<bool>(nullable: false),
                    InStock = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Rating" },
                values: new object[] { 1, "Laptops", 30 });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Rating" },
                values: new object[] { 2, "SmartPhones", 60 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InStock", "IsForSale", "Name", "Price" },
                values: new object[] { 1, 1, 0, false, "Apple MacBook Air 13 Mid 2017", 1000.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InStock", "IsForSale", "Name", "Price" },
                values: new object[] { 2, 1, 0, false, "Apple MacBook Pro 16 Late 2019", 2500.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InStock", "IsForSale", "Name", "Price" },
                values: new object[] { 3, 1, 0, false, "Xiaomi RedmiBook 14", 580.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InStock", "IsForSale", "Name", "Price" },
                values: new object[] { 4, 1, 0, false, "Lenovo Ideapad L340-17", 430.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InStock", "IsForSale", "Name", "Price" },
                values: new object[] { 5, 2, 0, false, "iPhone Xr 64GB", 650.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InStock", "IsForSale", "Name", "Price" },
                values: new object[] { 6, 2, 0, false, "iPhone 11 128GB", 870.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InStock", "IsForSale", "Name", "Price" },
                values: new object[] { 7, 2, 0, false, "Redmi Note 8T", 160.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "InStock", "IsForSale", "Name", "Price" },
                values: new object[] { 8, 2, 0, false, "Redmi Note 9 Pro", 300.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
