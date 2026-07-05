using MediatR;
using Microsoft.AspNetCore.Mvc;
using NextHoliday.Application.Features.Auth.Commands.Login;
using NextHoliday.Application.Features.Auth.Commands.Register;
using NextHoliday.Application.Features.Countries.Queries.GetAllCountries;

namespace NextHoliday.API.Endpoints
{
    public class AuthEndpoints : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("auth").WithTags("Authentication");

            group.MapPost("register", async (RegisterCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("RegisterAccount")
            .Produces<RegisterResult>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest);

            group.MapPost("login", async (LoginCommand command, IMediator mediator) =>
            {
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithName("Login")
            .Produces<string>(StatusCodes.Status200OK)
            .Produces<ProblemDetails>(StatusCodes.Status400BadRequest)
            .Produces<ProblemDetails>(StatusCodes.Status401Unauthorized);
        }
    }
}
