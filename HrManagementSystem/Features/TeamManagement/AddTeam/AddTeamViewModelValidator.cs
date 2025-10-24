using FluentValidation;

namespace HrManagementSystem.Features.TeamManagement.AddTeam;

public class AddTeamViewModelValidator : AbstractValidator<AddTeamViewModel>
{
    public AddTeamViewModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.DepartmentId).NotEmpty();
    }
}
