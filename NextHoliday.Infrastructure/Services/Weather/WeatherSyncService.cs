using Microsoft.EntityFrameworkCore;
using NextHoliday.Domain.Entities.History;
using NextHoliday.Infrastructure.Persistence;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace NextHoliday.Infrastructure.Services.Weather
{
    public class WeatherSyncService(ApplicationDbContext context, HttpClient httpClient)
    {
        private readonly ApplicationDbContext _context = context;
        private readonly HttpClient _httpClient = httpClient;

        public async Task SyncWeatherForDestinationsAsync()
        {
            const int batchSize = 10; // Number of destinations to get in each HTML request
            var delayBetweenBatches = TimeSpan.FromSeconds(2);

            var destinations = await _context.Destinations.Where(d => d.IsActive).ToListAsync();

            // Process destinations in batches
            for (int i = 0; i < destinations.Count; i += batchSize)
            {
                var batch = destinations.Skip(i).Take(batchSize).ToList();

                var latitudes = string.Join(",", batch.Select(d => d.Latitude.ToString(CultureInfo.InvariantCulture)));
                var longitudes = string.Join(",", batch.Select(d => d.Longitude.ToString(CultureInfo.InvariantCulture)));

                var url = $"https://api.open-meteo.com/v1/forecast?latitude={latitudes}&longitude={longitudes}&daily=weather_code,temperature_2m_max,temperature_2m_min,precipitation_probability_max&forecast_days=14";

                try
                {
                    List<OpenMeteoResponse>? apiResults = null;

                    if (batch.Count == 1)
                    {
                        var response = await _httpClient.GetFromJsonAsync<OpenMeteoResponse>(url);
                        if (response != null)
                            apiResults = [response];
                    }
                    else
                    {
                        apiResults = await _httpClient.GetFromJsonAsync<List<OpenMeteoResponse>>(url);
                    }

                    if (apiResults == null || apiResults.Count != batch.Count) continue;

                    // Iterate over the batch and corresponding API results
                    for (int j = 0; j < batch.Count; j++)
                    {
                        var destination = batch[j];
                        var apiResult = apiResults[j];

                        if (apiResult?.Daily == null) continue;

                        // Eliminate old forecasts for the destination before adding new ones
                        var oldForecasts = _context.ClimateHistories.Where(ch => ch.DestinationId == destination.Id);
                        _context.ClimateHistories.RemoveRange(oldForecasts);

                        // Iterate over each 14 days of forecast data
                        for (int k = 0; k < apiResult.Daily.Time.Count; k++)
                        {
                            var forecastDate = DateOnly.Parse(apiResult.Daily.Time[k]);
                            var weatherCode = apiResult.Daily.WeatherCode[k];

                            var climateHistory = new ClimateHistory
                            {
                                Id = Guid.NewGuid(),
                                DestinationId = destination.Id,
                                Date = forecastDate,
                                WeatherCode = weatherCode,
                                WeatherCondition = MapWeatherCodeToString(weatherCode),
                                MaxTemperature = apiResult.Daily.Temperature2mMax[k],
                                MinTemperature = apiResult.Daily.Temperature2mMin[k],
                                RainProbability = apiResult.Daily.PrecipitationProbabilityMax[k]
                            };

                            _context.ClimateHistories.Add(climateHistory);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching weather data: {ex.Message}");
                }

                // Delay between batches to avoid hitting API rate limits
                if (i + batchSize < destinations.Count)
                    await Task.Delay(delayBetweenBatches);
            }
        }

        private static string MapWeatherCodeToString(int code)
        {
            return code switch
            {
                0 => "Sunny",
                1 or 2 or 3 => "Partly Cloudy",
                45 or 48 => "Foggy",
                51 or 53 or 55 or 61 or 63 or 65 => "Rainy",
                71 or 73 or 75 or 77 or 85 or 86 => "Snowy",
                80 or 81 or 82 or 95 or 96 or 99 => "Stormy",
                _ => "Cloudy"
            };
        }
    }

    public class OpenMeteoResponse
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("daily")]
        public DailyData Daily { get; set; } = null!;
    }

    public class DailyData
    {
        [JsonPropertyName("time")]
        public List<string> Time { get; set; } = [];

        [JsonPropertyName("weather_code")]
        public List<int> WeatherCode { get; set; } = [];

        [JsonPropertyName("temperature_2m_max")]
        public List<double> Temperature2mMax { get; set; } = [];

        [JsonPropertyName("temperature_2m_min")]
        public List<double> Temperature2mMin { get; set; } = [];

        [JsonPropertyName("precipitation_probability_max")]
        public List<int> PrecipitationProbabilityMax { get; set; } = [];
    }
}
