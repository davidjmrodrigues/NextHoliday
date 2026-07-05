using MediatR;
using NextHoliday.Domain.Entities.History;

namespace NextHoliday.Application.Features.Destinations.Queries.GetDestinationbyId
{
    public record GetDestinationByIdQuery(Guid Id) : IRequest<DestinationByIdDto>;

    public record DestinationByIdDto(
        Guid Id,
        string City,
        string CountryCode,
        string CountryName,
        string Description,
        double Latitude,
        double Longitude,
        bool IsActive,
        string HistoricalMonthlyMinTemps,
        string HistoricalMonthlyMaxTemps,
        IEnumerable<ClimateHistoryDto> ClimateHistories,
        IEnumerable<PriceHistoryDto> PriceHistories
    );

    public record ClimateHistoryDto(DateOnly Date, double MinTemperature, double MaxTemperature, double RainProbability, string WeatherCondition, int WeatherCode);
    public record PriceHistoryDto(int Month, decimal EstimatedFlightPrice, decimal EstimatedHotelPricePerNight);
}
