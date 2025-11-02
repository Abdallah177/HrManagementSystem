using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class ScopeBase : BaseModel
    {
        [ForeignKey(nameof(Organization))]
        public string? OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;

        [ForeignKey(nameof(Company))]
        public string? CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        [ForeignKey(nameof(Branch))]
        public string? BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        [ForeignKey(nameof(Department))]
        public string? DepartmentId { get; set; }
        public Department Department { get; set; } = null!;

        [ForeignKey(nameof(Team))]
        public string? TeamId { get; set; }
        public Team Team { get; set; } = null!;
    }
}
