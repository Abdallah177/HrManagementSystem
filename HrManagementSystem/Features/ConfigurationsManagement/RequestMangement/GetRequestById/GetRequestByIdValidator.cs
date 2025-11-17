using FluentValidation;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetRequestById
{
    public class GetRequestByIdValidator : AbstractValidator<GetRequestByIdRequesViewModel>
    {
        public GetRequestByIdValidator() 
        { 
            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Request Id is required.");
        }
    }
}
