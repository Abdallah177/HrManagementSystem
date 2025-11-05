using FluentValidation;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.GetProbationById
{
    public class GetProbationByIdValidator : AbstractValidator<GetProbationByIdRequesViewModel>
    {
        public GetProbationByIdValidator() 
        { 
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Probation Id is required.");

        }
    }
}
