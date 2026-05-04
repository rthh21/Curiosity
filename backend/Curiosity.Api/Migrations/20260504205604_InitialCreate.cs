using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Curiosity.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayloadDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsArticleBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    LaunchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RocketName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlightStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LiveStreamUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaunchLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                columns: new[] { "Id", "Country", "Description", "LogoUrl", "Name" },
                values: new object[,]
                {
                    { 1, "USA", "National Aeronautics and Space Administration.", "https://upload.wikimedia.org/wikipedia/commons/e/e5/NASA_logo.svg", "NASA" },
                    { 2, "USA", "Space Exploration Technologies Corp.", "https://upload.wikimedia.org/wikipedia/commons/d/de/SpaceX-Logo.svg", "SpaceX" },
                    { 3, "Europe", "European Space Agency.", "https://upload.wikimedia.org/wikipedia/commons/6/6e/ESA_logo_simple.svg", "ESA" },
                    { 4, "China", "China National Space Administration.", "https://upload.wikimedia.org/wikipedia/commons/b/b2/Insignia_of_CNSA.svg", "CNSA" },
                    { 5, "India", "Indian Space Research Organisation.", "https://upload.wikimedia.org/wikipedia/commons/b/bd/Indian_Space_Research_Organisation_Logo.svg", "ISRO" }
                });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "Id", "AgencyId", "ImageUrl", "NewsArticleBody", "PayloadDescription", "Title" },
                values: new object[,]
                {
                    { 1, 1, "https://upload.wikimedia.org/wikipedia/commons/2/2a/JWST_spacecraft_model_3.png", "The James Webb Space Telescope (JWST) is a space telescope designed primarily to conduct infrared astronomy.", "Infrared astronomy mission to explore the early universe.", "James Webb Space Telescope" },
                    { 2, 1, "https://upload.wikimedia.org/wikipedia/commons/5/59/Europa_Clipper_spacecraft_model.png", "Europa Clipper will perform dozens of close flybys of Jupiter's moon Europa.", "Studying the Galilean moon Europa to investigate its habitability.", "Europa Clipper" },
                    { 3, 3, "https://upload.wikimedia.org/wikipedia/commons/3/3d/Juice_launch_kit_cover_close-up.png", "JUICE will spend at least three years making detailed observations of Jupiter.", "Jupiter Icy Moons Explorer studying Ganymede, Callisto, and Europa.", "JUICE" },
                    { 4, 4, "https://upload.wikimedia.org/wikipedia/commons/c/cb/Chang%27e_6_lunar_samples_at_IAC_2024_01.jpg", "The mission aims to collect samples from the South Pole-Aitken basin.", "Lunar sample return mission from the far side of the Moon.", "Chang'e 6" },
                    { 5, 1, "https://upload.wikimedia.org/wikipedia/commons/1/15/Earthset_%28art002e009288%29.jpg", "Artemis II is the first planned crewed mission of NASA's Artemis program.", "First crewed mission of the Artemis program to orbit the Moon.", "Artemis II" },
                    { 6, 1, "https://upload.wikimedia.org/wikipedia/commons/1/19/Artemis_III_ESM3_Engine_Nozzle_Install_Completion_%28KSC-20260217-PH-JBS01_0002%29.jpg", "Artemis III will be the first human mission to the lunar South Pole.", "Human return to the lunar surface.", "Artemis III" },
                    { 7, 1, "https://upload.wikimedia.org/wikipedia/commons/3/3c/Lunar_Gateway_rendering_2.webp", "Gateway will serve as a multi-purpose outpost orbiting the Moon.", "A lunar space station.", "Lunar Gateway" },
                    { 8, 1, "https://upload.wikimedia.org/wikipedia/commons/0/07/Mars_sample_returnjpl.jpg", "MSR will collect and return Martian samples for the first time.", "Bringing Mars rocks to Earth.", "Mars Sample Return" },
                    { 9, 1, "https://upload.wikimedia.org/wikipedia/commons/f/f7/Dragonfly_render_June_2025.png", "Dragonfly will explore the chemistry of Saturn's moon Titan.", "Rotorcraft to explore Titan.", "Dragonfly" },
                    { 10, 3, "https://upload.wikimedia.org/wikipedia/commons/f/f5/LISA-waves.jpg", "LISA will detect gravitational waves from space.", "Gravitational wave observatory.", "LISA" }
                });

            migrationBuilder.InsertData(
                table: "Launches",
                columns: new[] { "Id", "FlightStatus", "IsFeatured", "LaunchDate", "LaunchLocation", "LiveStreamUrl", "MissionId", "RocketName" },
                values: new object[,]
                {
                    { 1, "Scheduled", false, new DateTime(2026, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kourou, French Guiana", null, 1, "Ariane 5 Post-Flight Support" },
                    { 2, "Scheduled", true, new DateTime(2026, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kennedy Space Center, FL", null, 2, "Falcon Heavy - Clipper" },
                    { 3, "Scheduled", false, new DateTime(2027, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kourou, French Guiana", null, 3, "Ariane 6 - JUICE Extended" },
                    { 4, "Scheduled", false, new DateTime(2027, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wenchang, China", null, 4, "Long March 5 Y8 - Lunar Support" },
                    { 5, "Scheduled", false, new DateTime(2026, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kennedy Space Center, FL", null, 5, "SLS Block 1 - Artemis 2" },
                    { 6, "Scheduled", false, new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kennedy Space Center / Starbase", null, 6, "Starship HLS & SLS" },
                    { 7, "Scheduled", false, new DateTime(2027, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kennedy Space Center, FL", null, 7, "Falcon Heavy - Gateway" },
                    { 8, "Scheduled", false, new DateTime(2028, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kennedy Space Center, FL", null, 8, "SLS Block 1B - MSR" },
                    { 9, "Scheduled", false, new DateTime(2028, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TBA", null, 9, "Heavy Lift Vehicle TBA" },
                    { 10, "Scheduled", false, new DateTime(2035, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kourou, French Guiana", null, 10, "Ariane 64" }
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
