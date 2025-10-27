using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.CityManagement.Queries.GetByIDCity
{
    public class GetCityByIdRequestValidator : AbstractValidator<GetCityByIdRequestViewModel>
    {
        public GetCityByIdRequestValidator()
        {

            RuleFor(x => x.Id)
              .NotEmpty().WithMessage("Country Id is required.");
        }
    }
}
