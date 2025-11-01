using HrManagementSystem.Common.Entities.Features;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class OverTimeScope
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(ScopeBase))]
        public string ScopeId { get; set; }
        public ScopeBase ScopeBase { get; set; }

        [Required]
        [ForeignKey(nameof(OverTime))]
        public string OverTimeId { get; set; }
        public OverTime OverTime { get; set; }
    }
}
