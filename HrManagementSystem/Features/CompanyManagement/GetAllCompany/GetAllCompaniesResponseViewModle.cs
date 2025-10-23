namespace HrManagementSystem.Features.CompanyManagement.GetAllCompany
{
    public class GetAllCompaniesResponseViewModle
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string CountryName { get; set; } = null!;
        public string OrganizationName { get; set; } = null!;
    }
}
