using MediatR;
using Microsoft.AspNetCore.Identity;
using NextHoliday.Application.Common.Exceptions;

namespace NextHoliday.Application.Features.Auth.Commands.Register
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, RegisterResult>
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterHandler(UserManager<IdentityUser> userManager) => _userManager = userManager;

        public async Task<RegisterResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var userByUsername = await _userManager.FindByNameAsync(request.Username);
            if (userByUsername != null)
                throw new UserDataAlreadyExistsException("username", request.Username);

            if (await _userManager.FindByEmailAsync(request.Email) != null)
                throw new UserDataAlreadyExistsException("email", request.Email);

        var user = new IdentityUser
            {
                UserName = request.Username,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            return new RegisterResult("User successfully registered.", user.UserName);
        }
    }
}
