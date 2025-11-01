using FluentValidation;

namespace HrManagementSystem.Features.CompanyManagement.DeleteCompany.Validators
{
    public class DeleteCompanyRequestViewModelValidator : AbstractValidator<DeleteCompanyRequestViewModel>
    {
        public DeleteCompanyRequestViewModelValidator()
        {

            RuleFor(x => x.CompanyId)
                 .NotEmpty().WithMessage("CompanyId is required");
        }
    }
}


