using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopScraper.Migrations
{
    public partial class refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AvgPrice = table.Column<decimal>(nullable: false),
                    HighPrice = table.Column<decimal>(nullable: false),
                    LowPrice = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Shop = table.Column<int>(nullable: false),
                    TotalSum = table.Column<decimal>(nullable: false),
                    TimesAdded = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    HighLowPriceDiff = table.Column<decimal>(nullable: false),
                    HighPriceDate = table.Column<DateTime>(nullable: false),
                    LowPriceDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
