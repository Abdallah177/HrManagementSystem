using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.UpdateRequest
{
    public record UpdateRequestRequestViewModel(string Id, string Title, string? Description, RequestStatus Status);

}
