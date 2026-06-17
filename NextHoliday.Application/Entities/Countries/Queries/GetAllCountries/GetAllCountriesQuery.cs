using MediatR;
using NextHoliday.Domain.Enums;

namespace NextHoliday.Application.Entities.Countries.Queries.GetAllCountries
{
    public record GetAllCountriesQuery(Continent? Continent = null) : IRequest<List<CountryDto>>;
    public record CountryDto(
        string Code,
        string Name,
        Continent Continent
    );
}
