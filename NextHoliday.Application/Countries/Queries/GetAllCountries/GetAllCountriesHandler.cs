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
            var countries = await _context.Countries.ToListAsync(cancellationToken);

            return countries.Select(c => new CountryDto(c.Code, c.Name, c.Continent)).ToList();
        }
    }
}
