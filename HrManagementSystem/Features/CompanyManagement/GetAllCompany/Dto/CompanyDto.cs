namespace HrManagementSystem.Features.CompanyManagement.GetAllCompany.Dto
{
    public class CompanyDto
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string CountryName { get; set; } = null!;
        public string OrganizationName { get; set; } = null!;
    }
}
