using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesHandler(ApplicationDbContext context) : IRequestHandler<GetAllCountriesQuery, IEnumerable<CountryGridDto>?>
    {
        public async Task<IEnumerable<CountryGridDto>?> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var query = context.Countries.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                query = query.Where(c => 
                    c.Name.Contains(request.Search, StringComparison.CurrentCultureIgnoreCase) || 
                    c.Code.Contains(request.Search, StringComparison.CurrentCultureIgnoreCase)
                );
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
