using HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels;

namespace HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator
{
    public class AssignConfigRequest
    {
        public OrganizationViewModel ScopeViewModel { get; set; } = null!;
        public string ConfigId { get; set; } = null!;
    }

}
