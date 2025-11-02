using HrManagementSystem.Common.Entities.FeatureSope;
using HrManagementSystem.Common.Enums.FeatureEnums;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities.Features
{
    public class Vacation : BaseModel
    {
        public string Name { get; set; } = null!;

        [Required]
        public VacationType Type { get; set; }

        [Required]
        public int DurationInDays { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }
        
        public ICollection<VacationScope> VacationScopes { get; set; } = new List<VacationScope>();
    }
}
