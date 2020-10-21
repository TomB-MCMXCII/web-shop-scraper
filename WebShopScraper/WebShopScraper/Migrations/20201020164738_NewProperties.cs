using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebShopScraper.Migrations
{
    public partial class NewProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HighLowPriceDiff",
                table: "ElectricScooters",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "HighPriceDate",
                table: "ElectricScooters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LowPriceDate",
                table: "ElectricScooters",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "HighLowPriceDiff",
                table: "Cpus",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "HighPriceDate",
                table: "Cpus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LowPriceDate",
                table: "Cpus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HighLowPriceDiff",
                table: "ElectricScooters");

            migrationBuilder.DropColumn(
                name: "HighPriceDate",
                table: "ElectricScooters");

            migrationBuilder.DropColumn(
                name: "LowPriceDate",
                table: "ElectricScooters");

            migrationBuilder.DropColumn(
                name: "HighLowPriceDiff",
                table: "Cpus");

            migrationBuilder.DropColumn(
                name: "HighPriceDate",
                table: "Cpus");

            migrationBuilder.DropColumn(
                name: "LowPriceDate",
                table: "Cpus");
        }
    }
}
