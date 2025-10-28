namespace HrManagementSystem.Features.DepartmentManagement.UpdateDepartmet
{
    using FluentValidation;

    public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequestViewModel>
    {
        public UpdateDepartmentRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Department Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Department name is required.")
                .MaximumLength(200).WithMessage("Department name must not exceed 200 characters.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("Branch Id is required.");
        }
    }

}
