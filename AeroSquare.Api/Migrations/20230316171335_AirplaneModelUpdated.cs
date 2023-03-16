using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeroSquare.Api.Migrations
{
    /// <inheritdoc />
    public partial class AirplaneModelUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Capacity",
                table: "Airplane",
                type: "smallint",
                maxLength: 32767,
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<short>(
                name: "FlightCrew",
                table: "Airplane",
                type: "smallint",
                maxLength: 32767,
                nullable: false,
                defaultValue: (short)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Airplane");

            migrationBuilder.DropColumn(
                name: "FlightCrew",
                table: "Airplane");
        }
    }
}
