using HrManagementSystem.Common.Entities.Features;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class VacationScope
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(ScopeBase))]
        public string ScopeId { get; set; }
        public ScopeBase ScopeBase { get; set; }

        [Required]
        [ForeignKey(nameof(Vacation))]
        public string VacationId { get; set; }
        public Vacation Vacation { get; set; }
    }
}
