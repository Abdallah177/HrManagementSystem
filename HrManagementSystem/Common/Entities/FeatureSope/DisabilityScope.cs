using HrManagementSystem.Common.Entities.Features;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class DisabilityScope : BaseModel
    {
        [Required]
        [ForeignKey(nameof(ScopeBase))]
        public string ScopeId { get; set; } = null!;
        public ScopeBase ScopeBase { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Disability))]
        public string DisabilityId { get; set; } = null!;
        public Disability Disability { get; set; } = null!;
    }
}
