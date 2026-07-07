using MediatR;
using Microsoft.AspNetCore.Identity;
using NextHoliday.Application.Common.Exceptions;

namespace NextHoliday.Application.Features.Auth.Commands.Register
{
    public class RegisterHandler(UserManager<IdentityUser> userManager) : IRequestHandler<RegisterCommand, RegisterResult>
    {
        public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userByUsername = await userManager.FindByNameAsync(request.Username);
            if (userByUsername != null)
                throw new UserDataAlreadyExistsException("username", request.Username);

            if (await userManager.FindByEmailAsync(request.Email) != null)
                throw new UserDataAlreadyExistsException("email", request.Email);

        var user = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return new RegisterResult("User successfully registered.", user.UserName);
        }
    }
}
