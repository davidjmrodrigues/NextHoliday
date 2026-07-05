using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Infrastructure.Persistence;
using NextHoliday.Infrastructure.Services.Weather;

namespace NextHoliday.Application.Features.Admin.Commands.SyncHistoricalClimate;

public class SyncHistoricalClimateHandler(ApplicationDbContext context, ClimateService climateService)
    : IRequestHandler<SyncHistoricalClimateCommand, SyncHistoricalClimateResponse>
{
    public async Task<SyncHistoricalClimateResponse> Handle(SyncHistoricalClimateCommand request, CancellationToken cancellationToken)
    {
        var destinations = await context.Destinations.ToListAsync(cancellationToken);

        var destinationsToSync = destinations
            .Where(d => d.HistoricalMonthlyMaxTemps.All(t => t == 0.0) &&
                        d.HistoricalMonthlyMinTemps.All(t => t == 0.0))
            .ToList();

        if (destinationsToSync.Count == 0)
            return new SyncHistoricalClimateResponse(true, 0, "All destinations are already syncronized.");

        int syncedCount = 0;

        foreach (var destination in destinationsToSync)
        {
            await climateService.PopulateHistoricalClimateAsync(destination);

            context.Entry(destination).State = EntityState.Modified;
            syncedCount++;

            await Task.Delay(100, cancellationToken);
        }

        await context.SaveChangesAsync(cancellationToken);

        return new SyncHistoricalClimateResponse(true, syncedCount, $"Successfully synchronized {syncedCount} destinations historical climate.");
    }
}