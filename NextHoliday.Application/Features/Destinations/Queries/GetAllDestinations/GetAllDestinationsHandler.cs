using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Infrastructure.Persistence;
using System.Text.Json;

namespace NextHoliday.Application.Features.Destinations.Queries.GetAllDestinations;

public class GetAllDestinationsHandler(ApplicationDbContext context) : IRequestHandler<GetAllDestinationsQuery, IEnumerable<DestinationGridDto>>
{
    public async Task<IEnumerable<DestinationGridDto>> Handle(GetAllDestinationsQuery request, CancellationToken cancellationToken)
    {
        var query = context.Destinations
            .AsNoTracking()
            .Include(d => d.Country)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Search))
            query = query.Where(c => c.City.Contains(request.Search, StringComparison.CurrentCultureIgnoreCase));

        if (!string.IsNullOrWhiteSpace(request.CountryCode))
            query = query.Where(d => d.CountryCode == request.CountryCode);

        if (request.IsActive.HasValue)
            query = query.Where(d => d.IsActive == request.IsActive);

        return await query
            .OrderBy(c => c.City)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(d => new DestinationGridDto(
                d.Id,
                d.City,
                d.Country.Code,
                d.Country.Name,
                d.Description,
                d.Latitude,
                d.Longitude,
                d.IsActive,
                JsonSerializer.Serialize(d.HistoricalMonthlyMinTemps),
                JsonSerializer.Serialize(d.HistoricalMonthlyMaxTemps)
            ))
            .ToListAsync(cancellationToken);
    }
}