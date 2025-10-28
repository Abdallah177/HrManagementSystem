using FluentValidation;

namespace HrManagementSystem.Features.DepartmentManagement.DeleteDepartment
{
    public class DeleteDepartmentRequestViledator : AbstractValidator<DeleteDepartmentRequestViewModel>
    {
        public DeleteDepartmentRequestViledator()
        {
            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("DepartmentId is required.");
        }
    }
}
