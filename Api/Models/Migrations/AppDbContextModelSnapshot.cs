﻿// <auto-generated />
using System;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Models.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Api.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2021, 1, 3, 18, 8, 1, 137, DateTimeKind.Local).AddTicks(5544),
                            Description = "Lorem ipsum dolor sit amet.",
                            Name = "Automobile"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2020, 12, 4, 18, 8, 1, 140, DateTimeKind.Local).AddTicks(2225),
                            Description = "Lorem ipsum dolor sit amet.",
                            Name = "Suv"
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2020, 11, 4, 18, 8, 1, 140, DateTimeKind.Local).AddTicks(2449),
                            Description = "Lorem ipsum dolor sit amet.",
                            Name = "Truck"
                        });
                });

            modelBuilder.Entity("Api.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(2021, 1, 3, 18, 8, 1, 142, DateTimeKind.Local).AddTicks(7759),
                            Name = "Bmw"
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(2020, 12, 24, 18, 8, 1, 142, DateTimeKind.Local).AddTicks(8235),
                            Name = "Volvo"
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(2020, 12, 14, 18, 8, 1, 142, DateTimeKind.Local).AddTicks(8243),
                            Name = "Nissan"
                        },
                        new
                        {
                            Id = 4,
                            CreatedOn = new DateTime(2020, 12, 4, 18, 8, 1, 142, DateTimeKind.Local).AddTicks(8244),
                            Name = "Toyota"
                        },
                        new
                        {
                            Id = 5,
                            CreatedOn = new DateTime(2020, 11, 24, 18, 8, 1, 142, DateTimeKind.Local).AddTicks(8246),
                            Name = "Mazda"
                        });
                });

            modelBuilder.Entity("Api.Models.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BodyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("Doors")
                        .HasColumnType("int");

                    b.Property<int>("Engine")
                        .HasColumnType("int");

                    b.Property<string>("Generation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Vehicles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BodyType = "Sedan",
                            CategoryId = 1,
                            Color = "Red",
                            CreatedOn = new DateTime(2018, 1, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(3474),
                            Doors = 4,
                            Engine = 170,
                            Generation = "3 Series Sedan (E46, facelift 2001)",
                            ManufacturerId = 1,
                            Model = "3 Series",
                            Seats = 5,
                            Year = 2005
                        },
                        new
                        {
                            Id = 2,
                            BodyType = "Hatchback",
                            CategoryId = 1,
                            Color = "Black",
                            CreatedOn = new DateTime(2020, 12, 29, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4176),
                            Doors = 5,
                            Engine = 109,
                            Generation = "1 Series Hatchback (F40)",
                            ManufacturerId = 1,
                            Model = "1 Series",
                            Seats = 5,
                            Year = 2020
                        },
                        new
                        {
                            Id = 3,
                            BodyType = "SUV",
                            CategoryId = 2,
                            Color = "Black",
                            CreatedOn = new DateTime(2020, 10, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4183),
                            Doors = 5,
                            Engine = 408,
                            Generation = "XC90 II",
                            ManufacturerId = 2,
                            Model = "XC90",
                            Seats = 5,
                            Year = 2018
                        },
                        new
                        {
                            Id = 4,
                            BodyType = "Sedan",
                            CategoryId = 1,
                            Color = "Gray",
                            CreatedOn = new DateTime(2020, 11, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4192),
                            Doors = 4,
                            Engine = 150,
                            Generation = "S90 (facelift 2020)",
                            ManufacturerId = 2,
                            Model = "S90",
                            Seats = 5,
                            Year = 2020
                        },
                        new
                        {
                            Id = 5,
                            BodyType = "Truck",
                            CategoryId = 3,
                            Color = "White",
                            CreatedOn = new DateTime(2020, 12, 24, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4197),
                            Doors = 2,
                            Engine = 500,
                            Generation = "FH",
                            ManufacturerId = 2,
                            Model = "500",
                            Seats = 2,
                            Year = 2020
                        },
                        new
                        {
                            Id = 6,
                            BodyType = "Sedan",
                            CategoryId = 1,
                            Color = "Blue",
                            CreatedOn = new DateTime(2001, 1, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4199),
                            Doors = 4,
                            Engine = 200,
                            Generation = "Skyline X (R34)",
                            ManufacturerId = 3,
                            Model = "Skyline",
                            Seats = 5,
                            Year = 2001
                        },
                        new
                        {
                            Id = 7,
                            BodyType = "Coupe",
                            CategoryId = 1,
                            Color = "Red",
                            CreatedOn = new DateTime(2020, 7, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4202),
                            Doors = 2,
                            Engine = 195,
                            Generation = "AE86",
                            ManufacturerId = 4,
                            Model = "AE86",
                            Seats = 5,
                            Year = 2005
                        },
                        new
                        {
                            Id = 8,
                            BodyType = "Coupe",
                            CategoryId = 1,
                            Color = "Red",
                            CreatedOn = new DateTime(2011, 1, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4204),
                            Doors = 2,
                            Engine = 250,
                            Generation = "RX-8",
                            ManufacturerId = 5,
                            Model = "RX-8",
                            Seats = 4,
                            Year = 2009
                        });
                });

            modelBuilder.Entity("Api.Models.Vehicle", b =>
                {
                    b.HasOne("Api.Models.Category", "Category")
                        .WithMany("Vehicles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Api.Models.Manufacturer", "Manufacturer")
                        .WithMany("Vehicles")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");
                });

            modelBuilder.Entity("Api.Models.Category", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Api.Models.Manufacturer", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}