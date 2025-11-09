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

                    // Validate branches if provided
                    company.RuleForEach(c => c.Branches)
                        .ChildRules(branch =>
                        {
                            branch.RuleFor(b => b.Name)
                                .NotEmpty()
                                .When(b => b != null)
                                .WithMessage("Branch name is required")
                                .MaximumLength(200)
                                .WithMessage("Branch name cannot exceed 200 characters");

                            branch.RuleFor(b => b.CityId)
                                .NotEmpty()
                                .When(b => b != null)
                                .WithMessage("City is required for each branch");

                            // Validate departments if provided
                            branch.RuleForEach(b => b.Departments)
                                .ChildRules(dept =>
                                {
                                    dept.RuleFor(d => d.Name)
                                        .NotEmpty()
                                        .When(d => d != null)
                                        .WithMessage("Department name is required")
                                        .MaximumLength(200)
                                        .WithMessage("Department name cannot exceed 200 characters");

                                    // Validate teams if provided
                                    dept.RuleForEach(d => d.Teams)
                                        .ChildRules(team =>
                                        {
                                            team.RuleFor(t => t.Name)
                                                .NotEmpty()
                                                .When(t => t != null)
                                                .WithMessage("Team name is required")
                                                .MaximumLength(200)
                                                .WithMessage("Team name cannot exceed 200 characters");
                                        });
                                });
                        });
                });
        }
    }
}

