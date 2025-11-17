namespace HrManagementSystem.Features.CompanyManagement.AddCompany
{
    public class AddCompanyResponseViewModel
    {
        public string OrganizationId { get; set; }
        public string CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string? CompanyEmail { get; set; }
        public string CountryId { get; set; }
        public List<BranchInformationResponseViewModel> Branches {  get; set; }
    }

    public class BranchInformationResponseViewModel
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public string CityId { get; set; }

        public List<DepartmentInformationResponseViewModel> Departments { get; set; }
    }

    public class DepartmentInformationResponseViewModel
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public List<TeamInformationResponseViewModel> Teams { get; set; }
    }

    public class TeamInformationResponseViewModel
    {
        public string TeamId { get; set; }
        public string TeamName { get; set; }
    }


}
