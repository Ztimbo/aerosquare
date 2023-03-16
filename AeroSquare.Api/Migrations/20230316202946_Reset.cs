using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeroSquare.Api.Migrations
{
    /// <inheritdoc />
    public partial class Reset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "FlightDays",
                columns: table => new
                {
                    FlightDayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDays", x => x.FlightDayId);
                });

            migrationBuilder.CreateTable(
                name: "Airplane",
                columns: table => new
                {
                    AirplaneId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Capacity = table.Column<short>(type: "smallint", maxLength: 32767, nullable: false),
                    FlightCrew = table.Column<short>(type: "smallint", maxLength: 32767, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplane", x => x.AirplaneId);
                    table.ForeignKey(
                        name: "FK_Airplane_Flight_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Flight",
                        principalColumn: "FlightId");
                });

            migrationBuilder.CreateTable(
                name: "Destination",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.DestinationId);
                    table.ForeignKey(
                        name: "FK_Destination_Flight_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Flight",
                        principalColumn: "FlightId");
                });

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.OriginId);
                    table.ForeignKey(
                        name: "FK_Origin_Flight_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Flight",
                        principalColumn: "FlightId");
                });

            migrationBuilder.CreateTable(
                name: "Flight_FlightDays",
                columns: table => new
                {
                    FlightDayId = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight_FlightDays", x => new { x.FlightDayId, x.FlightId });
                    table.ForeignKey(
                        name: "FK_Flight_FlightDays_FlightDays_FlightDayId",
                        column: x => x.FlightDayId,
                        principalTable: "FlightDays",
                        principalColumn: "FlightDayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Flight_FlightDays_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Destination_CityId",
                        column: x => x.CityId,
                        principalTable: "Destination",
                        principalColumn: "DestinationId");
                    table.ForeignKey(
                        name: "FK_City_Origin_CityId",
                        column: x => x.CityId,
                        principalTable: "Origin",
                        principalColumn: "OriginId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_FlightDays_FlightId",
                table: "Flight_FlightDays",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Airplane");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Flight_FlightDays");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Origin");

            migrationBuilder.DropTable(
                name: "FlightDays");

            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}
