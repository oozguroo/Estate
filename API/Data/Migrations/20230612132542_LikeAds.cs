using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class LikeAds : Migration
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
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
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
                    Bathroom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Balcony = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Room = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Heath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComplexName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Furnish = table.Column<bool>(type: "bit", nullable: true),
                    Dues = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Exchange = table.Column<bool>(type: "bit", nullable: true),
                    Credit = table.Column<bool>(type: "bit", nullable: true),
                    Gross = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Square = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TownId = table.Column<int>(type: "int", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_Houses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Houses_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HouseLikes",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseLikes", x => new { x.AppUserId, x.HouseId });
                    table.ForeignKey(
                        name: "FK_HouseLikes_Houses_HouseId",
                        column: x => x.HouseId,
                        principalTable: "Houses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HouseLikes_Users_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
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

            migrationBuilder.CreateIndex(
                name: "IX_HouseLikes_HouseId",
                table: "HouseLikes",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_AppUserId",
                table: "Houses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_CategoryId",
                table: "Houses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_DistrictId",
                table: "Houses",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_TownId",
                table: "Houses",
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
                name: "HouseLikes");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
