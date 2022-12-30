using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVillaVillaAPI.Migrations
{
    /// <inheritdoc />
    public partial class addforeignkeytovillatable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VillaId",
                table: "VillaNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 13, 23, 54, 712, DateTimeKind.Local).AddTicks(6123), new DateTime(2022, 12, 30, 13, 23, 54, 712, DateTimeKind.Local).AddTicks(6160) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 13, 23, 54, 712, DateTimeKind.Local).AddTicks(6163), new DateTime(2022, 12, 30, 13, 23, 54, 712, DateTimeKind.Local).AddTicks(6164) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 30, 13, 23, 54, 712, DateTimeKind.Local).AddTicks(6166), new DateTime(2022, 12, 30, 13, 23, 54, 712, DateTimeKind.Local).AddTicks(6167) });

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VillaId",
                table: "VillaNumbers",
                column: "VillaId",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers");

            migrationBuilder.DropColumn(
                name: "VillaId",
                table: "VillaNumbers");

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
    }
}
