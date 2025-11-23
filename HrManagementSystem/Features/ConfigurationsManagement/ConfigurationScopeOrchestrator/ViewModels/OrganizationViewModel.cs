namespace HrManagementSystem.Features.ConfigurationsManagement.ConfigurationScopeOrchestrator.ViewModels
{
    public class OrganizationViewModel
    {
        public string? OrganizationId { get; set; } = null!;
        public List<CompanyViewModel?> companyViewModel { get; set; } = null!;
    }
}
