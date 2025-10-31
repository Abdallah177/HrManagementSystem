using FluentValidation;
using HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.AddCountry;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.AddCountry.Validators
{
    public class AddCountryViewModelValidator : AbstractValidator<AddCountryViewModel>
    {
        public AddCountryViewModelValidator() 
        {
            RuleFor(x => x.Name)
          .NotEmpty().WithMessage("Country name is required")
          .MaximumLength(50).WithMessage("Country name too long");

            RuleFor(x => x.Code)
                .MaximumLength(10).WithMessage("Country code too long");

        }
    }
}
