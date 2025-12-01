using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels;

namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.CreateBreakWithScopeOrchestrator
{
    public class CreateBreakWithScopeRequestViewModel
    {
        public string Name { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public bool IsPaid { get; set; }

        public OrganizationViewModel ScopeViewModel { get; set; } = null!;
    }
}
