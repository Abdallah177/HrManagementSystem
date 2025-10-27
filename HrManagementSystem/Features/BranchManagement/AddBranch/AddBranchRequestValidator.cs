using FluentValidation;

namespace HrManagementSystem.Features.BranchManagement.AddBranch
{
    public class AddBranchRequestValidator : AbstractValidator<AddBranchRquestViewModel>
    {
        public AddBranchRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Branch name is required.")
                .MaximumLength(100).WithMessage("Branch name must not exceed 100 characters.");

            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.Phone)
                .Length(10, 15).WithMessage("Phone number must be between 10 and 15 characters.");
            RuleFor(x => x.CityId)
                 .NotEmpty().WithMessage("City ID is required.");

            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company ID is required.");

        }
    }
}
