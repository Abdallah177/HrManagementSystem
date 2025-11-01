using HrManagementSystem.Common.Entities.Features;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class ProbationScope
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(ScopeBase))]
        public string ScopeId { get; set; }
        public ScopeBase ScopeBase { get; set; }

        [Required]
        [ForeignKey(nameof(Probation))]
        public string ProbationId { get; set; }
        public Probation Probation { get; set; }
    }
}
