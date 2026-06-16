using NextHoliday.Domain.Entities.History;

namespace NextHoliday.Domain.Entities
{
    public class Destination
    {
        public Guid Id { get; set; }
        public string City { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Foreign Keys
        public string CountryCode { get; set; } = string.Empty;

        // Navigation properties
        public Country Country { get; set; } = null!;
        public ICollection<ClimateHistory> ClimateHistories { get; set; } = [];
        public ICollection<PriceHistory> PriceHistories { get; set; } = [];

    }
}
