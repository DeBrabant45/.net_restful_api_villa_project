using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVillaVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedvillatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Testing amenity here!", new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1771), "Testing Details here for you!", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa3.jpg", "Test Valla 1", 5, 200.0, 1200, new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1812) },
                    { 2, "Testing amenity here!", new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1815), "Testing Details here for you!", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa4.jpg", "Test Valla 2", 3, 150.0, 1000, new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1816) },
                    { 3, "Testing amenity here!", new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1818), "Testing Details here for you!", "https://dotnetmasteryimages.blob.core.windows.net/bluevillaimages/villa5.jpg", "Test Valla 3", 6, 250.0, 1500, new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1819) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
