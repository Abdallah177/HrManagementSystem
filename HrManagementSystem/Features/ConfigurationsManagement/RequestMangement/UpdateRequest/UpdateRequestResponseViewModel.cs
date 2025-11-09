using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.UpdateRequest
{
    public record UpdateRequestResponseViewModel(string Id, string Title, string? Description, RequestStatus Status);

}
