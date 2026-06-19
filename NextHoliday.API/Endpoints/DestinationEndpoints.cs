using MediatR;
using Microsoft.AspNetCore.Mvc;
using NextHoliday.API.Common.Models;
using NextHoliday.Application.Features.Destinations.Commands.CreateDestination;
using NextHoliday.Application.Features.Destinations.Queries.GetAllDestinations;
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

            // GET ALL
            group.MapGet("", async (
                String? countryCode,
                bool? isActive,
                [AsParameters] PaginationParams paged,
                IMediator mediator) =>
            {
                var query = new GetAllDestinationsQuery(countryCode, isActive)
                {
                    Search = paged.Search,
                    Page = paged.Page,
                    PageSize = paged.PageSize
                };
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetAllDestinations")
            .Produces<List<DestinationGridDto>>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);
            
            // GET BY ID
            group.MapGet("{id:guid}", async (Guid id, IMediator mediator) =>
            {
                var query = new GetDestinationByIdQuery(id);
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetDestinationById")
            .Produces<DestinationByIdDto>(StatusCodes.Status200OK)
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
            .Produces<BestDestinationDto>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);

            // POST
            group.MapPost("", async (CreateDestinationCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.CreatedAtRoute("GetDestinationById", new { id = result.Id }, result);
            })
            .WithName("CreateDestination")
            .Produces<CreatedDestinationResponse>(StatusCodes.Status201Created)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);
        }
    }
}
