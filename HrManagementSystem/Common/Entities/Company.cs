using HrManagementSystem.Common.Entities.Location;
using System.ComponentModel.DataAnnotations;

namespace HrManagementSystem.Common.Entities
{
    public class Company : BaseModel
    {
        public string Name { get; set; } = null!;
        public string? Email { get; set; }

        public string CountryId { get; set; } = null!;
        public Country Country { get; set; } = null!;

        public string OrganizationId { get; set; } = null!;
        public Organization Organization { get; set; } = null!;

        public ICollection<Branch> Branches { get; set; } = new List<Branch>();
    }
}
