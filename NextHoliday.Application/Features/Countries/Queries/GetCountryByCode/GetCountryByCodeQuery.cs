using MediatR;

namespace NextHoliday.Application.Features.Countries.Queries.GetCountryByCode
{
    public record GetCountryByCodeQuery(string Code) : IRequest<CountryByCodeDto>;
    public record CountryByCodeDto(
        string Code,
        string Name,
        string Continent,
        string Currency,
        string Language,
        string Capital,
        bool RequiresVisa
    );
}
