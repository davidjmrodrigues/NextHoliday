using MediatR;
using NextHoliday.Domain.Enums;

namespace NextHoliday.Application.Entities.Destinations.Queries.GetBestDestination
{
    public record GetBestDestinationQuery(Continent Continent, int Month) : IRequest<DestinationDto>;

    public record DestinationDto(
        Guid Id,
        string City,
        string CountryName,
        double AverageTemperature,
        double RainProbability,
        string WeatherCondition,
        decimal EstimatedTotalCost
    );
}
