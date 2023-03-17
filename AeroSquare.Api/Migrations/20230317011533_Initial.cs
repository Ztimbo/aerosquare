using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AeroSquare.Api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airplane",
                columns: table => new
                {
                    AirplaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Capacity = table.Column<short>(type: "smallint", maxLength: 32767, nullable: false),
                    FlightCrew = table.Column<short>(type: "smallint", maxLength: 32767, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplane", x => x.AirplaneId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
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
                name: "Destination",
                columns: table => new
                {
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Destination", x => x.DestinationId);
                    table.ForeignKey(
                        name: "FK_Destination_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "Origin",
                columns: table => new
                {
                    OriginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origin", x => x.OriginId);
                    table.ForeignKey(
                        name: "FK_Origin_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginId = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AirplaneId = table.Column<int>(type: "int", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightId);
                    table.ForeignKey(
                        name: "FK_Flight_Airplane_AirplaneId",
                        column: x => x.AirplaneId,
                        principalTable: "Airplane",
                        principalColumn: "AirplaneId");
                    table.ForeignKey(
                        name: "FK_Flight_Destination_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destination",
                        principalColumn: "DestinationId");
                    table.ForeignKey(
                        name: "FK_Flight_Origin_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origin",
                        principalColumn: "OriginId");
                });

            migrationBuilder.CreateTable(
                name: "FlightFlightDays",
                columns: table => new
                {
                    FlightDaysFlightDayId = table.Column<int>(type: "int", nullable: false),
                    FlightsFlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightFlightDays", x => new { x.FlightDaysFlightDayId, x.FlightsFlightId });
                    table.ForeignKey(
                        name: "FK_FlightFlightDays_FlightDays_FlightDaysFlightDayId",
                        column: x => x.FlightDaysFlightDayId,
                        principalTable: "FlightDays",
                        principalColumn: "FlightDayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FlightFlightDays_Flight_FlightsFlightId",
                        column: x => x.FlightsFlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Airplane",
                columns: new[] { "AirplaneId", "Capacity", "FlightCrew", "Name" },
                values: new object[,]
                {
                    { 1, (short)126, (short)6, "Embraer 317" },
                    { 2, (short)180, (short)8, "Airbus 320" },
                    { 3, (short)186, (short)10, "Boeing 767" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "Portland" },
                    { 2, "Las Vegas" },
                    { 3, "Chicago" },
                    { 4, "Boise" },
                    { 5, "Dallas" }
                });

            migrationBuilder.InsertData(
                table: "FlightDays",
                columns: new[] { "FlightDayId", "Name" },
                values: new object[,]
                {
                    { 1, "Monday" },
                    { 2, "Tuesday" },
                    { 3, "Wednesday" },
                    { 4, "Thursday" },
                    { 5, "Friday" },
                    { 6, "Saturday" },
                    { 7, "Sunday" }
                });

            migrationBuilder.InsertData(
                table: "Destination",
                columns: new[] { "DestinationId", "CityId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 5 }
                });

            migrationBuilder.InsertData(
                table: "Origin",
                columns: new[] { "OriginId", "CityId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 3 },
                    { 3, 5 },
                    { 4, 2 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "FlightId", "AirplaneId", "ArrivalTime", "DepartureTime", "DestinationId", "FlightNumber", "ListPrice", "OriginId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1900, 1, 1, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 6, 15, 0, 0, DateTimeKind.Unspecified), 1, "AES 108", 1037.28, 1 },
                    { 2, 2, new DateTime(1900, 1, 1, 14, 16, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 10, 23, 0, 0, DateTimeKind.Unspecified), 3, "AES 210", 1500.1700000000001, 2 },
                    { 3, 3, new DateTime(1900, 1, 1, 21, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 20, 16, 0, 0, DateTimeKind.Unspecified), 1, "AES 325", 927.0, 3 },
                    { 4, 2, new DateTime(1900, 1, 1, 11, 34, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 7, 25, 0, 0, DateTimeKind.Unspecified), 3, "AES 218", 1215.25, 3 },
                    { 5, 3, new DateTime(1900, 1, 1, 4, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 23, 38, 0, 0, DateTimeKind.Unspecified), 2, "AES 927", 2100.0, 4 },
                    { 6, 1, new DateTime(1900, 1, 1, 6, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 4, 20, 0, 0, DateTimeKind.Unspecified), 1, "AES 639", 1450.3599999999999, 5 },
                    { 7, 1, new DateTime(1900, 1, 1, 12, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 9, 23, 0, 0, DateTimeKind.Unspecified), 1, "AES 709", 897.12, 2 },
                    { 8, 3, new DateTime(1900, 1, 1, 13, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 10, 16, 0, 0, DateTimeKind.Unspecified), 4, "AES 354", 1654.8699999999999, 2 },
                    { 9, 2, new DateTime(1900, 1, 1, 11, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 6, 59, 0, 0, DateTimeKind.Unspecified), 4, "AES 500", 1024.3499999999999, 1 },
                    { 10, 2, new DateTime(1900, 1, 1, 0, 59, 0, 0, DateTimeKind.Unspecified), new DateTime(1900, 1, 1, 22, 4, 0, 0, DateTimeKind.Unspecified), 2, "AES 724", 1024.3499999999999, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Destination_CityId",
                table: "Destination",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirplaneId",
                table: "Flight",
                column: "AirplaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationId",
                table: "Flight",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_OriginId",
                table: "Flight",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightFlightDays_FlightsFlightId",
                table: "FlightFlightDays",
                column: "FlightsFlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Origin_CityId",
                table: "Origin",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlightFlightDays");

            migrationBuilder.DropTable(
                name: "FlightDays");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Airplane");

            migrationBuilder.DropTable(
                name: "Destination");

            migrationBuilder.DropTable(
                name: "Origin");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
