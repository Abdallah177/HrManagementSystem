using HrManagementSystem.Common.Entities.Location;

namespace HrManagementSystem.Common.Entities
{
    public class Branch : BaseModel
    {
        public string Name { get; set; } = null!;
        public string? Phone { get; set; }

        public string CompanyId { get; set; } = null!;
        public Company Company { get; set; } = null!;

        public ICollection<Department> Departments { get; set; } = new List<Department>();

        public string CityId { get; set; } = null!;
        public City City { get; set; } = null!;
    }
}
