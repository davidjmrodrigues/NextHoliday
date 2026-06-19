using MediatR;
using NextHoliday.Domain.Entities.History;

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
        IEnumerable<ClimateHistoryDto> ClimateHistories,
        IEnumerable<PriceHistoryDto> PriceHistories
    );

    public record ClimateHistoryDto(int Month, double AverageTemperature, double RainProbability, string WeatherCondition);
    public record PriceHistoryDto(int Month, decimal EstimatedFlightPrice, decimal EstimatedHotelPricePerNight);
}
