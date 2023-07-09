using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class PostgresInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Age = table.Column<short>(type: "smallint", nullable: false),
                    Floor = table.Column<string>(type: "text", nullable: true),
                    Bathroom = table.Column<string>(type: "text", nullable: true),
                    Balcony = table.Column<string>(type: "text", nullable: true),
                    Room = table.Column<string>(type: "text", nullable: true),
                    Heath = table.Column<string>(type: "text", nullable: true),
                    ComplexName = table.Column<string>(type: "text", nullable: true),
                    Deed = table.Column<string>(type: "text", nullable: true),
                    Furnish = table.Column<bool>(type: "boolean", nullable: true),
                    Dues = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Exchange = table.Column<bool>(type: "boolean", nullable: true),
                    Credit = table.Column<bool>(type: "boolean", nullable: true),
                    Gross = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    Square = table.Column<decimal>(type: "numeric(18,2)", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    TownId = table.Column<int>(type: "integer", nullable: false),
                    DistrictId = table.Column<int>(type: "integer", nullable: false),
                    HasNorthFrontage = table.Column<bool>(type: "boolean", nullable: true),
                    HasSouthFrontage = table.Column<bool>(type: "boolean", nullable: true),
                    HasEastFrontage = table.Column<bool>(type: "boolean", nullable: true),
                    HasWestFrontage = table.Column<bool>(type: "boolean", nullable: true),
                    Nature = table.Column<bool>(type: "boolean", nullable: true),
                    Sea = table.Column<bool>(type: "boolean", nullable: true),
                    Lake = table.Column<bool>(type: "boolean", nullable: true),
                    HasWifi = table.Column<bool>(type: "boolean", nullable: true),
                    HasSteelDoors = table.Column<bool>(type: "boolean", nullable: true),
                    HasElevator = table.Column<bool>(type: "boolean", nullable: true),
                    HasChimney = table.Column<bool>(type: "boolean", nullable: true),
                    SwimmingPool = table.Column<bool>(type: "boolean", nullable: true),
                    Generator = table.Column<bool>(type: "boolean", nullable: true),
                    Parking = table.Column<bool>(type: "boolean", nullable: true),
                    Satellite = table.Column<bool>(type: "boolean", nullable: true),
                    Metro = table.Column<bool>(type: "boolean", nullable: true),
                    Tramvay = table.Column<bool>(type: "boolean", nullable: true),
                    Van = table.Column<bool>(type: "boolean", nullable: true),
                    BusStop = table.Column<bool>(type: "boolean", nullable: true),
                    Hospital = table.Column<bool>(type: "boolean", nullable: true),
                    Gym = table.Column<bool>(type: "boolean", nullable: true),
                    Pharmacy = table.Column<bool>(type: "boolean", nullable: true),
                    ShoppingCenter = table.Column<bool>(type: "boolean", nullable: true)
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
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    SenderUsername = table.Column<string>(type: "text", nullable: true),
                    RecipientId = table.Column<int>(type: "integer", nullable: false),
                    RecipientUsername = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    DateRead = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MessageSent = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SenderDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    RecipientDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Messages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseLikes",
                columns: table => new
                {
                    AppUserId = table.Column<int>(type: "integer", nullable: false),
                    HouseId = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: true),
                    IsMain = table.Column<bool>(type: "boolean", nullable: false),
                    PublicId = table.Column<string>(type: "text", nullable: true),
                    HouseId = table.Column<int>(type: "integer", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sell" },
                    { 2, "Rent" }
                });

            migrationBuilder.InsertData(
                table: "Districts",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Green Street" },
                    { 2, "St George" }
                });

            migrationBuilder.InsertData(
                table: "Towns",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New Mexico" },
                    { 2, "Paris" }
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
                name: "IX_Messages_RecipientId",
                table: "Messages",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SenderId",
                table: "Messages",
                column: "SenderId");

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
                name: "Messages");

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

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
