using HrManagementSystem.Common.Entities.Features;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class VacationScope : BaseModel
    {

        [Required]
        [ForeignKey(nameof(ScopeBase))]
        public string ScopeId { get; set; } = null!;
        public ScopeBase ScopeBase { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Vacation))]
        public string VacationId { get; set; } = null!;
        public Vacation Vacation { get; set; } = null!;
    }
}
