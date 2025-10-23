namespace HrManagementSystem.Features.OrganizationManagement.GetAllOrganization
{
    public class GetAllOrganizationResponseViewModel
    {
        public string OrganizationId {  get; set; }
        public string OrganizationName { get; set;}
        public List<GetCompaniesViewModel> Companies { get; set; } = new List<GetCompaniesViewModel>();

    }

    public class GetCompaniesViewModel
    {
        public string CompanyId { get; set; }
        public string CompanyName { get; set;}
        public List<GetBranchesViewModel> Branches { get; set; } = new List<GetBranchesViewModel>();

    }

    public class GetBranchesViewModel
    {
        public string BranchId { get; set; }
        public string BranchName { get; set; }
        public List<GetDepartmentsViewModels> Departments { get; set; } = new List<GetDepartmentsViewModels>();
    }

    public class GetDepartmentsViewModels
    {
        public string DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<GetTeamsViewModels> Teams { get; set; } = new List<GetTeamsViewModels>();
    }

    public class GetTeamsViewModels
    {
        public string TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
