namespace NextHoliday.Domain.Entities.History
{
    public class PriceHistory
    {
        public Guid Id { get; set; }
        public int Month { get; set; } // 1-12
        public decimal EstimatedFlightPrice { get; set; }
        public decimal EstimatedHotelPricePerNight { get; set; }
        public DateTime LastUpdatedAt { get; set; }

        // Foreign keys
        public Guid DestinationId { get; set; }
        
        // Navigation properties
        public Destination Destination { get; set; } = null!;
    }
}
