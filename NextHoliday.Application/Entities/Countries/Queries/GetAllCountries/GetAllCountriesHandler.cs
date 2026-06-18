using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Entities.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryDto>?>
    {
        private readonly ApplicationDbContext _context;

        public GetAllCountriesHandler(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<CountryDto>?> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
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

            var countries = await query
            .OrderBy(c => c.Name)
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .Select(c => new CountryDto(
                c.Code,
                c.Name,
                c.Continent.ToString(),
                c.Currency,
                c.Currency,
                c.Capital,
                c.RequiresVisa
            ))
            .ToListAsync(cancellationToken);

            return countries;
        }
    }
}
