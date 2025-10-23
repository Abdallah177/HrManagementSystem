namespace HrManagementSystem.Common.Entities.Roles
{
    public class Role:BaseModel
    {
        public string Name { get; set; } = null!;
        public ICollection<RoleFeature> RoleFeatures { get; set; } = new List<RoleFeature>();
    }
}
