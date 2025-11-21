namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.CreateBreakWithScopeOrchestrator
{
    public class CreateBreakWithScopeRequestViewModel
    {
        public string Name { get; set; } = null!;
        public TimeSpan Duration { get; set; }
        public bool IsPaid { get; set; }

        public MultiScopeViewModel ScopeViewModel { get; set; } = null!;
    }
}
