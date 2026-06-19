using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Application.Common.Exceptions;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Destinations.Queries.GetDestinationbyId
{
    public class GetDestinationByIdHandler : IRequestHandler<GetDestinationByIdQuery, DestinationDto?>
    {
        private readonly ApplicationDbContext _context;

        public GetDestinationByIdHandler(ApplicationDbContext context) => _context = context;

        public async Task<DestinationDto?> Handle(GetDestinationByIdQuery request, CancellationToken cancellationToken)
        {
            var destinations = await _context.Destinations
                .AsNoTracking()
                .Where(d => d.Id == request.Id)
                .Select(d => new DestinationDto(
                    d.Id,
                    d.City,
                    d.Country.Code,
                    d.Country.Name,
                    d.Description,
                    d.IsActive,
                    d.ClimateHistories.Select(ch => new ClimateHistoryDto(ch.Month, ch.AverageTemperature, ch.RainProbability, ch.WeatherCondition)),
                    d.PriceHistories.Select(ph => new PriceHistoryDto(ph.Month, ph.EstimatedFlightPrice, ph.EstimatedHotelPricePerNight))
                )).FirstOrDefaultAsync(cancellationToken);

            return destinations ?? throw new NotFoundException("Destination not found.");
        }
    }
}
