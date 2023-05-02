using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedHouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Age = table.Column<short>(type: "smallint", nullable: false),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bathroom = table.Column<byte>(type: "tinyint", nullable: false),
                    Balcony = table.Column<byte>(type: "tinyint", nullable: false),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeathType = table.Column<int>(type: "int", nullable: false),
                    ComplexName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeedType = table.Column<int>(type: "int", nullable: false),
                    Furnish = table.Column<bool>(type: "bit", nullable: false),
                    Dues = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Exchange = table.Column<bool>(type: "bit", nullable: false),
                    Credit = table.Column<bool>(type: "bit", nullable: true),
                    Gross = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Square = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ramp = table.Column<bool>(type: "bit", nullable: true),
                    Elevator = table.Column<bool>(type: "bit", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HasNorthFrontage = table.Column<bool>(type: "bit", nullable: true),
                    HasSouthFrontage = table.Column<bool>(type: "bit", nullable: true),
                    HasEastFrontage = table.Column<bool>(type: "bit", nullable: true),
                    HasWestFrontage = table.Column<bool>(type: "bit", nullable: true),
                    Nature = table.Column<bool>(type: "bit", nullable: true),
                    Sea = table.Column<bool>(type: "bit", nullable: true),
                    Lake = table.Column<bool>(type: "bit", nullable: true),
                    HasWifi = table.Column<bool>(type: "bit", nullable: true),
                    HasSteelDoors = table.Column<bool>(type: "bit", nullable: true),
                    HasElevator = table.Column<bool>(type: "bit", nullable: true),
                    HasChimney = table.Column<bool>(type: "bit", nullable: true),
                    SwimmingPool = table.Column<bool>(type: "bit", nullable: true),
                    Generator = table.Column<bool>(type: "bit", nullable: true),
                    Parking = table.Column<bool>(type: "bit", nullable: true),
                    Satellite = table.Column<bool>(type: "bit", nullable: true),
                    Metro = table.Column<bool>(type: "bit", nullable: true),
                    Tramvay = table.Column<bool>(type: "bit", nullable: true),
                    Van = table.Column<bool>(type: "bit", nullable: true),
                    BusStop = table.Column<bool>(type: "bit", nullable: true),
                    Hospital = table.Column<bool>(type: "bit", nullable: true),
                    Gym = table.Column<bool>(type: "bit", nullable: true),
                    Pharmacy = table.Column<bool>(type: "bit", nullable: true),
                    ShoppingCenter = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Houses_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Towns_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseCategories",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    ChoosenCategoryId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseCategories", x => new { x.HouseId, x.ChoosenCategoryId });
                    table.ForeignKey(
                        name: "FK_HouseCategories_Categories_ChoosenCategoryId",
                        column: x => x.ChoosenCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseCategories_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    PublicId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TownId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Districts_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseLocations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    LocationCityId = table.Column<int>(type: "int", nullable: false),
                    LocationTownId = table.Column<int>(type: "int", nullable: false),
                    LocationDistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HouseLocations_Cities_LocationCityId",
                        column: x => x.LocationCityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseLocations_Districts_LocationDistrictId",
                        column: x => x.LocationDistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseLocations_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseLocations_Towns_LocationTownId",
                        column: x => x.LocationTownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Districts_TownId",
                table: "Districts",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseCategories_ChoosenCategoryId",
                table: "HouseCategories",
                column: "ChoosenCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseLocations_HouseId",
                table: "HouseLocations",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseLocations_LocationCityId",
                table: "HouseLocations",
                column: "LocationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseLocations_LocationDistrictId",
                table: "HouseLocations",
                column: "LocationDistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseLocations_LocationTownId",
                table: "HouseLocations",
                column: "LocationTownId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_AppUserId",
                table: "Houses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_HouseId",
                table: "Photos",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Towns_CityId",
                table: "Towns",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseCategories");

            migrationBuilder.DropTable(
                name: "HouseLocations");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
