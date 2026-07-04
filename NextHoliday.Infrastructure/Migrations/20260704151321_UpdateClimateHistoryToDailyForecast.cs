using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextHoliday.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClimateHistoryToDailyForecast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Month",
                table: "ClimateHistories",
                newName: "WeatherCode");

            migrationBuilder.RenameColumn(
                name: "AverageTemperature",
                table: "ClimateHistories",
                newName: "MinTemperature");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "ClimateHistories",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<double>(
                name: "MaxTemperature",
                table: "ClimateHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "ClimateHistories");

            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "ClimateHistories");

            migrationBuilder.RenameColumn(
                name: "WeatherCode",
                table: "ClimateHistories",
                newName: "Month");

            migrationBuilder.RenameColumn(
                name: "MinTemperature",
                table: "ClimateHistories",
                newName: "AverageTemperature");
        }
    }
}
