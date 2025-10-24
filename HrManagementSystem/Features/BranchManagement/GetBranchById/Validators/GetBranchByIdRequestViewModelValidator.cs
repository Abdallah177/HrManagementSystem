using FluentValidation;

namespace HrManagementSystem.Features.BranchManagement.GetBranchById.Validators
{
    public class GetBranchByIdRequestViewModelValidator : AbstractValidator<GetBranchByIdRequestViewModel>
    {
        public GetBranchByIdRequestViewModelValidator()
        {
            RuleFor(x => x.BranchId)
                .NotEmpty().WithMessage("BranchId is required");
        }
    }
}
