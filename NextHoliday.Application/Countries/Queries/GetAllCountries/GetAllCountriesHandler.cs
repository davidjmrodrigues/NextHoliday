using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Countries.Queries.GetAllCountries
{
    public class GetAllCountriesHandler : IRequestHandler<GetAllCountriesQuery, List<CountryDto>?>
    {
        private readonly ApplicationDbContext _context;

        public GetAllCountriesHandler(ApplicationDbContext context) => _context = context;

        public async Task<List<CountryDto>?> Handle(GetAllCountriesQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Countries.AsQueryable();

            if (request.Continent.HasValue)
                query = query.Where(c => c.Continent == request.Continent.Value);

            return await query.Select(c => new CountryDto(c.Code, c.Name, c.Continent))
                .ToListAsync(cancellationToken);
        }
    }
}
