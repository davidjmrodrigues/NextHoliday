using FluentValidation;

namespace NextHoliday.Application.Entities.Destinations.Queries.GetBestDestination;

public class GetBestDestinationValidator : AbstractValidator<GetBestDestinationQuery>
{
    public GetBestDestinationValidator()
    {
        RuleFor(x => x.Month)
            .InclusiveBetween(1, 12)
            .WithMessage("Month must be beetween 1 and 12.");

        RuleFor(x => x.Continent)
            .IsInEnum()
            .WithMessage("Continent not valid.");
    }
}