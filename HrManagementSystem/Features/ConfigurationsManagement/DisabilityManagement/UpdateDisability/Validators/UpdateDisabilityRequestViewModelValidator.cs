using FluentValidation;

namespace HrManagementSystem.Features.DisabilityManagement.UpdateDisability.Validators
{
    public class UpdateDisabilityRequestViewModelValidator : AbstractValidator<UpdateDisabilityRequestViewModel>
    {
        public UpdateDisabilityRequestViewModelValidator()
        {

            RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage("Disability ID is required");

            RuleFor(x => x.Type)
                .IsInEnum()
                .WithMessage("Invalid disability type");

            //RuleFor(x => x.Description)
            //    .MaximumLength(300)
            //    .WithMessage("Description cannot exceed 300 characters")
            //    .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.RequiresSpecialSupport)
                .NotNull()
                .WithMessage("RequiresSpecialSupport must be specified");
        }

    }
}

