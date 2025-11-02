using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities.Features
{
    public class Probation : BaseModel
    {
        [Required]
        public int DurationInDays { get; set; }

        [MaxLength(300)]
        public string? EvaluationCriteria { get; set; }

        [Required]
        public ProbationStatus Status { get; set; } = ProbationStatus.Active;
        
        public ICollection<ProbationScope> ProbationScopes { get; set; } = new List<ProbationScope>();
    }
}
