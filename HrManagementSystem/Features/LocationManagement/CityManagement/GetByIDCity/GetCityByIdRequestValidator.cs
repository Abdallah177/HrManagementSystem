using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.GetByIDCity
{
    public class GetCityByIdRequestValidator : FluentValidation.AbstractValidator<GetCityByIdRequestViewModel>
    {
        public GetCityByIdRequestValidator()
        {

             RuleFor(x => x.Id)
               .NotEmpty().WithMessage("Country Id is required.");
        }
    }
}
