using FluentValidation;

namespace NextHoliday.Application.Entities.Countries.Queries.GetCountryByCode
{
    public class GetCountryByCodeValidator : AbstractValidator<GetCountryByCodeQuery>
    {
        public GetCountryByCodeValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty()
                .WithMessage("Country code is mandatory")
                .Length(2, 2)
                .WithMessage("Country code must have exactly 2 characters")
                .Matches(@"^[A-Z]{2}$")
                .WithMessage("Country code should contain exactly two uppercase letters (ex: PT, ES, FR)");
        }
    }
}