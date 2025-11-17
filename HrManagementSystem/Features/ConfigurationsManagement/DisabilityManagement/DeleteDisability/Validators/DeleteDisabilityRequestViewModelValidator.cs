using FluentValidation;

namespace HrManagementSystem.Features.DisabilityManagement.DeleteDisability.Validators
{
    public class DeleteDisabilityRequestViewModelValidator : AbstractValidator<DeleteDisabilityRequestViewModel>
    {
        public DeleteDisabilityRequestViewModelValidator() 
        {
            RuleFor(x => x.DisabilityId)
               .NotEmpty()
               .WithMessage("DisabilityId is required");

        }
    }
}
