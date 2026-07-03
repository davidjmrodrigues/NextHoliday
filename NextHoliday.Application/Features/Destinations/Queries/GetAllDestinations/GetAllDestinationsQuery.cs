using MediatR;
using NextHoliday.Application.Common.Parameters;

namespace NextHoliday.Application.Features.Destinations.Queries.GetAllDestinations
{
    public record GetAllDestinationsQuery(
        String? CountryCode = null, 
        bool? IsActive = null) 
        :  PagedRequest, IRequest<IEnumerable<DestinationGridDto>>;

    public record DestinationGridDto(
        Guid Id,
        string City,
        string CountryCode,
        string CountryName,
        string Description,
        double Latitude,
        double Longitude,
        bool IsActive
    );
}
