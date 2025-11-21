namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.CreateBreakWithScopeOrchestrator
{
    public class MultiScopeViewModel
    {
        public string? OrganizationId { get; set; }
        public List<string>? CompanyIds { get; set; }
        public List<string>? BranchIds { get; set; }
        public List<string>? DepartmentIds { get; set; }
        public List<string>? TeamIds { get; set; }
    }

}
