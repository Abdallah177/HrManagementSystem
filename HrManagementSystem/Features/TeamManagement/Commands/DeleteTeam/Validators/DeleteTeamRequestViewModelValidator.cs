using FluentValidation;

namespace HrManagementSystem.Features.TeamManagement.Commands.DeleteTeam.Validators
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
