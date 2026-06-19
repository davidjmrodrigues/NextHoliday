using MediatR;
using NextHoliday.Domain.Enums;

namespace NextHoliday.Application.Entities.Countries.Queries.GetCountryByCode
{
    public record GetCountryByCodeQuery(string Code) : IRequest<CountryDto>;
    public record CountryDto(
        string Code,
        string Name,
        string Continent,
        string Currency,
        string Language,
        string Capital,
        bool RequiresVisa
    );
}
