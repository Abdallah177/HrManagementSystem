using HrManagementSystem.Common.Entities.FeatureSope;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities.Features
{
    public class OverTime : BaseModel
    {
        [Required]
        public decimal RatePerHour { get; set; }

        [Required]
        public int MaxHoursPerMonth { get; set; }

        public bool RequiresApproval { get; set; }
        
        public ICollection<OverTimeScope> OverTimeScopes { get; set; } = new List<OverTimeScope>();
    }
}
