using MediatR;

namespace NextHoliday.Application.Features.Destinations.Commands.CreateDestination
{
    public record CreateDestinationCommand
    (
        string City,
        string Description,
        string CountryCode
    ) : IRequest<CreatedDestinationResponse>;
}

public record CreatedDestinationResponse(Guid Id, string City);