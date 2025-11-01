using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.Queries.GetCountryById
{
    public class GetCountryByIdRequestValidator : AbstractValidator<GetCountryByIdRequestViewModel>
    {
        public GetCountryByIdRequestValidator()
        {
            RuleFor(x => x.countryId)
             .NotEmpty().WithMessage("Country Id is required.");
        }
    }
}
