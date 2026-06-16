namespace NextHoliday.Domain.Entities.History
{
    public class ClimateHistory
    {
        public Guid Id { get; set; }
        public int Month { get; set; } // 1-12
        public double AverageTemperature { get; set; } // in Celsius
        public double RainProbability { get; set; } // Percentage 0-100
        public string WeatherCondition { get; set; } = string.Empty; // e.g., "Sunny", "Rainy"

        // Foreign keys
        public Guid DestinationId { get; set; }

        // Navigation properties
        public Destination Destination { get; set; } = null!;
    }
}
