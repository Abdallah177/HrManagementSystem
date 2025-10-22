using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.CityManagment.DeleteCity
{
    public class DeleteCityRequestViewModle
    {
        public string Id { get; set; }
    }
    public class DeleteCityRequestViewModleValiditor:AbstractValidator<DeleteCityRequestViewModle>
    {

        public DeleteCityRequestViewModleValiditor()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id Is Requierd");

        }
    }
}
