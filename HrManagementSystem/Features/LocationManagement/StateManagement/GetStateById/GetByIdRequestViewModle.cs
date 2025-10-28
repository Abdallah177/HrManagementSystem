using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.StateMangement.GetStateById
{
    public class GetByIdRequestViewModle
    {
        public string Id { get; set; } = null!;
    }

    public class GetStateByIdValiditor : AbstractValidator<GetByIdRequestViewModle>
    {
        public GetStateByIdValiditor()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("State Id Is Required");

        }


    }
}
