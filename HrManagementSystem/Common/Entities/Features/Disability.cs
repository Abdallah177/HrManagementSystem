using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities.Features
{
    public class Disability : BaseModel
    {
        [Required]
        public DisabilityType Type { get; set; }

        [MaxLength(300)]
        public string? Description { get; set; }

        [Required]
        public bool RequiresSpecialSupport { get; set; }

        
        public ICollection<DisabilityScope> DisabilityScopes { get; set; }
    }
}
