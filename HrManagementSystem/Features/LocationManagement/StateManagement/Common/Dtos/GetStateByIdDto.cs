using MediatR;

namespace HrManagementSystem.Features.LocationManagement.StateManagement.Common.Dtos
{
    public record GetStateByIdDto (string Id , string Name , string CountryId);
    
}
