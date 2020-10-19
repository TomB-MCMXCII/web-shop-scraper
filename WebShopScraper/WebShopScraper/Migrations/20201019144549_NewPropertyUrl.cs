using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopScraper.Migrations
{
    public partial class NewPropertyUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "ElectricScooters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Cpus",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "ElectricScooters");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Cpus");
        }
    }
}
