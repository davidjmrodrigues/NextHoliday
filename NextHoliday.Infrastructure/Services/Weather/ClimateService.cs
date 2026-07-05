using NextHoliday.Domain.Entities;
using System.Globalization;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace NextHoliday.Infrastructure.Services.Weather
{
    public class ClimateService(HttpClient httpClient)
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task PopuplateHistoricalClimateAsync(Destination destination)
        {
            var url = string.Format(
                CultureInfo.InvariantCulture,
                "https://climate-api.open-meteo.com/v1/climate?latitude={0}&longitude={1}&start_date=2023-01-01&end_date=2025-12-31&models=EC_Earth3P_HR&daily=temperature_2m_max,temperature_2m_min",
                destination.Latitude,
                destination.Longitude
            );

            try
            {
                var response = await _httpClient.GetFromJsonAsync<OpenMeteoResponse>(url);

                if (response?.Daily == null || response.Daily.Time == null)
                {
                    Console.WriteLine($"[WARNING] No climate data found for destination: {destination.City}");
                    return;
                }

                var monthlyMaxGroup = new List<double>[12];
                var monthlyMinGroup = new List<double>[12];
                for (int i = 0; i < 12; i++)
                {
                    monthlyMaxGroup[i] = [];
                    monthlyMinGroup[i] = [];
                }

                // Group the temperatures by month
                for (int i=0; i < response.Daily.Time.Count; i++)
                {
                    if (!DateTime.TryParse(response.Daily.Time[i], out var date)) continue;

                    var monthIndex = date.Month - 1;

                    var maxTemp = response.Daily.MaxTempModel[i];
                    var minTemp = response.Daily.MinTempModel[i];

                    if (minTemp.HasValue) monthlyMinGroup[monthIndex].Add(minTemp.Value);
                    if (maxTemp.HasValue) monthlyMaxGroup[monthIndex].Add(maxTemp.Value);
                }

                // Calculate the average for each month
                for (int m = 0; m < 12; m++)
                {
                    destination.HistoricalMonthlyMaxTemps[m] = monthlyMaxGroup[m].Count != 0
                        ? Math.Round(monthlyMaxGroup[m].Average(), 1)
                        : 0.0;

                    destination.HistoricalMonthlyMinTemps[m] = monthlyMinGroup[m].Count != 0
                        ? Math.Round(monthlyMinGroup[m].Average(), 1)
                        : 0.0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Failed to fetch climate data for destination: {destination.City}. Exception: {ex.Message}");
            }
        }
        
        // DTOS
        public class OpenMeteoResponse
        {
            [JsonPropertyName("daily")]
            public DailyData Daily { get; set; } = null!;
        }

        public class DailyData
        {
            [JsonPropertyName("time")]
            public List<string> Time { get; set; } = null!;

            [JsonPropertyName("temperature_2m_max_EC_Earth3P_HR")]
            public List<double?> MaxTempModel { get; set; } = null!;

            [JsonPropertyName("temperature_2m_min_EC_Earth3P_HR")]
            public List<double?> MinTempModel { get; set; } = null!;
        }
    }
}
