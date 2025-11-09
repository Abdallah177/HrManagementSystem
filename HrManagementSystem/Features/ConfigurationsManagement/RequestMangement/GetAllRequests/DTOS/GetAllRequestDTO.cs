using HrManagementSystem.Common.Enums.FeatureEnums;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.GetAllRequests.DTOS
{
    public class GetAllRequestDTO
    {
        public string Id { get; set; }
        public string Tittle{ get; set; }
        public string? Description { get; set; }
        public RequestStatus Status { get; set; }
    }
}
