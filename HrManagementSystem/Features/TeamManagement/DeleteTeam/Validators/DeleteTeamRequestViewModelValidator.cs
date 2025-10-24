using FluentValidation;
using HrManagementSystem.Features.TeamManagement.DeleteTeam;

namespace HrManagementSystem.Features.TeamManagement.DeleteTeam.Validators
{
    public class DeleteTeamRequestViewModelValidator : AbstractValidator<DeleteTeamRequestViewModel>
    {
        public DeleteTeamRequestViewModelValidator()
        {
            RuleFor(x => x.TeamId)
                .NotEmpty().WithMessage("TeamId is required.");
        }
    }
}
