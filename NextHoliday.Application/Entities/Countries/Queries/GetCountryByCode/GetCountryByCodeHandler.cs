using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Application.Common.Exceptions;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Entities.Countries.Queries.GetCountryByCode
{
    public class GetCountryByCodeHandler : IRequestHandler<GetCountryByCodeQuery, CountryDto?>
    {
        private readonly ApplicationDbContext _context;

        public GetCountryByCodeHandler(ApplicationDbContext context) => _context = context;

        public async Task<CountryDto?> Handle(GetCountryByCodeQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Countries.AsQueryable();

            if (!request.Code.Equals(""))
                query = query.Where(c => c.Code == request.Code);

            var country = await query.Select(c => new CountryDto(c.Code, c.Name, c.Continent.ToString()))
                .FirstOrDefaultAsync(cancellationToken);

            return country ?? throw new NotFoundException($"Country with code {request.Code} not found.");
        }
    }
}
