using MediatR;
using NextHoliday.Application.Common.Parameters;

namespace NextHoliday.Application.Features.Countries.Queries.GetAllCountries
{
    public record GetAllCountriesQuery(
        String? Continent = null,
        bool? RequiresVisa = null
        ) : PagedRequest, IRequest<IEnumerable<CountryGridDto>>;

    public record CountryGridDto(
        string Code,
        string Name,
        string Continent,
        string Currency,
        string Language,
        string Capital,
        bool RequiresVisa
    );
}
