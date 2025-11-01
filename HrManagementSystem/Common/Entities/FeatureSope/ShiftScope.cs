using HrManagementSystem.Common.Entities.Features;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class ShiftScope
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(ScopeBase))]
        public string ScopeId { get; set; }
        public ScopeBase ScopeBase { get; set; }

        [Required]
        [ForeignKey(nameof(Shift))]
        public string ShiftId { get; set; }
        public Shift Shift { get; set; }
    }
}
