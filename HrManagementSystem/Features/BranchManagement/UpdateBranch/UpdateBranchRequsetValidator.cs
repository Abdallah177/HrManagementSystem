using FluentValidation;

namespace HrManagementSystem.Features.BranchManagement.UpdateBranch
{
    public class UpdateBranchRequsetValidator : AbstractValidator<UpdateBranchRequsetViewModel>
    {
        public UpdateBranchRequsetValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Branch Id is required.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Branch name is required.")
                .MaximumLength(100).WithMessage("Branch name must not exceed 100 characters.");
            RuleFor(x => x.Phone)
                .MaximumLength(15).WithMessage("Phone number must not exceed 15 characters.");
            RuleFor(x => x.CompanyId)
                .NotEmpty().WithMessage("Company Id is required.");
            RuleFor(x => x.CityId)
                .NotEmpty().WithMessage("City Id is required.");
        }
    }
}
