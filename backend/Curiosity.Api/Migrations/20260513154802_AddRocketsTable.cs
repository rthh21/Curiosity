using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Curiosity.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRocketsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RocketName",
                table: "Launches");

            migrationBuilder.AddColumn<int>(
                name: "RocketId",
                table: "Launches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayloadCapacity = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rockets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2c5e174e-3b0e-446f-86af-483d56fd7210", "fbb9a360-c2dd-4e16-b2f1-934c8f708de0", "User", "USER" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "9954dc7c-df35-4c91-8f86-906af7fa0651", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5463f82b-1b4e-4e42-9e8a-e990c79f977c", 0, "74ebb7b8-97b7-4457-a552-8905da06c8fd", new DateTime(2026, 5, 13, 15, 48, 1, 672, DateTimeKind.Utc).AddTicks(8847), "admin@curiosity.com", true, "System", "Administrator", false, null, "ADMIN@CURIOSITY.COM", "ADMIN@CURIOSITY.COM", "AQAAAAIAAYagAAAAEHBXNtku5WJemgyt8O8GK2KOkuiejjU6goDSu+ZgIe1tzAkWy8RoMpj6yJZlu07lUA==", null, false, "", false, "admin@curiosity.com" });

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 1,
                column: "RocketId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 2,
                column: "RocketId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 3,
                column: "RocketId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 4,
                column: "RocketId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 5,
                column: "RocketId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 6,
                column: "RocketId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 7,
                column: "RocketId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 8,
                column: "RocketId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 9,
                column: "RocketId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 10,
                column: "RocketId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 11,
                column: "RocketId",
                value: 8);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 12,
                column: "RocketId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 13,
                column: "RocketId",
                value: 1);

            migrationBuilder.InsertData(
                table: "Rockets",
                columns: new[] { "Id", "Description", "ImageUrl", "Manufacturer", "Name", "PayloadCapacity" },
                values: new object[,]
                {
                    { 1, "Reusable two-stage rocket.", null, "SpaceX", "Falcon 9", 22800.0 },
                    { 2, "Most powerful operational rocket.", null, "SpaceX", "Falcon Heavy", 63800.0 },
                    { 3, "Space Launch System for Artemis.", null, "Boeing/NASA", "SLS Block 1", 95000.0 },
                    { 4, "European heavy-lift launch vehicle.", null, "ArianeGroup", "Ariane 6", 21600.0 },
                    { 5, "Fully reusable transport system.", null, "SpaceX", "Starship", 100000.0 },
                    { 6, null, null, "ArianeGroup", "Ariane 5", 21000.0 },
                    { 7, null, null, "CALT", "Long March 5", 25000.0 },
                    { 8, null, null, "Boeing/North American/Douglas", "Saturn V", 140000.0 },
                    { 9, null, null, "Martin Marietta", "Titan IIIE", 15400.0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "5463f82b-1b4e-4e42-9e8a-e990c79f977c" });

            migrationBuilder.CreateIndex(
                name: "IX_Launches_RocketId",
                table: "Launches",
                column: "RocketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Launches_Rockets_RocketId",
                table: "Launches",
                column: "RocketId",
                principalTable: "Rockets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Launches_Rockets_RocketId",
                table: "Launches");

            migrationBuilder.DropTable(
                name: "Rockets");

            migrationBuilder.DropIndex(
                name: "IX_Launches_RocketId",
                table: "Launches");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "5463f82b-1b4e-4e42-9e8a-e990c79f977c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5463f82b-1b4e-4e42-9e8a-e990c79f977c");

            migrationBuilder.DropColumn(
                name: "RocketId",
                table: "Launches");

            migrationBuilder.AddColumn<string>(
                name: "RocketName",
                table: "Launches",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 1,
                column: "RocketName",
                value: "Ariane 5 Post-Flight Support");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 2,
                column: "RocketName",
                value: "Falcon Heavy - Clipper");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 3,
                column: "RocketName",
                value: "Ariane 6 - JUICE Extended");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 4,
                column: "RocketName",
                value: "Long March 5 Y8 - Lunar Support");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 5,
                column: "RocketName",
                value: "SLS Block 1 - Artemis 2");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 6,
                column: "RocketName",
                value: "Starship HLS & SLS");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 7,
                column: "RocketName",
                value: "Falcon Heavy - Gateway");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 8,
                column: "RocketName",
                value: "SLS Block 1B - MSR");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 9,
                column: "RocketName",
                value: "Heavy Lift Vehicle TBA");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 10,
                column: "RocketName",
                value: "Ariane 64");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 11,
                column: "RocketName",
                value: "Saturn V");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 12,
                column: "RocketName",
                value: "Titan IIIE");

            migrationBuilder.UpdateData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 13,
                column: "RocketName",
                value: "Falcon 9 v1.0");
        }
    }
}
