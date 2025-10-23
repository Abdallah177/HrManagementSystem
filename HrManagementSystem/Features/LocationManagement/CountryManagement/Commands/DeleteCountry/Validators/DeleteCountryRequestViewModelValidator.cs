using FluentValidation;
using HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.DeleteCountry;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Commands.DeleteCountry.Validators
{
    public class DeleteCountryRequestViewModelValidator : AbstractValidator<DeleteCountryRequestViewModel>
    {
        public DeleteCountryRequestViewModelValidator()
        {
            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("Country ID is required");
        }
    }
}
