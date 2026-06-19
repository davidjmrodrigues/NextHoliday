using MediatR;
using Microsoft.AspNetCore.Mvc;
using NextHoliday.Application.Entities.Destinations.Queries.GetBestDestination;
using NextHoliday.Application.Features.Destinations.Commands.CreateDestination;
using NextHoliday.Domain.Enums;

namespace NextHoliday.API.Endpoints
{
    public class DestinationEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("destinations").WithTags("Destinations");

            // GET BEST
            group.MapGet("best", async (Continent? continent, int? month, IMediator mediator) =>
            {
                var query = new GetBestDestinationQuery(continent, month);
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetBestDestination")
            .Produces<DestinationDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);

            // POST
            group.MapPost("", async (CreateDestinationCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.CreatedAtRoute("GetDestinationById", new { id = result.Id }, result);
            });
        }
    }
}
