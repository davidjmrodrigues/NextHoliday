using MediatR;
using Microsoft.AspNetCore.Mvc;
using NextHoliday.Application.Features.Destinations.Commands.CreateDestination;
using NextHoliday.Application.Features.Destinations.Queries.GetBestDestination;
using NextHoliday.Application.Features.Destinations.Queries.GetDestinationbyId;
using NextHoliday.Domain.Enums;

namespace NextHoliday.API.Endpoints
{
    public class DestinationEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("destinations").WithTags("Destinations");

            group.MapGet("{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var query = new GetDestinationByIdQuery(id);
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("DestinationById")
            .Produces<Application.Features.Destinations.Queries.GetDestinationbyId.DestinationDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);

            // GET BEST
            group.MapGet("best", async (Continent? continent, int? month, IMediator mediator) =>
            {
                var query = new GetBestDestinationQuery(continent, month);
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetBestDestination")
            .Produces<Application.Features.Destinations.Queries.GetBestDestination.DestinationDto>(StatusCodes.Status200OK)
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
