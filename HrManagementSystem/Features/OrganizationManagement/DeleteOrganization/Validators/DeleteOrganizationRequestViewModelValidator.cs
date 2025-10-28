using FluentValidation;

namespace HrManagementSystem.Features.OrganizationManagement.DeleteOrganization.Validators
{
    public class DeleteOrganizationRequestViewModelValidator : AbstractValidator<DeleteOrganizationRequestViewModel>
    {
        public DeleteOrganizationRequestViewModelValidator()
        {
            RuleFor(x => x.OrganizationId)
                .NotEmpty().WithMessage("OrganizationId is required.");
        }
    }
}
