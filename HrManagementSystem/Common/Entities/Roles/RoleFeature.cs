namespace HrManagementSystem.Common.Entities.Roles
{
    public class RoleFeature
    {
        public string RoleId { get; set; } = null!;
        public Role Role { get; set; } = null!;

        public string FeatureId { get; set; } = null!;
        public Feature Feature { get; set; } = null!;
    }
}
