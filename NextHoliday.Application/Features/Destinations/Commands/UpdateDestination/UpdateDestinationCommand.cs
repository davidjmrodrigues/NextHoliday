using MediatR;
using System.Text.Json.Serialization;

namespace NextHoliday.Application.Features.Destinations.Commands.UpdateDestination
{
    public record UpdateDestinationCommand(
        string City,
        string Description,
        string CountryCode,
        double Latitude,
        double Longitude,
        bool IsActive
    ) : IRequest<Unit>
    {
    [JsonIgnore] 
    public Guid Id { get; set; }
    }
}
