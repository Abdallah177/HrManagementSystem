using FluentValidation;

namespace HrManagementSystem.Features.ConfigurationsManagement.ProbationMangement.UpdateProbation
{
    public class UpdateProbationValidator : AbstractValidator<UpdateProbationRequestViewModel>
    {
        public UpdateProbationValidator() 
        {
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Probation Id is required.");

            RuleFor(x => x.EvaluationCriteria)
                .NotEmpty().WithMessage("Evaluation criteria is required.")
                .MaximumLength(500).WithMessage("Evaluation criteria must not exceed 500 characters.");

            RuleFor(x => x.DurationInDays)
                .GreaterThan(0).WithMessage("Duration in days must be greater than zero.");

                


        }
    }
}
