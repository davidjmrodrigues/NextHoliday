using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Application.Common.Exceptions;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Destinations.Commands.DeleteDestination
{
    public class DeleteDestinationHandler : IRequestHandler<DeleteDestinationCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public DeleteDestinationHandler(ApplicationDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteDestinationCommand request, CancellationToken cancellationToken)
        {
            var destination = await _context.Destinations
                .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken) 
                ?? throw new NotFoundException("Destination not found.");

            _context.Destinations.Remove(destination);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
