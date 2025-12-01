using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.AddRequest.DTOS
{
    public record AddRequestDTO(string Title, string? Description, RequestStatus Status);
}
