using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class BaseScope<T> : BaseModel where T : BaseModel
    {
        [Required]
        [ForeignKey(nameof(ScopeBase))]
        public string ScopeId { get; set; } = null!;
        public ScopeBase ScopeBase { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(T))]
        public string EntityId { get; set; } = null!;
        public T Entity { get; set; } = null!;
    }

}
