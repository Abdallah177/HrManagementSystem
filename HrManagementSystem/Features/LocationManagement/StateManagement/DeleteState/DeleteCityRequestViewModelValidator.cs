using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.DeleteState
{
    public class DeleteCityRequestViewModelValidator : AbstractValidator<DeleteStateRequestViewModel>
    {
        public DeleteCityRequestViewModelValidator()
        {
            RuleFor(x => x.StateId)
                .NotEmpty().WithMessage("State ID is required");
        }

    }
}
