using MediatR;
using NextHoliday.Domain.Enums;

namespace NextHoliday.Application.Features.Destinations.Queries.GetBestDestination
{
    public record GetBestDestinationQuery(Continent? Continent, int? Month) : IRequest<BestDestinationDto>;

    public record BestDestinationDto(
        Guid Id,
        string City,
        string CountryCode,
        string CountryName,
        string Description,
        double Latitude,
        double Longitude,
        bool IsActive,
        double AverageTemperature,
        double RainProbability,
        string WeatherCondition,
        decimal EstimatedTotalCost
    );
}
