using MediatR;
using Microsoft.AspNetCore.Mvc;
using NextHoliday.Application.Countries.Queries.GetAllCountries;
using NextHoliday.Domain.Enums;

namespace NextHoliday.API.Endpoints
{
    public class CountryEndpoint : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("countries").WithTags("Countries");

            group.MapGet("/", async (Continent? continent, IMediator mediator) =>
            {
                var query = new GetAllCountriesQuery(continent);
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetAllCountries")
            .Produces<List<CountryDto>>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);
        }
    }
}
