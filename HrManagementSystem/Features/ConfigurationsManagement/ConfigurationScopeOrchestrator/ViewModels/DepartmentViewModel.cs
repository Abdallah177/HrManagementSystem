namespace HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels
{
    public class DepartmentViewModel
    {
        public string? DepartmentId { get; set; } = null!;
        public List<TeamViewModel?> teamViewModel { get; set; } = null!;
    }
}
