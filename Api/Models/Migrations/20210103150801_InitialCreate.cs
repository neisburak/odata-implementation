using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Api.Models.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    Generation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Engine = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Doors = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vehicles_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedOn", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 3, 18, 8, 1, 137, DateTimeKind.Local).AddTicks(5544), "Lorem ipsum dolor sit amet.", "Automobile" },
                    { 2, new DateTime(2020, 12, 4, 18, 8, 1, 140, DateTimeKind.Local).AddTicks(2225), "Lorem ipsum dolor sit amet.", "Suv" },
                    { 3, new DateTime(2020, 11, 4, 18, 8, 1, 140, DateTimeKind.Local).AddTicks(2449), "Lorem ipsum dolor sit amet.", "Truck" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 3, 18, 8, 1, 142, DateTimeKind.Local).AddTicks(7759), "Bmw" },
                    { 2, new DateTime(2020, 12, 24, 18, 8, 1, 142, DateTimeKind.Local).AddTicks(8235), "Volvo" },
                    { 3, new DateTime(2020, 12, 14, 18, 8, 1, 142, DateTimeKind.Local).AddTicks(8243), "Nissan" },
                    { 4, new DateTime(2020, 12, 4, 18, 8, 1, 142, DateTimeKind.Local).AddTicks(8244), "Toyota" },
                    { 5, new DateTime(2020, 11, 24, 18, 8, 1, 142, DateTimeKind.Local).AddTicks(8246), "Mazda" }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "BodyType", "CategoryId", "Color", "CreatedOn", "Doors", "Engine", "Generation", "ManufacturerId", "Model", "Seats", "Year" },
                values: new object[,]
                {
                    { 1, "Sedan", 1, "Red", new DateTime(2018, 1, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(3474), 4, 170, "3 Series Sedan (E46, facelift 2001)", 1, "3 Series", 5, 2005 },
                    { 2, "Hatchback", 1, "Black", new DateTime(2020, 12, 29, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4176), 5, 109, "1 Series Hatchback (F40)", 1, "1 Series", 5, 2020 },
                    { 3, "SUV", 2, "Black", new DateTime(2020, 10, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4183), 5, 408, "XC90 II", 2, "XC90", 5, 2018 },
                    { 4, "Sedan", 1, "Gray", new DateTime(2020, 11, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4192), 4, 150, "S90 (facelift 2020)", 2, "S90", 5, 2020 },
                    { 5, "Truck", 3, "White", new DateTime(2020, 12, 24, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4197), 2, 500, "FH", 2, "500", 2, 2020 },
                    { 6, "Sedan", 1, "Blue", new DateTime(2001, 1, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4199), 4, 200, "Skyline X (R34)", 3, "Skyline", 5, 2001 },
                    { 7, "Coupe", 1, "Red", new DateTime(2020, 7, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4202), 2, 195, "AE86", 4, "AE86", 5, 2005 },
                    { 8, "Coupe", 1, "Red", new DateTime(2011, 1, 3, 18, 8, 1, 143, DateTimeKind.Local).AddTicks(4204), 2, 250, "RX-8", 5, "RX-8", 4, 2009 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CategoryId",
                table: "Vehicles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ManufacturerId",
                table: "Vehicles",
                column: "ManufacturerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
