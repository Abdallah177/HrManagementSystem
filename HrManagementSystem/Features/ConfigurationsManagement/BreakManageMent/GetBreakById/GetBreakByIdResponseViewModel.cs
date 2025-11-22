namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.GetBreakById
{
    public record GetBreakByIdResponseViewModel(string Id, string Name, TimeSpan Duration, bool IsPaid);

}
