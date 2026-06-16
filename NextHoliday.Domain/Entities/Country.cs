using NextHoliday.Domain.Enums;

namespace NextHoliday.Domain.Entities
{
    public class Country
    {
        public String Code { get; set; } = string.Empty; // ISO 3166-1 alpha-2 code
        public String Name { get; set; } = string.Empty;
        public Continent Continent { get; set; }

        // Navigation properties
        public ICollection<Destination> Destinations { get; set; } = [];
    }
}
