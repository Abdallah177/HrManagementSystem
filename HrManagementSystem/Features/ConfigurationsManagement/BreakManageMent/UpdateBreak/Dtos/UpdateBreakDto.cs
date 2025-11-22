namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.UpdateBreak.Dtos
{
    public record UpdateBreakDto(string Id, string Name, TimeSpan Duration, bool IsPaid);
   
}
