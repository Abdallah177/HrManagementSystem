namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManagement.GetAllBreaks
{
    public record GetAllBreaksResponseViewModel(string Id, string Name, TimeSpan Duration, bool IsPaid);
    
}
