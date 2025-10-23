namespace HrManagementSystem.Common.Entities
{
    public class Organization : BaseModel
    {
        public string Name { get; set; } = null!;
        public ICollection<Company> Companies { get; set; } = new List<Company>();

    }
}
