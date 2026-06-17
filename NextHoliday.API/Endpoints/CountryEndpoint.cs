using MediatR;
using NextHoliday.Application.Countries.Queries.GetAllCountries;

namespace NextHoliday.API.Endpoints
{
    public class CountryEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("countries").WithTags("Countries");

            group.MapGet("get", async (IMediator mediator) =>
            {
                var query = new GetAllCountriesQuery();
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetAllCountries");
        }
    }
}
