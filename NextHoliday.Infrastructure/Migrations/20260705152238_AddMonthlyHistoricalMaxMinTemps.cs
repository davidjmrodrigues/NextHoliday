using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextHoliday.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMonthlyHistoricalMaxMinTemps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HistoricalMonthlyMaxTemps",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HistoricalMonthlyMinTemps",
                table: "Destinations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-6c7d-8e9f0a1b2c3d"),
                columns: new[] { "HistoricalMonthlyMaxTemps", "HistoricalMonthlyMinTemps" },
                values: new object[] { "[0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0]" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b5c-6d7e-8f9a0b1c2d3e"),
                columns: new[] { "HistoricalMonthlyMaxTemps", "HistoricalMonthlyMinTemps" },
                values: new object[] { "[0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0]" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-4c5d-6e7f-8a9b0c1d2e3f"),
                columns: new[] { "HistoricalMonthlyMaxTemps", "HistoricalMonthlyMinTemps" },
                values: new object[] { "[0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0]" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-4d5e-6f7a-8b9c0d1e2f3a"),
                columns: new[] { "HistoricalMonthlyMaxTemps", "HistoricalMonthlyMinTemps" },
                values: new object[] { "[0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0]" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9d0-4e5f-b6a7-8c9d0e1f2a3b"),
                columns: new[] { "HistoricalMonthlyMaxTemps", "HistoricalMonthlyMinTemps" },
                values: new object[] { "[0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0]" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("f2b3c4d5-e6f7-4a8b-9c0d-e1f2a3b4c5d6"),
                columns: new[] { "HistoricalMonthlyMaxTemps", "HistoricalMonthlyMinTemps" },
                values: new object[] { "[0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0]" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-d0e1-4f5a-b6c7-8d9e0f1a2b3c"),
                columns: new[] { "HistoricalMonthlyMaxTemps", "HistoricalMonthlyMinTemps" },
                values: new object[] { "[0,0,0,0,0,0,0,0,0,0,0,0]", "[0,0,0,0,0,0,0,0,0,0,0,0]" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HistoricalMonthlyMaxTemps",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "HistoricalMonthlyMinTemps",
                table: "Destinations");
        }
    }
}
