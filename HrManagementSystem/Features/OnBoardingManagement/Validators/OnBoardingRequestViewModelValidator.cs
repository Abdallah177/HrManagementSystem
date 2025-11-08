using FluentValidation;

namespace HrManagementSystem.Features.OnBoardingManagement.Validators
{
    public class OnBoardingRequestViewModelValidator : AbstractValidator<OnBoardingRequestViewModel>
    {
        public OnBoardingRequestViewModelValidator()
        {
            RuleFor(x => x.Organization)
               .NotNull()
               .WithMessage("Organization is required");

            RuleFor(x => x.Organization.Name)
                .NotEmpty()
                .WithMessage("Organization name is required")
                .MaximumLength(200)
                .WithMessage("Organization name cannot exceed 200 characters");

            RuleFor(x => x.Organization.Companies)
                .NotNull().NotEmpty()
                .WithMessage("At least one company is required");

            RuleForEach(x => x.Organization.Companies)
                .ChildRules(company =>
                {
                    company.RuleFor(c => c.Name)
                        .NotEmpty()
                        .WithMessage("Company name is required")
                        .MaximumLength(200)
                        .WithMessage("Company name cannot exceed 200 characters");

                    company.RuleFor(c => c.CountryId)
                        .NotEmpty()
                        .WithMessage("Country is required for each company");

                    company.RuleFor(c => c.Email)
                        .EmailAddress()
                        .When(c => !string.IsNullOrEmpty(c.Email))
                        .WithMessage("Invalid email format");
                });
        }
    }
}

