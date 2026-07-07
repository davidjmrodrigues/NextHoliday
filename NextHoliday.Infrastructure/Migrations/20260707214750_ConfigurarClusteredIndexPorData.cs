using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextHoliday.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurarClusteredIndexPorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClimateHistories",
                table: "ClimateHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClimateHistories",
                table: "ClimateHistories",
                column: "Id")
                .Annotation("SqlServer:Clustered", false);

            migrationBuilder.CreateIndex(
                name: "IX_ClimateHistories_Date",
                table: "ClimateHistories",
                column: "Date")
                .Annotation("SqlServer:Clustered", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ClimateHistories",
                table: "ClimateHistories");

            migrationBuilder.DropIndex(
                name: "IX_ClimateHistories_Date",
                table: "ClimateHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClimateHistories",
                table: "ClimateHistories",
                column: "Id");
        }
    }
}
