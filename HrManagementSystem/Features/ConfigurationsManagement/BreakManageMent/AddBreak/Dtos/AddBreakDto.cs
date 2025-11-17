namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.AddBreak.Dtos
{
    public record AddBreakDto(string Id, string Name, TimeSpan Duration, bool IsPaid);

}
