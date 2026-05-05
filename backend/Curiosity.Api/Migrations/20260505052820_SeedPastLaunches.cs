using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Curiosity.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedPastLaunches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "AgencyId", "ImageUrl", "NewsArticleBody", "PayloadDescription", "Title" },
                values: new object[,]
                {
                    { 11, 1, "https://upload.wikimedia.org/wikipedia/commons/9/98/Apollo_11_Lunar_Module_Eagle_in_lunar_orbit_viewed_from_Command_Module_Columbia.jpg", "Apollo 11 was the first spaceflight that landed humans on the Moon.", "First crewed lunar landing.", "Apollo 11" },
                    { 12, 1, "https://upload.wikimedia.org/wikipedia/commons/d/d2/Voyager.jpg", "Voyager 1 is a space probe launched by NASA in 1977.", "Interstellar mission to the outer solar system.", "Voyager 1" },
                    { 13, 2, "https://upload.wikimedia.org/wikipedia/commons/2/2a/Falcon_9_launching_CRS-1.jpg", "CRS-1 was the first commercial resupply mission to the International Space Station.", "First commercial resupply mission to the ISS.", "SpaceX CRS-1" }
                });

            migrationBuilder.InsertData(
                table: "Launches",
                columns: new[] { "Id", "FlightStatus", "IsFeatured", "LaunchDate", "LaunchLocation", "LiveStreamUrl", "MissionId", "RocketName" },
                values: new object[,]
                {
                    { 11, "Success", false, new DateTime(1969, 7, 16, 13, 32, 0, 0, DateTimeKind.Unspecified), "Kennedy Space Center, FL", null, 11, "Saturn V" },
                    { 12, "Success", false, new DateTime(1977, 9, 5, 12, 56, 0, 0, DateTimeKind.Unspecified), "Cape Canaveral, FL", null, 12, "Titan IIIE" },
                    { 13, "Success", false, new DateTime(2012, 10, 8, 0, 35, 0, 0, DateTimeKind.Unspecified), "Cape Canaveral, FL", null, 13, "Falcon 9 v1.0" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Launches",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Missions",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
