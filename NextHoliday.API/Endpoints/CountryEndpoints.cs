using MediatR;
using Microsoft.AspNetCore.Mvc;
using NextHoliday.Application.Entities.Countries.Queries.GetAllCountries;
using NextHoliday.Application.Entities.Countries.Queries.GetCountryByCode;
using NextHoliday.Domain.Enums;

namespace NextHoliday.API.Endpoints
{
    public class CountryEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("countries").WithTags("Countries");

            group.MapGet("/", async (string? search, string? continent, int page=1, int pageSize=50, IMediator mediator = null!) =>
            {
                var query = new GetAllCountriesQuery(search, continent, page, pageSize);
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetAllCountries")
            .Produces<List<Application.Entities.Countries.Queries.GetAllCountries.CountryDto>>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);

            group.MapGet("/{code}", async (string code, IMediator mediator) =>
            {
                var query = new GetCountryByCodeQuery(code);
                var result = await mediator.Send(query);
                return Results.Ok(result);
            })
            .WithName("GetCountryByCode")
            .Produces<List<Application.Entities.Countries.Queries.GetCountryByCode.CountryDto>>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status404NotFound);
        }
    }
}
