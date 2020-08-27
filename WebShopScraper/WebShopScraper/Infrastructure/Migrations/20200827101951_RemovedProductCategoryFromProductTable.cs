using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopScraper.Migrations
{
    public partial class RemovedProductCategoryFromProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductCategory",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductCategory",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
