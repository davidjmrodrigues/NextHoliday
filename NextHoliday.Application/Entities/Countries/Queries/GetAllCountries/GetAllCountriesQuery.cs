using MediatR;
using NextHoliday.Domain.Enums;

namespace NextHoliday.Application.Entities.Countries.Queries.GetAllCountries
{
    public record GetAllCountriesQuery(
        String? Search = null,
        String? Continent = null,
        int Page = 1,
        int PageSize = 50
        ) : IRequest<IEnumerable<CountryDto>>;
    public record CountryDto(
        string Code,
        string Name,
        string Continent
    );
}
