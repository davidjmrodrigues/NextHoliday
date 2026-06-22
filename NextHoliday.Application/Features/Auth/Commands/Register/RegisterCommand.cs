using MediatR;

namespace NextHoliday.Application.Features.Auth.Commands.Register
{
    public record RegisterCommand(string Username, string Email, string Password) : IRequest<RegisterResult>;
}
