using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Application.Common.Exceptions;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Destinations.Commands.UpdateDestination
{
    public class UpdateDestinationHandler : IRequestHandler<UpdateDestinationCommand, Unit>
    {
        private readonly ApplicationDbContext _context;

        public UpdateDestinationHandler(ApplicationDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateDestinationCommand request, CancellationToken cancellationToken)
        {
            var destination = await _context.Destinations.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException($"Destination with ID {request.Id} not found.");

            var countryExists = await _context.Countries.AnyAsync(c => c.Code == request.CountryCode, cancellationToken);

            if (!countryExists)
                throw new KeyNotFoundException($"Country with code {request.CountryCode} not found.");

            destination.City = request.City;
            destination.Description = request.Description;
            destination.CountryCode = request.CountryCode;
            destination.IsActive = request.IsActive;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
