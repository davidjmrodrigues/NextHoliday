using MediatR;

namespace NextHoliday.Application.Features.Destinations.Queries.GetDestinationbyId
{
    public record GetDestinationByIdQuery(Guid Id) : IRequest<DestinationDto>;

    public record DestinationDto(
        Guid Id,
        string City,
        string CountryCode,
        string CountryName,
        string Description,
        bool IsActive,
        double AverageTemperature,
        double RainProbability,
        string WeatherCondition,
        decimal EstimatedTotalCost
    );
}
