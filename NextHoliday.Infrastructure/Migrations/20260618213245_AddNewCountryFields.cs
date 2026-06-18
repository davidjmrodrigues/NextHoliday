using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NextHoliday.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCountryFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Capital",
                table: "Countries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "Countries",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Countries",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "RequiresVisa",
                table: "Countries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "AU",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "BR",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "CN",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "EG",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "ES",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "FR",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "IT",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "JP",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "PT",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "US",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capital",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "RequiresVisa",
                table: "Countries");
        }
    }
}
