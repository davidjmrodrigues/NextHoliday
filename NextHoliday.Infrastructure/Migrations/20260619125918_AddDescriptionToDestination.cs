using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextHoliday.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDescriptionToDestination : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Destinations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Destinations");
        }
    }
}
