using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetRequestById.DTOS
{
    public class GetRequestByIdDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public RequestStatus Status { get; set; }
    }
}
