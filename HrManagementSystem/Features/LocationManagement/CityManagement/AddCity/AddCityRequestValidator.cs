using FluentValidation;
using HrManagementSystem.Features.LocationManagement.StateManagement.UpdateState;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.AddCity
{
    public class AddCityRequestValidator : AbstractValidator<AddCityRequestViewModel>
    {
        public AddCityRequestValidator()
        {
            RuleFor(x => x.Name)
           .NotEmpty().WithMessage("State Id is required.");

            RuleFor(x => x.StateId)
                .NotEmpty().WithMessage("State name is required.");
        }
    }
}
