using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.UpdateCity.Validators
{
    public class UpdateCityRequestViewModelValidator : AbstractValidator<UpdateCityRequestViewModel>
    {
        public UpdateCityRequestViewModelValidator()
        {
            RuleFor(x => x.cityId)
                .NotEmpty().WithMessage("CityId is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("City name is required.")
                .MaximumLength(100).WithMessage("City name must not exceed 100 characters.");
            RuleFor(x => x.StateId)
                .NotEmpty().WithMessage("StateId is required.");
        }
    }
}
