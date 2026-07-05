using MediatR;
using Microsoft.EntityFrameworkCore;
using NextHoliday.Domain.Entities;
using NextHoliday.Infrastructure.Persistence;
using NextHoliday.Infrastructure.Services.Weather;
using System.Text.Json;

namespace NextHoliday.Application.Features.Destinations.Commands.CreateDestination
{
    public class CreateDestinationHandler(ApplicationDbContext context, ClimateService climateService) 
        : IRequestHandler<CreateDestinationCommand, CreatedDestinationResponse>
    {
        public async Task<CreatedDestinationResponse> Handle(CreateDestinationCommand request, CancellationToken cancellationToken)
        {
            var countryExists = await context.Countries.AnyAsync(c => c.Code == request.CountryCode, cancellationToken);

            if (!countryExists)
                throw new KeyNotFoundException($"Country with code '{request.CountryCode}' not found.");

            var destination = new Destination
            {
                Id = Guid.NewGuid(),
                City = request.City,
                Description = request.Description,
                CountryCode = request.CountryCode.ToUpper(),
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                IsActive = true
            };

            await climateService.PopulateHistoricalClimateAsync(destination);

            await context.Destinations.AddAsync(destination, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return new CreatedDestinationResponse(
                destination.Id, 
                destination.City,
                destination.Description,
                destination.CountryCode,
                destination.Latitude,
                destination.Longitude,
                destination.IsActive,
                JsonSerializer.Serialize(destination.HistoricalMonthlyMinTemps),
                JsonSerializer.Serialize(destination.HistoricalMonthlyMaxTemps)
            );
        }
    }
}
