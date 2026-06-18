using NextHoliday.Domain.Enums;

namespace NextHoliday.Domain.Entities
{
    public class Country
    {
        // PK
        public String Code { get; set; } = string.Empty; // ISO 3166-1 alpha-2 code

        public String Name { get; set; } = string.Empty;
        public String Currency { get; set; } = string.Empty; // ISO 4217 currency code
        public String Language { get; set; } = string.Empty;
        public String Capital { get; set; } = string.Empty;
        public bool RequiresVisa { get; set; }
        public Continent Continent { get; set; }

        // Navigation properties
        public ICollection<Destination> Destinations { get; set; } = [];
    }
}
