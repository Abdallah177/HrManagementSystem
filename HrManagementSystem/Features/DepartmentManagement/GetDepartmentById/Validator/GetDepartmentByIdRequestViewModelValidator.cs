using FluentValidation;

namespace HrManagementSystem.Features.DepartmentManagement.GetDepartmentById.Validator
{
    public class GetDepartmentByIdRequestViewModelValidator : AbstractValidator<GetDepartmentByIdRequestViewModel>
    {
        public GetDepartmentByIdRequestViewModelValidator()
        {
            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("DepartmentId is required");
        }
    }
}
