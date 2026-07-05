using MediatR;
using NextHoliday.Application.Features.Admin.Commands.SyncHistoricalClimate;
using NextHoliday.Infrastructure.Services.Weather;

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


            // DESTINATIONS
            var destinationsGroup = group.MapGroup("destinations");
            destinationsGroup.MapPost("sync-historical-climate", async (IMediator mediator, CancellationToken cancellationToken) =>
            {
                Console.WriteLine("[Manual Sync] Historical climate sync initiaded via API...");

                var response = await mediator.Send(new SyncHistoricalClimateCommand(), cancellationToken);

                Console.WriteLine("[Manual Sync] Historical climate sync terminated with message: " + response.Message);

                return Results.Ok(response);
            })
            .WithName("SyncHistoricalClimate");
        }
    }
}
