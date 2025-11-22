using FluentValidation;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.UpdateVacation
{
    public class UpdateVactionViladator : AbstractValidator<UpdateVacationRequestViewModel>
    {
        public UpdateVactionViladator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Vacation Id is required.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Vacation name is required.")
                .MaximumLength(100).WithMessage("Vacation name must not exceed 100 characters.");
            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid vacation type.");
            RuleFor(x => x.DurationInDays)
                .GreaterThan(0).WithMessage("Duration in days must be greater than zero.");
            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("Description must not exceed 200 characters.");
        }
    }
    
}
