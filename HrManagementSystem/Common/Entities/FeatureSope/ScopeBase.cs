using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrManagementSystem.Common.Entities.FeatureSope
{
    public class ScopeBase
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey(nameof(Organization))]
        public string? OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [ForeignKey(nameof(Company))]
        public string? CompanyId { get; set; }
        public Company Company { get; set; }

        [ForeignKey(nameof(Branch))]
        public string? BranchId { get; set; }
        public Branch Branch { get; set; }

        [ForeignKey(nameof(Department))]
        public string? DepartmentId { get; set; }
        public Department Department { get; set; }

        [ForeignKey(nameof(Team))]
        public string? TeamId { get; set; }
        public Team Team { get; set; }
    }
}
