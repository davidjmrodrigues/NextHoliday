using MediatR;

namespace NextHoliday.Application.Features.Destinations.Commands.DeleteDestination
{
    public record DeleteDestinationCommand(Guid Id) : IRequest<Unit>;
}
