using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace NextHoliday.Infrastructure.Services.Weather
{
    public class WeatherSyncBackgroundService(IServiceProvider serviceProvider) : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;
        private readonly TimeSpan _period = TimeSpan.FromHours(12);

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using PeriodicTimer timer = new(_period);

            while (await timer.WaitForNextTickAsync(stoppingToken) && !stoppingToken.IsCancellationRequested)
            {
                await TriggerSyncAsync();
            }
        }

        private async Task TriggerSyncAsync()
        {
            Console.WriteLine($"[Background Job] Initiating automatic weather sync: {DateTime.UtcNow}");

            using var scope = _serviceProvider.CreateScope();
            var syncService = scope.ServiceProvider.GetRequiredService<WeatherSyncService>();

            await syncService.SyncWeatherForDestinationsAsync();

            Console.WriteLine($"[Background Job] Weather sync completed: {DateTime.UtcNow}");
        }
    }
}
