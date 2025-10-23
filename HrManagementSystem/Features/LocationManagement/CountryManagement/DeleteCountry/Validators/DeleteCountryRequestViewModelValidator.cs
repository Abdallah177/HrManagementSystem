using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.DeleteCountry.Validators
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
