using FluentValidation;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.AddState
{
    public record AddStateRequestViewModel(string Name, string CountryId);

   
}
