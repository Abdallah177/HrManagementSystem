using FluentValidation;

namespace HrManagementSystem.Features.OrganizationManagement.GetByIDOrganization
{
    public class GetOrganizationRequsetValidator : AbstractValidator<GetOranizationByIdRequsetViewModel>
    {
        public GetOrganizationRequsetValidator()
        {
            RuleFor(x => x.OrganizationId)
              .NotEmpty().WithMessage("Organization Id is required.");
        }
    }
}
