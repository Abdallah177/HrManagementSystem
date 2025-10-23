using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.GetCountryById
{
    public class GetCountryByIdRequestValidator : AbstractValidator<GetCountryByIdRequestViewModel>
    {
        public GetCountryByIdRequestValidator()
        {
            RuleFor(x => x.Id)
             .NotEmpty().WithMessage("Country Id is required.");
        }
    }
}
