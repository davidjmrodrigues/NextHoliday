using MediatR;

namespace NextHoliday.Application.Features.Auth.Commands.Login
{
    public record LoginCommand(string Username, string Password) : IRequest<string>;
}
