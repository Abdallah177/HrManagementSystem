using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities.Features
{
    public class Request : BaseModel
    {
        [Required, MaxLength(150)]
        public string Title { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public RequestStatus Status { get; set; } = RequestStatus.Pending;

        
        public ICollection<RequestScope> RequestScopes { get; set; }
    }
}
