using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Application.Common.Exceptions;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Destinations.Commands.UpdateDestination
{
    public class UpdateDestinationHandler(ApplicationDbContext context) : IRequestHandler<UpdateDestinationCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateDestinationCommand request, CancellationToken cancellationToken)
        {
            var destination = await context.Destinations.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken)
                ?? throw new NotFoundException($"Destination with ID {request.Id} not found.");

            var countryExists = await context.Countries.AnyAsync(c => c.Code == request.CountryCode, cancellationToken);

            if (!countryExists)
                throw new KeyNotFoundException($"Country with code {request.CountryCode} not found.");

            destination.City = request.City;
            destination.Description = request.Description;
            destination.CountryCode = request.CountryCode;
            destination.Latitude = request.Latitude;
            destination.Longitude = request.Longitude;
            destination.IsActive = request.IsActive;

            await context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
