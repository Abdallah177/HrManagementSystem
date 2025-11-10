using FluentValidation;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.UpdateRequest
{
    public class UpdateRequestValidator : AbstractValidator<UpdateRequestRequestViewModel>
    {
        public UpdateRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Request Id is required.");
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(150).WithMessage("Title must not exceed 150 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Invalid request status.");
        }
    }
    
}
