using NextHoliday.Domain.Enums;
using MediatR;
using NextHoliday.Application.Destinations.Queries.GetBestDestination;
using Microsoft.AspNetCore.Mvc;

namespace NextHoliday.API.Endpoints
{
    public class DestinationEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("destinations").WithTags("Destinations");

            group.MapGet("best", async (Continent continent, int month, IMediator mediator) =>
            {
                var query = new GetBestDestinationQuery(continent, month);
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetBestDestination")
            .Produces<DestinationDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);
        }
    }
}
