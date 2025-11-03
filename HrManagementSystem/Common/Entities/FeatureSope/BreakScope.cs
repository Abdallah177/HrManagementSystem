using HrManagementSystem.Common.Entities.Features;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class BreakScope : BaseModel
    {
        [Required]
        [ForeignKey(nameof(ScopeBase))]
        public string ScopeId { get; set; } = null!;
        public ScopeBase ScopeBase { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Break))]
        public string BreakId { get; set; } = null!;
        public Break Break { get; set; } = null!;
    }
}
