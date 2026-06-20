using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryGridDto>?>
    {
        private readonly ApplicationDbContext _context;

        public GetAllCountriesHandler(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<CountryGridDto>?> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Countries.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var searchLower = request.Search.ToLower();
                query = query.Where(c => c.Name.ToLower().Contains(searchLower) || c.Code.ToLower().Contains(searchLower));
            }

            if (!string.IsNullOrWhiteSpace(request.Continent))
            {
                var continentLower = request.Continent.ToLower();
                query = query.Where(c => c.Continent.ToString() == continentLower);
            }

            if (request.RequiresVisa.HasValue)
                query = query.Where(c => c.RequiresVisa == request.RequiresVisa.Value);

            var countries = await query
            .OrderBy(c => c.Name)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(c => new CountryGridDto(
                c.Code,
                c.Name,
                c.Continent.ToString(),
                c.Currency,
                c.Language,
                c.Capital,
                c.RequiresVisa
            ))
            .ToListAsync(cancellationToken);

            return countries;
        }
    }
}
