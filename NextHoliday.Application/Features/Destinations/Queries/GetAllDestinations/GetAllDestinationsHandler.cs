using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Destinations.Queries.GetAllDestinations;

public class GetAllDestinationsHandler : IRequestHandler<GetAllDestinationsQuery, IEnumerable<DestinationGridDto>>
{
    private readonly ApplicationDbContext _context;

    public GetAllDestinationsHandler(ApplicationDbContext context) => _context = context;

    public async Task<IEnumerable<DestinationGridDto>> Handle(GetAllDestinationsQuery request, CancellationToken cancellationToken)
    {
        var query = _context.Destinations
            .AsNoTracking()
            .Include(d => d.Country)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(request.Search))
        {
            var searchLower = request.Search.ToLower();
            query = query.Where(c => c.City.ToLower().Contains(searchLower));
        }

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
                d.IsActive
            ))
            .ToListAsync(cancellationToken);
    }
}