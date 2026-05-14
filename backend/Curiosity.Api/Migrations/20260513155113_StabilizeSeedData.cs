using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Curiosity.Api.Migrations
{
    /// <inheritdoc />
    public partial class StabilizeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "b2c3d4e5-f6a7-4b6c-8d9e-0f1a2b3c4d5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "a1b2c3d4-e5f6-4a5b-9c8d-7e6f5a4b3c2d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5463f82b-1b4e-4e42-9e8a-e990c79f977c",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "c3d4e5f6-a7b8-4c7d-9e0f-1a2b3c4d5e6f", new DateTime(2026, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "d4e5f6a7-b8c9-4d8e-0f1a-2b3c4d5e6f7a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210",
                column: "ConcurrencyStamp",
                value: "fbb9a360-c2dd-4e16-b2f1-934c8f708de0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "9954dc7c-df35-4c91-8f86-906af7fa0651");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5463f82b-1b4e-4e42-9e8a-e990c79f977c",
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "SecurityStamp" },
                values: new object[] { "74ebb7b8-97b7-4457-a552-8905da06c8fd", new DateTime(2026, 5, 13, 15, 48, 1, 672, DateTimeKind.Utc).AddTicks(8847), "" });
        }
    }
}
