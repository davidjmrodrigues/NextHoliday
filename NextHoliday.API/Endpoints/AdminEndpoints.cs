using NextHoliday.Infrastructure.Services;

namespace NextHoliday.API.Endpoints
{
    public class AdminEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("admin")
                .RequireAuthorization(policy => policy.RequireRole("Admin"));

            // WEATHER
            var weatherGroup = group.MapGroup("weather");

            weatherGroup.MapPost("sync", async (WeatherSyncService syncService) =>
            {
                Console.WriteLine("[Manual Sync] Weather data sync initiated via API...");

                await syncService.SyncWeatherForDestinationsAsync();

                return Results.Ok();
            })
            .WithName("ForceWeatherSync");
        }
    }
}
