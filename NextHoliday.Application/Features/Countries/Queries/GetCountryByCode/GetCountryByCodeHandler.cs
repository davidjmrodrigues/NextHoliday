using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Application.Common.Exceptions;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Countries.Queries.GetCountryByCode
{
    public class GetCountryByCodeHandler : IRequestHandler<GetCountryByCodeQuery, CountryByCodeDto?>
    {
        private readonly ApplicationDbContext _context;

        public GetCountryByCodeHandler(ApplicationDbContext context) => _context = context;

        public async Task<CountryByCodeDto?> Handle(GetCountryByCodeQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Countries.AsQueryable();

            if (!request.Code.Equals(""))
                query = query.Where(c => c.Code == request.Code);

            var country = await query.Select(c => new CountryByCodeDto(
                c.Code,
                c.Name,
                c.Continent.ToString(),
                c.Currency,
                c.Language,
                c.Capital,
                c.RequiresVisa
            ))
            .FirstOrDefaultAsync(cancellationToken);

            return country ?? throw new NotFoundException($"Country with code {request.Code} not found.");
        }
    }
}
