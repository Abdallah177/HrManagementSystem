using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities
{
    public class Department : BaseModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}
