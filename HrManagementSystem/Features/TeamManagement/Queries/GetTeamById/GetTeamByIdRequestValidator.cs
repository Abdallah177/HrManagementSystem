using FluentValidation;

namespace HrManagementSystem.Features.TeamManagement.Queries.GetTeamById
{
    public class GetTeamByIdRequestValidator : AbstractValidator<GetTeamByIdRequestViewModel>
    {
        public GetTeamByIdRequestValidator() 
        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("State Id is required.");

        }

    }
}
