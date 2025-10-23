using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.UpdateState
{
    public class UpdateStateRequestValidator : AbstractValidator<UpdateStateRequestViewModel>
    {
        public UpdateStateRequestValidator()
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("State Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("State name is required.");

            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("Country Id is required.");
        }
    }
}
