using FluentValidation;

namespace HrManagementSystem.Features.OrganizationManagement.AddOrganization
{
    public class AddOrganizationRequestViewModle
    {
        public string Name {  get; set; }
    }

    public class AddOrganizationRequestViewModleValiditor : AbstractValidator<AddOrganizationRequestViewModle>
    {
        public AddOrganizationRequestViewModleValiditor()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Name Is Requierd");
        }
    }
}
