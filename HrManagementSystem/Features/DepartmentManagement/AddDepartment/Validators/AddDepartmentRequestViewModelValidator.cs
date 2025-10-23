using FluentValidation;

namespace HrManagementSystem.Features.DepartmentManagement.AddDepartment.Validators
{
    public class AddDepartmentRequestViewModelValidator : AbstractValidator<AddDepartmentRequestViewModel>
    {
        public AddDepartmentRequestViewModelValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Department name is required")
            .MaximumLength(100).WithMessage("Department name cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("BranchId is required");
        }
    }
}
