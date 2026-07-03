using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextHoliday.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDestinations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Destinations",
                columns: new[] { "Id", "City", "CountryCode", "Description", "IsActive", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a5b-6c7d-8e9f0a1b2c3d"), "Brasília", "BR", "The federal capital of Brazil, famous for its unique modern architecture designed by Oscar Niemeyer and its airplane-shaped urban plan.", true, -15.797499999999999, -47.8919 },
                    { new Guid("b2c3d4e5-f6a7-4b5c-6d7e-8f9a0b1c2d3e"), "Paris", "FR", "The City of Light, world-renowned for its art, gastronomy, culture, and iconic landmarks like the Eiffel Tower and the Louvre Museum.", true, 48.8566, 2.3521999999999998 },
                    { new Guid("c3d4e5f6-a7b8-4c5d-6e7f-8a9b0c1d2e3f"), "Tokyo", "JP", "A bustling metropolis blending futuristic technology with traditional temples, neon-lit streets, and world-class cuisine.", true, 35.676200000000001, 139.65029999999999 },
                    { new Guid("d4e5f6a7-b8c9-4d5e-6f7a-8b9c0d1e2f3a"), "Washington D.C.", "US", "The capital of the United States, home to iconic monuments, world-class museums, and the centers of the three branches of the federal government.", true, 38.907200000000003, -77.036900000000003 },
                    { new Guid("e5f6a7b8-c9d0-4e5f-b6a7-8c9d0e1f2a3b"), "Canberra", "AU", "Australia's capital city, known for its planned layout, vast open spaces, and national cultural institutions.", true, -35.280900000000003, 149.13 },
                    { new Guid("f2b3c4d5-e6f7-4a8b-9c0d-e1f2a3b4c5d6"), "Lisbon", "PT", "The stunning capital city of Portugal, known for its historic neighborhoods, iconic yellow trams, and delicious custard tart pastries (Pastéis de Belém).", true, 38.722299999999997, -9.1393000000000004 },
                    { new Guid("f6a7b8c9-d0e1-4f5a-b6c7-8d9e0f1a2b3c"), "Cairo", "EG", "The vibrant capital of Egypt, situated on the Nile River and famous for the nearby Great Pyramids of Giza and the Sphinx.", true, 30.0444, 31.235700000000001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a5b-6c7d-8e9f0a1b2c3d"));

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-4b5c-6d7e-8f9a0b1c2d3e"));

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-a7b8-4c5d-6e7f-8a9b0c1d2e3f"));

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-b8c9-4d5e-6f7a-8b9c0d1e2f3a"));

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-c9d0-4e5f-b6a7-8c9d0e1f2a3b"));

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("f2b3c4d5-e6f7-4a8b-9c0d-e1f2a3b4c5d6"));

            migrationBuilder.DeleteData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-d0e1-4f5a-b6c7-8d9e0f1a2b3c"));
        }
    }
}
