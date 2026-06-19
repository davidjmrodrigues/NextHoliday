using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Application.Common.Exceptions;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Entities.Destinations.Queries.GetBestDestination
{
    public class GetBestDestinationHandler : IRequestHandler<GetBestDestinationQuery, DestinationDto?>
    {
        private readonly ApplicationDbContext _context;

        public GetBestDestinationHandler(ApplicationDbContext context) => _context = context;

        public async Task<DestinationDto?> Handle(GetBestDestinationQuery request, CancellationToken cancellationToken)
        {
            var destinations = await _context.Destinations
                .Include(d => d.Country)
                .Include(d => d.ClimateHistories.Where(ch => ch.Month == request.Month))
                .Include(d => d.PriceHistories.Where(ch => ch.Month == request.Month))
                .Where(d => d.Country.Continent == request.Continent)
                .ToListAsync(cancellationToken);

            if (destinations.Count == 0) throw new NotFoundException("No destination found.");

            var bestDestination = destinations
                .OrderBy(d => d.ClimateHistories.FirstOrDefault()?.RainProbability ?? 100)
                .FirstOrDefault();

            if (bestDestination == null) throw new NotFoundException("No destination found.");

            var climate = bestDestination.ClimateHistories.FirstOrDefault();
            var price = bestDestination.PriceHistories.FirstOrDefault();

            decimal totalCost = (price?.EstimatedFlightPrice ?? 0) + ((price?.EstimatedHotelPricePerNight ?? 0) * 7);

            return new DestinationDto(
                bestDestination.Id,
                bestDestination.City,
                bestDestination.Country.Code,
                bestDestination.Country.Name,
                bestDestination.Description,
                climate?.AverageTemperature ?? 0,
                climate?.RainProbability ?? 0,
                climate?.WeatherCondition ?? "Unknown",
                totalCost
            );
        }
    }
}
