using FluentValidation;

namespace HrManagementSystem.Features.ConfigurationsManagement.VacationMangement.GetVacationById
{
    public class GetVacationByIdValidator : AbstractValidator<GetVacationByIdRequestViewModel>
    {
        public GetVacationByIdValidator()
        {

            RuleFor(x => x.Id)
             .NotEmpty().WithMessage("Probation Id is required.");
        }
    }
}
