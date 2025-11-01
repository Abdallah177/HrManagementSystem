using FluentValidation;

namespace HrManagementSystem.Features.DepartmentManagement.DeleteDepartment
{
    public class DeleteDepartmentRequestValidator : AbstractValidator<DeleteDepartmentRequestViewModel>
    {
        public DeleteDepartmentRequestValidator()
        {
            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("DepartmentId is required.");
        }
    }
}
