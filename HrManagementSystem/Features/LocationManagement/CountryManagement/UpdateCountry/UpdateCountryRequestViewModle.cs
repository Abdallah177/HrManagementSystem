using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.CountryManagement.UpdateCountry
{
    public class UpdateCountryRequestViewModle
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Code { get; set; }
    }

    public class UpdateCountryValidator : AbstractValidator<UpdateCountryRequestViewModle>
    {
        public UpdateCountryValidator()

        {
            RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Country Id is required");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Country name is required")
                .MaximumLength(50).WithMessage("Country name too long");

            RuleFor(x => x.Code)
                .MaximumLength(10).WithMessage("Country code too long");


        }
    }


}
