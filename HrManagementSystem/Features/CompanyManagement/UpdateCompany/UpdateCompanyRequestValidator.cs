using FluentValidation;

namespace HrManagementSystem.Features.CompanyManagement.UpdateCompany
{
    public class UpdateCompanyRequestValidator : AbstractValidator<UpdateCompanyRequestViewModel>
    {
        public UpdateCompanyRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Company Id is required.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Company name is required.")
                .MaximumLength(200).WithMessage("Company name must not exceed 200 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(250).WithMessage("Email must not exceed 250 characters.");

            RuleFor(x => x.CountryId)
                .NotEmpty().WithMessage("Country Id is required.");

            RuleFor(x => x.OrganizationId)
                .NotEmpty().WithMessage("Organization Id is required.");
        }
    }

}
