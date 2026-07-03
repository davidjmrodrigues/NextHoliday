using MediatR;

namespace NextHoliday.Application.Features.Destinations.Commands.CreateDestination
{
    public record CreateDestinationCommand
    (
        string City,
        string Description,
        string CountryCode,
        double Latitude,
        double Longitude
    ) : IRequest<CreatedDestinationResponse>;
}

public record CreatedDestinationResponse(
    Guid Id, 
    string City, 
    string Description, 
    string CountryCode,
    double Latitude,
    double Longitude,
    bool IsActive
);