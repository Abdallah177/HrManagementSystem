using FluentValidation;

namespace HrManagementSystem.Features.TeamManagement.TeamUpdate
{
    public class UpdateTeamValidator : AbstractValidator<UpdateTeamRequsetViewModel>
    {
        public UpdateTeamValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Team Id is required.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Team name is required.");
            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("Department Id is required.");
        }
    }
}
