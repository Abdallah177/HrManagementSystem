using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.DTOS
{
    public record AddRequestDTO( string Id,string Title, string? Description, RequestStatus Status);
}
