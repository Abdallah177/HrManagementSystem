using Azure.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class RequestScope
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(ScopeBase))]
        public string ScopeId { get; set; }
        public ScopeBase ScopeBase { get; set; }

        [Required]
        [ForeignKey(nameof(Request))]
        public string RequestId { get; set; }
        public Request Request { get; set; }
    }
}
