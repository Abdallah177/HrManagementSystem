using HrManagementSystem.Common.Entities.FeatureSope;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities.Features
{
    public class Break : BaseModel
    {
        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public bool IsPaid { get; set; }

        
        public ICollection<BreakScope> BreakScopes { get; set; }
    }
}
