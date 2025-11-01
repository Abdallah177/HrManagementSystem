using FluentValidation;

namespace HrManagementSystem.Features.CompanyManagement.GetCompanyById.Validators
{
    public class GetCompanyByIdRequestViewModelValidator : AbstractValidator<GetCompanyByIdRequestViewModel>
    {
        public GetCompanyByIdRequestViewModelValidator() 
        {

            RuleFor(x => x.companyId)
                 .NotEmpty().WithMessage("CompanyId is required");

        }
    }
}
