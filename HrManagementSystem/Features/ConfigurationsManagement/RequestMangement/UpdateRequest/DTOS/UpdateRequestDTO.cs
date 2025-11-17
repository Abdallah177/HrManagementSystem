using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Features.ConfigurationsManagement.RequestMangement.UpdateRequest.DTOS
{
    public class UpdateRequestDTO
    {
        public string Id { get; set; }
        public string Title { get; set; } 
        public string? Description { get; set; }

        public RequestStatus Status { get; set; }
    }
}
