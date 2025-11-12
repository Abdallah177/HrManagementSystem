namespace HrManagementSystem.Features.ConfigurationsManagement.BreakManageMent.GetAllBreaks.Dtos
{
    public record BreakDto (string Id,string Name , TimeSpan Duration , bool IsPaid);
    
}
