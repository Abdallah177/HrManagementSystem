namespace HrManagementSystem.Common.Entities.Roles
{
    public class Feature:BaseModel
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!; 
        public ICollection<RoleFeature> RoleFeatures { get; set; } = new List<RoleFeature>();
    }
}
