using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddingVillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    Number = table.Column<int>(type: "int", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.Number);
                });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 11, 48, 21, 166, DateTimeKind.Local).AddTicks(4490), new DateTime(2022, 12, 30, 11, 48, 21, 166, DateTimeKind.Local).AddTicks(4534) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 11, 48, 21, 166, DateTimeKind.Local).AddTicks(4537), new DateTime(2022, 12, 30, 11, 48, 21, 166, DateTimeKind.Local).AddTicks(4538) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 11, 48, 21, 166, DateTimeKind.Local).AddTicks(4539), new DateTime(2022, 12, 30, 11, 48, 21, 166, DateTimeKind.Local).AddTicks(4540) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1771), new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1812) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1815), new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1816) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1818), new DateTime(2022, 12, 28, 15, 24, 8, 794, DateTimeKind.Local).AddTicks(1819) });
        }
    }
}
