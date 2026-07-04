using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Application.Common.Exceptions;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Destinations.Queries.GetDestinationbyId
{
    public class GetDestinationByIdHandler : IRequestHandler<GetDestinationByIdQuery, DestinationByIdDto?>
    {
        private readonly ApplicationDbContext _context;

        public GetDestinationByIdHandler(ApplicationDbContext context) => _context = context;

        public async Task<DestinationByIdDto?> Handle(GetDestinationByIdQuery request, CancellationToken cancellationToken)
        {
            var destinations = await _context.Destinations
                .AsNoTracking()
                .Where(d => d.Id == request.Id)
                .Select(d => new DestinationByIdDto(
                    d.Id,
                    d.City,
                    d.Country.Code,
                    d.Country.Name,
                    d.Description,
                    d.Latitude,
                    d.Longitude,
                    d.IsActive,
                    d.ClimateHistories.Select(ch => new ClimateHistoryDto(ch.Date, ch.MinTemperature, ch.MaxTemperature, ch.RainProbability, ch.WeatherCondition, ch.WeatherCode)),
                    d.PriceHistories.Select(ph => new PriceHistoryDto(ph.Month, ph.EstimatedFlightPrice, ph.EstimatedHotelPricePerNight))
                )).FirstOrDefaultAsync(cancellationToken);

            return destinations ?? throw new NotFoundException("Destination not found.");
        }
    }
}
