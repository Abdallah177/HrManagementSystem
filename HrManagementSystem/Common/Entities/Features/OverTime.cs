using HrManagementSystem.Common.Entities.FeatureSope;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.Features
{
    public class OverTime : BaseModel
    {
        [Required]

        [Column(TypeName = "decimal(18,2)")]
        public decimal RatePerHour { get; set; }

        [Required]
        public int MaxHoursPerMonth { get; set; }

        public bool RequiresApproval { get; set; }
        
        public ICollection<OverTimeScope> OverTimeScopes { get; set; } = new List<OverTimeScope>();
    }
}
