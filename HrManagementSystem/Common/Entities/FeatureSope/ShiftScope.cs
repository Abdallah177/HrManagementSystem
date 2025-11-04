using HrManagementSystem.Common.Entities.Features;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class ShiftScope : BaseModel
    {
        [Required]
        [ForeignKey(nameof(ScopeBase))]
        public string ScopeId { get; set; } = null!;
        public ScopeBase ScopeBase { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Shift))]
        public string ShiftId { get; set; } = null!;
        public Shift Shift { get; set; } = null!;
    }
}
