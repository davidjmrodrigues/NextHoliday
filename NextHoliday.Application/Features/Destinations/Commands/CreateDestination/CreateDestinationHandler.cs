using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Domain.Entities;
using NextHoliday.Infrastructure.Persistence;

namespace NextHoliday.Application.Features.Destinations.Commands.CreateDestination
{
    public class CreateDestinationHandler : IRequestHandler<CreateDestinationCommand, CreatedDestinationResponse>
    {
        private readonly ApplicationDbContext _context;
        public CreateDestinationHandler(ApplicationDbContext context) => _context = context;

        public async Task<CreatedDestinationResponse> Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            var countryExists = await _context.Countries.AnyAsync(c => c.Code == request.CountryCode, cancellationToken);

            if (!countryExists)
                throw new KeyNotFoundException($"Country with code '{request.CountryCode}' not found.");

            var destination = new Destination
            {
                Id = Guid.NewGuid(),
                City = request.City,
                Description = request.Description,
                CountryCode = request.CountryCode,
                IsActive = true
            };

            await _context.Destinations.AddAsync(destination, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreatedDestinationResponse(destination.Id, destination.City);
        }
    }
}
