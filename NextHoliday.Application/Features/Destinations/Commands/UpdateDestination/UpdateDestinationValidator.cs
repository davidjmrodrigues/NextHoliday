using FluentValidation;

namespace NextHoliday.Application.Features.Destinations.Commands.UpdateDestination
{
    public class UpdateDestinationValidator : AbstractValidator<UpdateDestinationCommand>
    {
        public UpdateDestinationValidator()
        {
            RuleFor(x => x.Id)
            .NotEqual(Guid.Empty)
            .WithMessage("The Destination ID cannot be empty.");

            RuleFor(x => x.City)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.CountryCode)
                .NotEmpty()
                .Length(2);

            RuleFor(x => x.Latitude)
                .NotEmpty()
                .NotEqual(0);
            
            RuleFor(x => x.Longitude)
                .NotEmpty()
                .NotEqual(0);
        }
    }
}
