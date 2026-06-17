using MediatR;
using NextHoliday.Domain.Enums;

namespace NextHoliday.Application.Countries.Queries.GetAllCountries
{
    public record GetAllCountriesQuery() : IRequest<List<CountryDto>>;
    public record CountryDto(
        string Code,
        string Name,
        Continent Continent
    );
}
