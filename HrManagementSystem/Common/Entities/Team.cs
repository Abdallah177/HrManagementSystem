namespace HrManagementSystem.Common.Entities
{
    public class Team : BaseModel
    {
        public string Name { get; set; } = null!;

        public string DepartmentId { get; set; } = null!;
        public Department Department { get; set; } = null!;
    }
}
