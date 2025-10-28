namespace HrManagementSystem.Features.CompanyManagement.GetAllCompany
{
    public class GetAllCompaniesResponseViewModle
    {
        public string Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public GetCountryWithCompanyViewModle country { get; set; }=null!;
        public GetOrganizationViewModle organization { get; set; } = null!;
    }

    public class GetCountryWithCompanyViewModle
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }

    public class GetOrganizationViewModle
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}