using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NextHoliday.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCountries : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "AU",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "Canberra", "AUD", "English", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "BR",
                columns: new[] { "Capital", "Currency", "Language" },
                values: new object[] { "Brasília", "BRL", "Portuguese" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "CN",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "Beijing", "CNY", "Mandarin", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "EG",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "Cairo", "EGP", "Arabic", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "ES",
                columns: new[] { "Capital", "Currency", "Language" },
                values: new object[] { "Madrid", "EUR", "Spanish" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "FR",
                columns: new[] { "Capital", "Currency", "Language" },
                values: new object[] { "Paris", "EUR", "French" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "IT",
                columns: new[] { "Capital", "Currency", "Language" },
                values: new object[] { "Rome", "EUR", "Italian" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "JP",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "Tokyo", "JPY", "Japanese", true });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "PT",
                columns: new[] { "Capital", "Currency", "Language" },
                values: new object[] { "Lisboa", "EUR", "Portuguese" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "US",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "Washington D.C.", "USD", "English", true });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Code", "Capital", "Continent", "Currency", "Language", "Name", "RequiresVisa" },
                values: new object[,]
                {
                    { "AD", "Andorra la Vella", 4, "EUR", "Catalan", "Andorra", false },
                    { "AE", "Abu Dhabi", 3, "AED", "Arabic", "United Arab Emirates", true },
                    { "AF", "Kabul", 3, "AFN", "Pashto", "Afghanistan", true },
                    { "AL", "Tirana", 4, "ALL", "Albanian", "Albania", true },
                    { "AO", "Luanda", 1, "AOA", "Portuguese", "Angola", true },
                    { "AR", "Buenos Aires", 7, "ARS", "Spanish", "Argentina", true },
                    { "AT", "Vienna", 4, "EUR", "German", "Austria", false },
                    { "BE", "Brussels", 4, "EUR", "Dutch, French, German", "Belgium", false },
                    { "BG", "Sofia", 4, "BGN", "Bulgarian", "Bulgaria", false },
                    { "BO", "Sucre", 7, "BOB", "Spanish, Quechua, Aymara", "Bolivia", true },
                    { "CA", "Ottawa", 5, "CAD", "English, French", "Canada", true },
                    { "CH", "Bern", 4, "CHF", "German, French, Italian, Romansh", "Switzerland", false },
                    { "CL", "Santiago", 7, "CLP", "Spanish", "Chile", true },
                    { "CO", "Bogotá", 7, "COP", "Spanish", "Colombia", true },
                    { "CR", "San José", 5, "CRC", "Spanish", "Costa Rica", true },
                    { "CU", "Havana", 5, "CUP", "Spanish", "Cuba", true },
                    { "CY", "Nicosia", 4, "EUR", "Greek, Turkish", "Cyprus", false },
                    { "CZ", "Prague", 4, "CZK", "Czech", "Czech Republic", false },
                    { "DE", "Berlin", 4, "EUR", "German", "Germany", false },
                    { "DK", "Copenhagen", 4, "DKK", "Danish", "Denmark", false },
                    { "DO", "Santo Domingo", 5, "DOP", "Spanish", "Dominican Republic", true },
                    { "DZ", "Algiers", 1, "DZD", "Arabic", "Algeria", true },
                    { "EC", "Quito", 7, "USD", "Spanish", "Ecuador", true },
                    { "EE", "Tallinn", 4, "EUR", "Estonian", "Estonia", false },
                    { "FI", "Helsinki", 4, "EUR", "Finnish, Swedish", "Finland", false },
                    { "GB", "London", 4, "GBP", "English", "United Kingdom", true },
                    { "GR", "Athens", 4, "EUR", "Greek", "Greece", false },
                    { "HR", "Zagreb", 4, "EUR", "Croatian", "Croatia", false },
                    { "HU", "Budapest", 4, "HUF", "Hungarian", "Hungary", false },
                    { "ID", "Jakarta", 3, "IDR", "Indonesian", "Indonesia", true },
                    { "IE", "Dublin", 4, "EUR", "Irish, English", "Ireland", false },
                    { "IL", "Jerusalem", 3, "ILS", "Hebrew", "Israel", true },
                    { "IN", "New Delhi", 3, "INR", "Hindi, English", "India", true },
                    { "IS", "Reykjavik", 4, "ISK", "Icelandic", "Iceland", false },
                    { "JM", "Kingston", 5, "JMD", "English", "Jamaica", true },
                    { "JO", "Amman", 3, "JOD", "Arabic", "Jordan", true },
                    { "KE", "Nairobi", 1, "KES", "Swahili, English", "Kenya", true },
                    { "KR", "Seoul", 3, "KRW", "Korean", "South Korea", true },
                    { "LB", "Beirut", 3, "LBP", "Arabic", "Lebanon", true },
                    { "LK", "Colombo", 3, "LKR", "Sinhala, Tamil", "Sri Lanka", true },
                    { "LT", "Vilnius", 4, "EUR", "Lithuanian", "Lithuania", false },
                    { "LU", "Luxembourg City", 4, "EUR", "Luxembourgish, French, German", "Luxembourg", false },
                    { "LV", "Riga", 4, "EUR", "Latvian", "Latvia", false },
                    { "MA", "Rabat", 1, "MAD", "Arabic, Berber", "Morocco", true },
                    { "MC", "Monaco", 4, "EUR", "French", "Monaco", false },
                    { "MT", "Valletta", 4, "EUR", "Maltese, English", "Malta", false },
                    { "MV", "Malé", 3, "MVR", "Dhivehi", "Maldives", true },
                    { "MX", "Mexico City", 5, "MXN", "Spanish", "Mexico", true },
                    { "MY", "Kuala Lumpur", 3, "MYR", "Malay", "Malaysia", true },
                    { "NL", "Amsterdam", 4, "EUR", "Dutch", "Netherlands", false },
                    { "NO", "Oslo", 4, "NOK", "Norwegian", "Norway", false },
                    { "NZ", "Wellington", 6, "NZD", "English, Maori", "New Zealand", true },
                    { "PA", "Panama City", 5, "PAB", "Spanish", "Panama", true },
                    { "PE", "Lima", 7, "PEN", "Spanish", "Peru", true },
                    { "PH", "Manila", 3, "PHP", "Filipino, English", "Philippines", true },
                    { "PL", "Warsaw", 4, "PLN", "Polish", "Poland", false },
                    { "PY", "Asunción", 7, "PYG", "Spanish, Guarani", "Paraguay", true },
                    { "QA", "Doha", 3, "QAR", "Arabic", "Qatar", true },
                    { "RO", "Bucharest", 4, "RON", "Romanian", "Romania", false },
                    { "RU", "Moscow", 4, "RUB", "Russian", "Russia", true },
                    { "SA", "Riyadh", 3, "SAR", "Arabic", "Saudi Arabia", true },
                    { "SE", "Stockholm", 4, "SEK", "Swedish", "Sweden", false },
                    { "SG", "Singapore", 3, "SGD", "English, Malay, Mandarin, Tamil", "Singapore", true },
                    { "SI", "Ljubljana", 4, "EUR", "Slovene", "Slovenia", false },
                    { "SK", "Bratislava", 4, "EUR", "Slovak", "Slovakia", false },
                    { "TH", "Bangkok", 3, "THB", "Thai", "Thailand", true },
                    { "TN", "Tunis", 1, "TND", "Arabic", "Tunisia", true },
                    { "TR", "Ankara", 4, "TRY", "Turkish", "Turkey", true },
                    { "UA", "Kyiv", 4, "UAH", "Ukrainian", "Ukraine", true },
                    { "UY", "Montevideo", 7, "UYU", "Spanish", "Uruguay", true },
                    { "VA", "Vatican City", 4, "EUR", "Italian, Latin", "Vatican City", false },
                    { "VE", "Caracas", 7, "VES", "Spanish", "Venezuela", true },
                    { "VN", "Hanoi", 3, "VND", "Vietnamese", "Vietnam", true },
                    { "ZA", "Pretoria", 1, "ZAR", "Afrikaans, English, etc.", "South Africa", true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "AD");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "AE");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "AF");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "AL");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "AO");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "AR");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "AT");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "BE");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "BG");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "BO");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "CA");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "CH");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "CL");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "CO");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "CR");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "CU");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "CY");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "CZ");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "DE");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "DK");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "DO");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "DZ");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "EC");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "EE");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "FI");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "GB");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "GR");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "HR");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "HU");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "ID");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "IE");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "IL");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "IN");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "IS");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "JM");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "JO");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "KE");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "KR");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "LB");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "LK");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "LT");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "LU");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "LV");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "MA");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "MC");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "MT");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "MV");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "MX");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "MY");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "NL");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "NO");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "NZ");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "PA");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "PE");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "PH");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "PL");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "PY");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "QA");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "RO");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "RU");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "SA");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "SE");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "SG");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "SI");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "SK");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "TH");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "TN");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "TR");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "UA");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "UY");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "VA");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "VE");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "VN");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "ZA");

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
                columns: new[] { "Capital", "Currency", "Language" },
                values: new object[] { "", "", "" });

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
                columns: new[] { "Capital", "Currency", "Language" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "FR",
                columns: new[] { "Capital", "Currency", "Language" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "IT",
                columns: new[] { "Capital", "Currency", "Language" },
                values: new object[] { "", "", "" });

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
                columns: new[] { "Capital", "Currency", "Language" },
                values: new object[] { "", "", "" });

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "Code",
                keyValue: "US",
                columns: new[] { "Capital", "Currency", "Language", "RequiresVisa" },
                values: new object[] { "", "", "", false });
        }
    }
}
