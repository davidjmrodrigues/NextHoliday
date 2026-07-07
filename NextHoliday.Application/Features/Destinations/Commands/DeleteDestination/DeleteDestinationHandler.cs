using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Application.Common.Exceptions;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Destinations.Commands.DeleteDestination
{
    public class DeleteDestinationHandler(ApplicationDbContext context) : IRequestHandler<DeleteDestinationCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteDestinationCommand request, CancellationToken cancellationToken)
        {
            var destination = await context.Destinations
                .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken) 
                ?? throw new NotFoundException("Destination not found.");

            context.Destinations.Remove(destination);

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
