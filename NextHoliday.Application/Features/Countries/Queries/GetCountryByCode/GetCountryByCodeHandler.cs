using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Application.Common.Exceptions;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Countries.Queries.GetCountryByCode
{
    public class GetCountryByCodeHandler(ApplicationDbContext context) : IRequestHandler<GetCountryByCodeQuery, CountryByCodeDto?>
    {
        public async Task<CountryByCodeDto?> Handle(GetCountryByCodeQuery request, CancellationToken cancellationToken)
        {
            var query = context.Countries.AsQueryable();

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
