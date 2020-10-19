﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShopScraper;

namespace WebShopScraper.Migrations
{
    [DbContext(typeof(WebShopScraperDbContext))]
    partial class WebShopScraperDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebShopScraper.Cpu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AvgPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HighPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LowPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Shop")
                        .HasColumnType("int");

                    b.Property<int>("TimesAdded")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cpus");
                });

            modelBuilder.Entity("WebShopScraper.ElectricScooter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("AvgPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HighPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("LowPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Shop")
                        .HasColumnType("int");

                    b.Property<int>("TimesAdded")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ElectricScooters");
                });
#pragma warning restore 612, 618
        }
    }
}
