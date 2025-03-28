﻿// <auto-generated />
using DataModels.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataModels.Migrations
{
    [DbContext(typeof(AddDbContext))]
    [Migration("20250107051535_One")]
    partial class One
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataModels.Entities.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Mobile",
                            Price = 50.0m
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "Charger",
                            Price = 60.0m
                        },
                        new
                        {
                            ProductId = 3,
                            Name = "Battery",
                            Price = 20.0m
                        },
                        new
                        {
                            ProductId = 4,
                            Name = "Ear Phones",
                            Price = 10.0m
                        },
                        new
                        {
                            ProductId = 5,
                            Name = "Watches",
                            Price = 70.0m
                        },
                        new
                        {
                            ProductId = 6,
                            Name = "Bottle",
                            Price = 70.0m
                        },
                        new
                        {
                            ProductId = 7,
                            Name = "Box",
                            Price = 20.0m
                        },
                        new
                        {
                            ProductId = 8,
                            Name = "Notepad",
                            Price = 10.0m
                        },
                        new
                        {
                            ProductId = 9,
                            Name = "Bag",
                            Price = 70.0m
                        },
                        new
                        {
                            ProductId = 10,
                            Name = "Head Phones",
                            Price = 70.0m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
