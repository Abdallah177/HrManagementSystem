using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.GetById
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
