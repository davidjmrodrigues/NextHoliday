using MediatR;
using NextHoliday.Domain.Enums;

namespace NextHoliday.Application.Entities.Countries.Queries.GetCountryByCode
{
    public record GetCountryByCodeQuery(string Code) : IRequest<CountryDto>;
    public record CountryDto(
        string Code,
        string Name,
        Continent Continent
    );
}
