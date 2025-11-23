namespace HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels
{
    public class BranchViewModel
    {
        public string? BranchId { get; set; } = null!;

        public List<DepartmentViewModel> departmentViewModels { get; set; } = null!;
    }
}
