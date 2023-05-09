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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HouseCategories",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseCategories", x => new { x.HouseId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_HouseCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
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
                name: "HouseDistricts",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseDistricts", x => new { x.HouseId, x.DistrictId });
                    table.ForeignKey(
                        name: "FK_HouseDistricts_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseDistricts_Houses_HouseId",
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
                name: "HouseTowns",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseTowns", x => new { x.HouseId, x.TownId });
                    table.ForeignKey(
                        name: "FK_HouseTowns_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HouseTowns_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HouseCategories_CategoryId",
                table: "HouseCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseDistricts_DistrictId",
                table: "HouseDistricts",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_AppUserId",
                table: "Houses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseTowns_TownId",
                table: "HouseTowns",
                column: "TownId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_HouseId",
                table: "Photos",
                column: "HouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HouseCategories");

            migrationBuilder.DropTable(
                name: "HouseDistricts");

            migrationBuilder.DropTable(
                name: "HouseTowns");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Towns");

            migrationBuilder.DropTable(
                name: "Houses");
        }
    }
}
