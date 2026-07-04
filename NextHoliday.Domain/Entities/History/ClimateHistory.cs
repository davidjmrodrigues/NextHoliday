namespace NextHoliday.Domain.Entities.History
{
    public class ClimateHistory
    {
        public Guid Id { get; set; }
        
        public DateOnly Date { get; set; } 
        
        // in Celsius
        public double MaxTemperature { get; set; } 
        public double MinTemperature { get; set; } 
        
        public double RainProbability { get; set; } // 0-100
        public string WeatherCondition { get; set; } = string.Empty; // ex: "Sunny", "Rainy"
        
        public int WeatherCode { get; set; } 

        // Foreign keys
        public Guid DestinationId { get; set; }

        // Navigation properties
        public Destination Destination { get; set; } = null!;
    }
}