using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Curiosity.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Agencies_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "Agencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Launches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveStreamUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false),
                    MissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Launches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Launches_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFavoriteMissions",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MissionId = table.Column<int>(type: "int", nullable: false),
                    SavedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteMissions", x => new { x.UserId, x.MissionId });
                    table.ForeignKey(
                        name: "FK_UserFavoriteMissions_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteMissions_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agencies",
                columns: new[] { "Id", "Country", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "USA", "National Aeronautics and Space Administration.", "https://upload.wikimedia.org/wikipedia/commons/e/e5/NASA_logo.svg", "NASA" },
                    { 2, "USA", "Space Exploration Technologies Corp.", "https://upload.wikimedia.org/wikipedia/commons/d/de/SpaceX-Logo.svg", "SpaceX" },
                    { 3, "Europe", "European Space Agency.", "https://upload.wikimedia.org/wikipedia/commons/b/bb/European_Space_Agency_logo.svg", "ESA" },
                    { 4, "China", "China National Space Administration.", "https://upload.wikimedia.org/wikipedia/commons/9/98/China_National_Space_Administration_logo.svg", "CNSA" },
                    { 5, "India", "Indian Space Research Organisation.", "https://upload.wikimedia.org/wikipedia/commons/b/bd/Indian_Space_Research_Organisation_Logo.svg", "ISRO" },
                    { 6, "Japan", "Japan Aerospace Exploration Agency.", "https://upload.wikimedia.org/wikipedia/commons/8/85/JAXA_logo.svg", "JAXA" },
                    { 7, "Russia", "State Space Corporation Roscosmos.", "https://upload.wikimedia.org/wikipedia/commons/a/a2/Roscosmos_logo_en.svg", "Roscosmos" },
                    { 8, "USA/NZ", "Aerospace manufacturer and launch service provider.", "https://upload.wikimedia.org/wikipedia/commons/8/87/Rocket_Lab_logo.svg", "Rocket Lab" },
                    { 9, "USA", "American privately funded aerospace manufacturer.", "https://upload.wikimedia.org/wikipedia/commons/7/7b/Blue_Origin_Logo.svg", "Blue Origin" },
                    { 10, "USA", "United Launch Alliance.", "https://upload.wikimedia.org/wikipedia/commons/8/8c/United_Launch_Alliance_logo.svg", "ULA" }
                });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "AgencyId", "Description", "ImageUrl", "Name", "StartDate", "Target" },
                values: new object[,]
                {
                    { 1, 1, "Infrared astronomy.", "https://upload.wikimedia.org/wikipedia/commons/c/c5/James_Webb_Space_Telescope_2022_rendering.png", "James Webb Space Telescope", new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "L2 Point" },
                    { 2, 1, "Studying the Galilean moon Europa.", "https://upload.wikimedia.org/wikipedia/commons/0/05/Europa_Clipper_spacecraft_model.png", "Europa Clipper", new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jupiter/Europa" },
                    { 3, 3, "Jupiter Icy Moons Explorer.", "https://upload.wikimedia.org/wikipedia/commons/9/9d/JUICE_spacecraft_model.jpg", "JUICE", new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jupiter" },
                    { 4, 4, "Lunar sample return mission.", "https://upload.wikimedia.org/wikipedia/commons/2/22/Change_6_lunar_probe.jpg", "Chang'e 6", new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moon (Far Side)" },
                    { 5, 1, "First crewed mission of the Artemis program.", "https://upload.wikimedia.org/wikipedia/commons/c/cb/Artemis_II_mission_patch.png", "Artemis II", new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Moon Orbit" },
                    { 6, 1, "Crewed lunar landing.", "https://upload.wikimedia.org/wikipedia/commons/4/4c/Artemis_III_mission_patch.png", "Artemis III", new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lunar South Pole" },
                    { 7, 1, "First elements of the lunar space station.", "https://upload.wikimedia.org/wikipedia/commons/6/69/Gateway_in_lunar_orbit_%28artist%27s_concept%29.jpg", "Lunar Gateway - PPE & HALO", new DateTime(2027, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lunar Orbit" },
                    { 8, 1, "Returning samples collected by Perseverance.", "https://upload.wikimedia.org/wikipedia/commons/e/e0/Mars_Sample_Return_mission_concept.png", "Mars Sample Return", new DateTime(2028, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mars" },
                    { 9, 1, "Rotorcraft lander to explore Saturn's moon Titan.", "https://upload.wikimedia.org/wikipedia/commons/8/87/Dragonfly_on_Titan_%28artist%27s_concept%29.jpg", "Dragonfly", new DateTime(2028, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Titan" },
                    { 10, 3, "Laser Interferometer Space Antenna.", "https://upload.wikimedia.org/wikipedia/commons/5/52/LISA_artist_impression.jpg", "LISA", new DateTime(2035, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Solar Orbit" }
                });

            migrationBuilder.InsertData(
                table: "Launches",
                columns: new[] { "Id", "Date", "IsFeatured", "LiveStreamUrl", "Location", "MissionId", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kourou, French Guiana", 1, "Ariane 5 Flight VA256", "Success" },
                    { 2, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kennedy Space Center, FL", 2, "Falcon Heavy - Clipper", "Success" },
                    { 3, new DateTime(2023, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kourou, French Guiana", 3, "Ariane 5 Flight VA260", "Success" },
                    { 4, new DateTime(2024, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Wenchang, China", 4, "Long March 5 Y8", "Success" },
                    { 5, new DateTime(2025, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kennedy Space Center, FL", 5, "SLS Block 1 - Artemis 2", "Scheduled" },
                    { 6, new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kennedy Space Center / Starbase", 6, "Starship HLS & SLS", "Scheduled" },
                    { 7, new DateTime(2027, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kennedy Space Center, FL", 7, "Falcon Heavy - Gateway", "Scheduled" },
                    { 8, new DateTime(2028, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kennedy Space Center, FL", 8, "SLS Block 1B - MSR", "Scheduled" },
                    { 9, new DateTime(2028, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "TBA", 9, "Heavy Lift Vehicle TBA", "Scheduled" },
                    { 10, new DateTime(2035, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Kourou, French Guiana", 10, "Ariane 64", "Scheduled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Launches_MissionId",
                table: "Launches",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_AgencyId",
                table: "Missions",
                column: "AgencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteMissions_MissionId",
                table: "UserFavoriteMissions",
                column: "MissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Launches");

            migrationBuilder.DropTable(
                name: "UserFavoriteMissions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Agencies");
        }
    }
}
