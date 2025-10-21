using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.AddState.Validators
{
    public class AddStateRequestViewModelValidator : AbstractValidator<AddStateRequestViewModel>
    {
        public AddStateRequestViewModelValidator() 
        {
            RuleFor(x => x.Name)
                   .NotEmpty().WithMessage("State name is required")
                   .MaximumLength(100).WithMessage("State name cannot exceed 100 characters")
                   .Matches("^[a-zA-Z\\s]+$").WithMessage("State name can only contain letters and spaces");

            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("Country ID is required");

        }
    }
}
