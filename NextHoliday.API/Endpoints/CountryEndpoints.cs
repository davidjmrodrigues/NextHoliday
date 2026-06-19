using MediatR;
using Microsoft.AspNetCore.Mvc;
using NextHoliday.API.Common.Models;
using NextHoliday.Application.Features.Countries.Queries.GetAllCountries;
using NextHoliday.Application.Features.Countries.Queries.GetCountryByCode;

namespace NextHoliday.API.Endpoints
{
    public class CountryEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("countries").WithTags("Countries");

            group.MapGet("", async (
                string? continent,
                bool? requiresVisa,
                [AsParameters] PaginationParams paged, 
                IMediator mediator = null!) =>
            {
                var query = new GetAllCountriesQuery(continent, requiresVisa)
                {
                    Search = paged.Search,
                    Page = paged.Page,
                    PageSize = paged.PageSize
                };
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetAllCountries")
            .Produces<List<CountryGridDto>>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);

            group.MapGet("/{code}", async (string code, IMediator mediator) =>
            {
                var query = new GetCountryByCodeQuery(code);
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetCountryByCode")
            .Produces<List<CountryByCodeDto>>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);
        }
    }
}
