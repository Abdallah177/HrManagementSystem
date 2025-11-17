namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.GetBreakById.Dtos
{
    public record BreakDto (string Id,string Name , TimeSpan Duration , bool IsPaid);
    
}
